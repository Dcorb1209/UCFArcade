using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using AutomatedTesting.Infrastructure.Data.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedTesting.Infrastructure.Data
{
    public class S3Data : IS3Data
    {
        private readonly ILogger<S3Data> _logger;
        private readonly IAmazonS3 _s3Client;
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        //ToDo: Put credentials in a secret location
        public S3Data(ILogger<S3Data> logger, IConfiguration config)
        {
            _logger = logger;
            _s3Client = new AmazonS3Client(config.GetSection("AWSCredentials:AWSAccessKey").Value,
                config.GetSection("AWSCredentials:AWSSecretKey").Value, bucketRegion);
        }

        public async Task<object> ReadObjectDataAsync(string key)
        {
            string responseBody = "";
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = "knightarcade",
                    Key = key
                };

                CancellationToken cancellationToken = new CancellationToken();

                using (GetObjectResponse response = await _s3Client.GetObjectAsync(request))
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string title = response.Metadata["x-amz-meta-title"];
                    string contentType = response.Headers["Content-Type"];
                    Console.WriteLine("Object metadata, Title: {0}", title);
                    Console.WriteLine("Content type: {0}", contentType);

                    //Saves to current directory
                    string tempFileName = System.IO.Path.GetTempFileName();
                    await response.WriteResponseStreamToFileAsync(tempFileName, true, cancellationToken);
                    ZipFile.ExtractToDirectory(tempFileName, AppDomain.CurrentDomain.BaseDirectory);
                    
                }

                return responseBody;
            }
            catch (AmazonS3Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public async Task ListingObjectsAsync(string bucketName)
        {
            try
            {
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = bucketName,
                    MaxKeys = 10
                };
                ListObjectsV2Response response;
                do
                {
                    response = await _s3Client.ListObjectsV2Async(request);

                    // Process the response.
                    foreach (S3Object entry in response.S3Objects)
                    {
                        Console.WriteLine("key = {0} size = {1}",
                            entry.Key, entry.Size);
                    }
                    Console.WriteLine("Next Continuation Token: {0}", response.NextContinuationToken);
                    request.ContinuationToken = response.NextContinuationToken;
                } while (response.IsTruncated);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Console.WriteLine("S3 error occurred. Exception: " + amazonS3Exception.ToString());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                Console.ReadKey();
            }
        }

    }

}
