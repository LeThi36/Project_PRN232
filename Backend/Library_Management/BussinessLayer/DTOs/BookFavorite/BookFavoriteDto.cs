using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.BookFavorite
{
    public class BookFavoriteDto
    {
        public string BookId { get; set; } = null!;
        public string BookTitle { get; set; } = null!;
        public DateTime? AddedAt { get; set; }
    }
}
