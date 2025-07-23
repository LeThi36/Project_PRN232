using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.User
{
    public class CreateUserDto
    {
        public string Username { get; set; } = null!;
        public string StudentCode { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
        public int RoleId { get; set; }
    }
}
