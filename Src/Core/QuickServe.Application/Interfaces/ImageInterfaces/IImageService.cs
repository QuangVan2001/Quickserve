using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.ImageInterfaces
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile image);
        Task<string> UpdateImageAsync(string oldImage, IFormFile image);
    }
}
