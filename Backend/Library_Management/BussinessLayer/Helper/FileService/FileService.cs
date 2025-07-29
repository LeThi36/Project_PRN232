using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Helper.FileService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(wwwRootPath))
            {
                wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            string contentPath = Path.Combine(wwwRootPath, "images");
            if (!Directory.Exists(contentPath))
            {
                Console.WriteLine($"Attempting to create directory: {contentPath}");
                Directory.CreateDirectory(contentPath);
            }

            // --- IMPORTANT CHANGE HERE ---
            string extension = Path.GetExtension(file.FileName);
            string fileName = Guid.NewGuid().ToString() + extension.ToLowerInvariant(); // Convert extension to lowercase

            string filePath = Path.Combine(contentPath, fileName);

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                Console.WriteLine($"File saved successfully to: {filePath}");
                return "/images/" + fileName; // Return the path with lowercase extension
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                return null;
            }
        }

        public void DeleteFile(string? relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return;

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(wwwRootPath, relativePath.TrimStart('/'));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
