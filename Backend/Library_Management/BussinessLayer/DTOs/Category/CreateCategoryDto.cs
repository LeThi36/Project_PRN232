using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; } = string.Empty;
    }
}
