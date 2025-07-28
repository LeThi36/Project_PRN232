using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.BorrowRecord
{
    public class BorrowRecordDto
    {
        public string Id { get; set; }
        public string CopyId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int ExtensionDateCount { get; set; }
        public string Status { get; set; }
        public decimal Fine { get; set; }
        public string BookTitle { get; set; }
    }
}
