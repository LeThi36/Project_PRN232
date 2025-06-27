using AutoMapper;
using BussinessLayer.DTOs.User;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using DataLayer.Enum;
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
        private readonly IMapper _mapper;

        public UserService(ProjectPrn232Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User?> GetUserByStudentCodeAsync(string studentCode)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.StudentCode == studentCode);
        }
        public async Task<IEnumerable<UserDto>> GetStudentsAsync()
        {
            var students = await _context.Users
                .Include(u => u.Role)
                .Where(u => u.Role != null && u.Role.RoleName == RoleEnum.Student)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserDto>>(students);
        }

    }
}
