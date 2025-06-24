using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly ProjectPrn232Context _context;

        public UserService(ProjectPrn232Context context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByStudentCodeAsync(string studentCode)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.StudentCode == studentCode);
        }
    }
}
