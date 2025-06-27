using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.BookFavorite
{
    public class BookFavoriteCreateDto
    {
        public string UserId { get; set; } = null!;
        public string BookId { get; set; } = null!;
    }
}
