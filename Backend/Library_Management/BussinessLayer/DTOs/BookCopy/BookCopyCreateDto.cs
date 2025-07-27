using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.NewFolder1
{
    public class BookCopyCreateDto
    {
        public string BookId { get; set; } = null!;
        public string Status { get; set; } = "Available";
    }
}
