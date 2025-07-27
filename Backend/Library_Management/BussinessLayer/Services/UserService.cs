using AutoMapper;
using BussinessLayer.DTOs.User;
using BussinessLayer.Helper.FileService;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using DataLayer.Enum;
using DataLayer.Repositories.Abstraction;
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
        private readonly IGenericRepository<User> _userRepository; // Sử dụng Generic Repository
        private readonly IFileService _fileService; // Inject File Service

        public UserService(ProjectPrn232Context context, IMapper mapper, IGenericRepository<User> userRepository, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public async Task<User?> GetUserByStudentCodeAsync(string studentCode)
        {
            return await _context.Users
                                 .Include(u => u.Role)
                                 .SingleOrDefaultAsync(u => u.StudentCode == studentCode);
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
            user.CreatedAt = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(dto.Id);
            if (user == null || user.DeletedAt != null) return false;

            _mapper.Map(dto, user);
            user.UpdatedAt = DateTime.Now;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto?> UpdateProfileAsync(string userId, UpdateProfileDto updateDto)
        {
            var user = await _userRepository.GetAsync(u => u.Id == userId);
            if (user == null)
            {
                return null; // Không tìm thấy user
            }

            // Xử lý upload ảnh
            if (updateDto.ImageFile != null && updateDto.ImageFile.Length > 0)
            {
                // Xóa ảnh cũ nếu có
                _fileService.DeleteFile(user.ImageUrl);

                // Lưu ảnh mới và lấy đường dẫn
                var newImageUrl = await _fileService.SaveFileAsync(updateDto.ImageFile);
                user.ImageUrl = newImageUrl;
            }

            // Cập nhật các trường thông tin khác
            user.PhoneNumber = updateDto.PhoneNumber ?? user.PhoneNumber;
            user.Address = updateDto.Address ?? user.Address;
            user.DateOfBirth = updateDto.DateOfBirth ?? user.DateOfBirth;

            if (!string.IsNullOrEmpty(updateDto.Gender) && Enum.TryParse<Gender>(updateDto.Gender, true, out var gender))
            {
                user.Gender = gender;
            }

            user.UpdatedAt = DateTime.Now;

            await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserDto>(user);
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
