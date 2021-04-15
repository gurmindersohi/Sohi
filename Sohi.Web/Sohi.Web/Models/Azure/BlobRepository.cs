using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.WindowsAzure.Storage;

namespace Sohi.Web.Models.Azure
{
    public class BlobRepository : IBlobRepository
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobRepository(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<BlobInfo> CreateBlobAsync(string name)
        {
            //CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse();


            //var containerClient = _blobServiceClient.GetBlobContainerClient("sohi");


            //var blob = containerClient.ge
            return null;

        }


        public async Task<BlobInfo> GetBlobAsync(string name)
        {

            throw new NotImplementedException();

            var containerClient = _blobServiceClient.GetBlobContainerClient("sohi");

            var blobClient = containerClient.GetBlobClient(name);


            var blobDownloadInfo = await blobClient.DownloadAsync();

            //return new BlobInfo(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);

            return null;

        }

        public async Task<IEnumerable<string>> ListBlobsAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("websites");

            var items = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync()) {
                items.Add(blobItem.Name);
            }

            return items;
        }
    }
}
