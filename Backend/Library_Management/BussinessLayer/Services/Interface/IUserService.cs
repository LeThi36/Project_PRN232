using BussinessLayer.DTOs.User;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IUserService
    {

        Task<User?> GetUserByStudentCodeAsync(string studentCode);
        Task<IEnumerable<UserDto>> GetStudentsAsync();
        Task<UserDto?> UpdateProfileAsync(string userId, UpdateProfileDto updateDto);
        Task<UserDto?> CreateUserAsync(CreateUserDto dto);
        Task<bool> UpdateUserAsync(UpdateUserDto dto);
        Task<bool> ToggleBanStatusAsync(string userId, bool ban);
    }
}
