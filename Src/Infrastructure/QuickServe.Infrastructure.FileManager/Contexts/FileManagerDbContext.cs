using Microsoft.EntityFrameworkCore;
using QuickServe.Infrastructure.FileManager.Models;

namespace QuickServe.Infrastructure.FileManager.Contexts
{
    public class FileManagerDbContext : DbContext
    {
        public FileManagerDbContext(DbContextOptions<FileManagerDbContext> options) : base(options)
        {

        }

        public DbSet<FileEntity> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}