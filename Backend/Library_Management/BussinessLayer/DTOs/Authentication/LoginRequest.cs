using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTOs.Authentication
{
    public class LoginRequest
    {
        public string StudentCode { get; set; }
        public string Password { get; set; }
    }
}
