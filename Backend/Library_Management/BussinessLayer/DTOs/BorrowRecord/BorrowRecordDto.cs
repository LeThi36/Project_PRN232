using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.BorrowRecord
{
    public class BorrowRecordDto
    {
        public string BorrowId { get; set; } = null!;
        public string BookTitle { get; set; } = null!;
        public string CopyCode { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal Fine { get; set; }
    }
}
