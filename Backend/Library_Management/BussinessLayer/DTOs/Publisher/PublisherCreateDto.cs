using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.Publisher
{
    public class PublisherCreateDto
    {
        public string PublisherName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }
    }

}
