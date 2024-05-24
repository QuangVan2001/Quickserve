﻿using Microsoft.EntityFrameworkCore;
using QuickServe.Application.Interfaces;
using QuickServe.Infrastructure.FileManager.Contexts;
using QuickServe.Infrastructure.FileManager.Models;
using System.Threading.Tasks;

namespace QuickServe.Infrastructure.FileManager.Services
{
    public class FileManagerService(FileManagerDbContext fileManagerDbContext) : IFileManagerService
    {
        public async Task Create(string name, byte[] content)
        {
            await fileManagerDbContext.Files.AddAsync(new FileEntity(name, content));
        }

        public async Task Delete(string name)
        {
            var file = await fileManagerDbContext.Files.FirstOrDefaultAsync(p => p.Name == name);
            fileManagerDbContext.Files.Remove(file);
        }

        public async Task<byte[]> Download(string name)
        {
            var file = await fileManagerDbContext.Files.FirstOrDefaultAsync(p => p.Name == name);
            return file?.Content;
        }

        public async Task Update(string name, byte[] content)
        {
            var file = await fileManagerDbContext.Files.FirstOrDefaultAsync(p => p.Name == name);
            if (file is null)
            {
                await Create(name, content);
            }
            else
            {
                file.UpdateContent(content);
            }
        }
        public async Task<int> SaveChangesAsync() => 
            await fileManagerDbContext.SaveChangesAsync();
    }
}