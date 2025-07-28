using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.Cart
{
    public class CartItemDto
    {
        public string BookId { get; set; } = null!;
        public string BookTitle { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
