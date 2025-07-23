using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.BookCopy
{
    public class BookCopyResponseDto
    {
        public string Id { get; set; }
        public string CopyCode { get; set; }
        public string Status { get; set; }
        public string BookId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
