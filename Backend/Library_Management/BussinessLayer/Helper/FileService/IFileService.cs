using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Helper.FileService
{
    public interface IFileService
    {
        /// <summary>
        /// Lưu file vào thư mục wwwroot/images và trả về đường dẫn tương đối.
        /// </summary>
        /// <param name="file">File ảnh được upload.</param>
        /// <returns>Đường dẫn tương đối của file đã lưu (ví dụ: /images/ten_file.jpg).</returns>
        Task<string> SaveFileAsync(IFormFile file);

        /// <summary>
        /// Xóa file dựa trên đường dẫn tương đối.
        /// </summary>
        /// <param name="relativePath">Đường dẫn tương đối của file (ví dụ: /images/ten_file.jpg).</param>
        void DeleteFile(string? relativePath);
    }
}
