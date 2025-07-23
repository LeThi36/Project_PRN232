using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BussinessLayer.DTOs.Category;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using DataLayer.Repositories.Abstraction;

namespace BussinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync(c => c.DeletedAt == null);
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null || category.DeletedAt != null)
                return null;

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _repo.CreateAsync(entity);
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<bool> UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _repo.GetByIdAsync(dto.Id);
            if (category == null || category.DeletedAt != null)
                return false;

            _mapper.Map(dto, category);
            await _repo.UpdateAsync(category);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null || category.DeletedAt != null)
                return false;

            category.DeletedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(category);
            return true;
        }
    }
}
