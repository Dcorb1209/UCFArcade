using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightArcade.Infrastructure.Data.Interface
{
    public interface IS3Data
    {
        Task<bool> CreateS3BucketAsync(string bucketName);
        Task WritingAnObjectAsync(string bucketName, string folderPath, string objectName);
        Task ListingObjectsAsync(string bucketName);
        Task<bool> DeleteS3BucketFolderAsync(string bucketName, string folderPath);
        Task<bool> DeleteS3BucketFolderObjectAsync(string bucketName, string folderPath, string objectName);
        Task<object> ReadObjectDataAsync(string bucketName, string folderPath, string objectName);
        Task<object> GetFolderFromS3BucketAsync(string bucketName, string folderPath);
    }
}
