using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Table("borrow_orders")]
[Index(nameof(UserId), Name = "IX_borrow_orders_user_id")]
public class BorrowOrder : BaseEntity
{
    [Column("user_id")]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [Column("borrow_date")]
    public DateTime BorrowDate { get; set; }

    [Column("due_date")]
    public DateTime DueDate { get; set; }

    [Column("status")]
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Completed

    [Column("total_fine")]
    public decimal TotalFine { get; set; } = 0;

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
}
