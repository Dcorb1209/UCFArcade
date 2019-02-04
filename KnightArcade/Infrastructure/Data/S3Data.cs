using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using KnightArcade.Infrastructure.Data.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KnightArcade.Infrastructure.Data
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

        public async Task<bool> CreateS3BucketAsync(string bucketName)
        {
            try
            {
                if(await AmazonS3Util.DoesS3BucketExistAsync(_s3Client, bucketName) == false)
                {
                    PutBucketRequest putBucketRequest = new PutBucketRequest()
                    {
                        BucketName = bucketName,
                        UseClientRegion = true
                    };

                    PutBucketResponse response = await _s3Client.PutBucketAsync(putBucketRequest);
                }

                return true;
            }
            catch(AmazonS3Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public async Task WritingAnObjectAsync(string bucketName, string folderPath, string objectName)
        {
            try
            {
                // 1. Put object-specify only key name for the new object.
                var putRequest1 = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = folderPath + "/" + objectName,
                    ContentBody = "sample text"
                };

                PutObjectResponse response1 = await _s3Client.PutObjectAsync(putRequest1);

                // 2. Put the object-set ContentType and add metadata.
                var putRequest2 = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectName,
                    FilePath = folderPath,
                    ContentType = "text/plain"
                };
                putRequest2.Metadata.Add("x-amz-meta-title", "someTitle");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }
        }

        public async Task<bool> DeleteS3BucketFolderAsync(string bucketName, string folderPath)
        {
            try
            {
                DeleteObjectsRequest deleteItems = new DeleteObjectsRequest();
                ListObjectsRequest itemsRequest = new ListObjectsRequest
                {
                    BucketName = bucketName,
                    Prefix = folderPath
                };

                ListObjectsResponse itemsResponse = _s3Client.ListObjectsAsync(itemsRequest).Result;
                foreach(S3Object s in itemsResponse.S3Objects)
                {
                    deleteItems.AddKey(s.Key);
                }
                deleteItems.BucketName = bucketName;
                await _s3Client.DeleteObjectsAsync(deleteItems);
                return true;
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

        public async Task<bool> DeleteS3BucketFolderObjectAsync(string bucketName, string folderPath, string objectName)
        {
            try
            {
                DeleteObjectsRequest deleteItems = new DeleteObjectsRequest();
                ListObjectsRequest itemsRequest = new ListObjectsRequest
                {
                    BucketName = bucketName,
                    Prefix = folderPath
                };

                ListObjectsResponse itemsResponse = _s3Client.ListObjectsAsync(itemsRequest).Result;
                foreach (S3Object s in itemsResponse.S3Objects)
                {
                    if(s.Key.Equals(objectName))
                    {
                        deleteItems.AddKey(s.Key);
                    }
                }
                deleteItems.BucketName = bucketName;
                await _s3Client.DeleteObjectsAsync(deleteItems);
                return true;
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

        public async Task<object> ReadObjectDataAsync(string bucketName, string folderPath, string objectName)
        {
            string responseBody = "";
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = folderPath + "/" + objectName
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

                    /* Saves to current directory
                    string tempFileName = System.IO.Path.GetTempFileName();
                    await response.WriteResponseStreamToFileAsync(tempFileName, true, cancellationToken);
                    ZipFile.ExtractToDirectory(tempFileName, AppDomain.CurrentDomain.BaseDirectory);
                    */
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

        public async Task<object> GetFolderFromS3BucketAsync(string bucketName, string folderName)
        {
            return false;
        }
    }
}
