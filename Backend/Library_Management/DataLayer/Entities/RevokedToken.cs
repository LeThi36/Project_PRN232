using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class RevokedToken : BaseEntity
    {
        [Required]
        public string Token { get; set; } // Chuỗi token JWT đầy đủ

        // Thời gian token sẽ hết hạn (sẽ dùng để tự động xóa khỏi DB hoặc cache)
        public DateTime ExpiryDate { get; set; }
    }
}
