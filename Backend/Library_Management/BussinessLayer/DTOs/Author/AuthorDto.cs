using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.Author
{
    public class AuthorDto
    {
        [Required(ErrorMessage = "You must enter the author's name")]
        public string AuthorName { get; set; }
    }
}
