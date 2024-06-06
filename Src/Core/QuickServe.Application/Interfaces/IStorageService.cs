using QuickServe.Domain.File;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces
{
    public interface IStorageService
    {
        public Task<BlobFileInfo> UploadAsync(string name, byte[] content, string extension);
        public Task<byte[]> DownloadAsync(string name);
        public Task DeleteAsync(string name);
        public Task UpdateAsync(string name, byte[] content, string extension);
    }
}
