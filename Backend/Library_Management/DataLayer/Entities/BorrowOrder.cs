using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class BorrowOrder : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Completed

        public decimal TotalFine { get; set; } = 0;

        public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }
}
