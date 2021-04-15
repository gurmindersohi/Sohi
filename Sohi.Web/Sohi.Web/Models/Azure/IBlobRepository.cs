using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Sohi.Web.Models.Azure
{
    public interface IBlobRepository
    {
        public Task<BlobInfo> GetBlobAsync(string name);

        public Task<IEnumerable<string>> ListBlobsAsync();
    }
}
