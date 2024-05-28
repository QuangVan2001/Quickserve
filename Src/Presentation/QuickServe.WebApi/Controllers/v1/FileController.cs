using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    //[ApiVersion("1")]
    public class FileController(IFileManagerService fileManagerService) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetFile(string name)
        {
            var bytes = await fileManagerService.Download(name);

            return File(bytes, MediaTypeNames.Application.Octet, name);
        }

        [HttpPost]
        public async Task<BaseResult<string>> UploadFile(string name, IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                await fileManagerService.Create(name, memoryStream.ToArray());
                await fileManagerService.SaveChangesAsync();

                return new(name);
            }
        }

        [HttpDelete]
        public async Task<BaseResult<string>> DeleteFile(string name)
        {
            await fileManagerService.Delete(name);
            await fileManagerService.SaveChangesAsync();
            return  new BaseResult<string>(name);
        }

        [HttpPut]
        public async Task<BaseResult<string>> UpdateFile(string name, IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                await fileManagerService.Update(name, memoryStream.ToArray());
                await fileManagerService.SaveChangesAsync();

                return new BaseResult<string>(name);

            }
        }
    }
}