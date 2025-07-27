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
        public async Task<UserDto?> CreateUserAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Id = Guid.NewGuid().ToString();
            user.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(dto.Id);
            if (user == null || user.DeletedAt != null) return false;

            _mapper.Map(dto, user);
            user.UpdatedAt = DateTime.UtcNow;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ToggleBanStatusAsync(string userId, bool ban)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;


            //check if deleted or not
            if (ban)
            {
                if (user.DeletedAt != null) return false;
                user.DeletedAt = DateTime.UtcNow;
            }
            else
            {
                if (user.DeletedAt == null) return false;
                user.DeletedAt = null;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
