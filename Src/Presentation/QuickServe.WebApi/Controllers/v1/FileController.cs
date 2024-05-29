using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.File;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class FileController(IStorageService storageService) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetFile(string name)
        {
            var bytes = await storageService.DownloadAsync(name);

            return File(bytes, MediaTypeNames.Application.Octet, name);
        }

        [HttpPost]
        public async Task<BaseResult<BlobFileInfo>> UploadFile(string name, IFormFile file)
        {
            using MemoryStream memoryStream = new();
            file.CopyTo(memoryStream);
            var extension = Path.GetExtension(file.FileName);
            var fileInfo = await storageService.UploadAsync(name, memoryStream.ToArray(), extension);
            return new BaseResult<BlobFileInfo>(fileInfo);
        }

        [HttpDelete]
        public async Task<BaseResult<string>> DeleteFile(string name)
        {
            await storageService.DeleteAsync(name);
            return  new BaseResult<string>(name);
        }

        [HttpPut]
        public async Task<BaseResult<string>> UpdateFile(string name, IFormFile file)
        {
            using MemoryStream memoryStream = new();
            file.CopyTo(memoryStream);
            var extension = Path.GetExtension(file.FileName);
            await storageService.UpdateAsync(name, memoryStream.ToArray(), extension);
            return new BaseResult<string>(name);
        }
    }
}