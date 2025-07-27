using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Table("cart_items")]
[Index(nameof(CartId), Name = "IX_cart_items_cart_id")]
[Index(nameof(BookId), Name = "IX_cart_items_book_id")]
public class CartItem : BaseEntity
{
    [Column("cart_id")]
    public string CartId { get; set; } = null!;

    [ForeignKey(nameof(CartId))]
    public virtual Cart Cart { get; set; } = null!;

    [Column("book_id")]
    public string BookId { get; set; } = null!;

    [ForeignKey(nameof(BookId))]
    public virtual Book Book { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; }
}
