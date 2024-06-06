using Azure.Storage.Blobs;
using QuickServe.Application.Interfaces;
using QuickServe.Domain.File;
using System;
using System.IO;
using System.Threading.Tasks;

namespace QuickServe.Infrastructure.FileManager.Services
{

    public class BlobStorageService(BlobServiceClient blobServiceClient) : IStorageService
    {
        private const string ContainerName = "files";
        private readonly BlobServiceClient _blobServiceClient = blobServiceClient;
        private readonly BlobContainerClient _containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

        public async Task<BlobFileInfo> UploadAsync(string name, byte[] content, string extension)
        {
            var now = DateTime.UtcNow;
            name = name.Replace(" ", "-") + now.ToString("yyyyMMddHHmmss") + extension;
            var storageAccountName = _blobServiceClient.AccountName;
            var url = $"https://{storageAccountName}.blob.core.windows.net/{ContainerName}/{name}";
            var blobClient = _containerClient.GetBlobClient(name);
            await blobClient.UploadAsync(new MemoryStream(content), true);
            return new BlobFileInfo
            { 
                Name = name,
                Path = url,
                Extension = extension
            };
        }

        public async Task<byte[]> DownloadAsync(string name)
        {
            var blobClient = _containerClient.GetBlobClient(name);
            var response = await blobClient.DownloadAsync();
            using var memoryStream = new MemoryStream();
            await response.Value.Content.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public async Task DeleteAsync(string name)
        {
            var blobClient = _containerClient.GetBlobClient(name);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task UpdateAsync(string name, byte[] content, string extension)
        {
            await DeleteAsync(name);
            await UploadAsync(name, content, extension);
        }
    }
}
