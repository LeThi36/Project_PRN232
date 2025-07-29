using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.BorrowRecord
{
    public class BorrowOrderDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string? StudentCode { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public decimal TotalFine { get; set; }
        public List<BorrowRecordDto> BorrowRecords { get; set; } = new();
    }

}
