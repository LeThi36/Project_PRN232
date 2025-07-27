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
            // Đường dẫn tới thư mục wwwroot
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(wwwRootPath))
            {
                // Xử lý trường hợp wwwroot không tồn tại (hữu ích cho unit test hoặc console app)
                wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            // Tạo thư mục 'images' nếu chưa có
            string contentPath = Path.Combine(wwwRootPath, "images");
            if (!Directory.Exists(contentPath))
            {
                Directory.CreateDirectory(contentPath);
            }

            // Tạo tên file duy nhất để tránh trùng lặp
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(contentPath, fileName);

            // Lưu file vào server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Trả về đường dẫn tương đối để lưu vào DB
            return "/images/" + fileName;
        }

        public void DeleteFile(string? relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return;

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            // Chuyển đổi đường dẫn tương đối thành đường dẫn vật lý
            // Loại bỏ dấu '/' ở đầu nếu có
            string filePath = Path.Combine(wwwRootPath, relativePath.TrimStart('/'));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
