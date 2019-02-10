using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedTesting.Infrastructure.Data.Infrastructure
{
    public interface IS3Data
    {
        Task ListingObjectsAsync(string bucketName);
        Task<object> ReadObjectDataAsync(string key);
    }
}
