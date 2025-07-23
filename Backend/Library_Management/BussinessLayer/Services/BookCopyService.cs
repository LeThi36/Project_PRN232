using BussinessLayer.DTOs.BookCopy;
using BussinessLayer.DTOs.NewFolder1;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using DataLayer.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class BookCopyService : IBookCopyService
    {
        private readonly IGenericRepository<BookCopy> _copyRepo;

        public BookCopyService(IGenericRepository<BookCopy> copyRepo)
        {
            _copyRepo = copyRepo;
        }

        public async Task<BookCopy> CreateAsync(BookCopyCreateDto dto)
        {
            var copy = new BookCopy
            {
                Id = Guid.NewGuid().ToString(),
                BookId = dto.BookId,
                Status = dto.Status,
                CopyCode = Guid.NewGuid().ToString().Substring(0, 8),
                CreatedAt = DateTime.Now
            };

            await _copyRepo.CreateAsync(copy);
            return copy;
        }

        public async Task UpdateAsync(string id, BookCopyUpdateDto dto)
        {
            var copy = await _copyRepo.GetAsync(c => c.Id == id);
            if (copy == null)
                throw new KeyNotFoundException($"BookCopy with ID {id} not found.");

            copy.Status = dto.Status;
            copy.UpdatedAt = DateTime.Now;
            await _copyRepo.UpdateAsync(copy);
        }

        public async Task DeleteAsync(string id)
        {
            var copy = await _copyRepo.GetAsync(c => c.Id == id);
            if (copy == null)
                throw new KeyNotFoundException($"BookCopy with ID {id} not found.");

            await _copyRepo.RemoveAsync(copy);
        }

        public async Task<IEnumerable<BookCopy>> GetByBookIdAsync(string bookId)
        {
            return await _copyRepo.GetAllAsync(c => c.BookId == bookId);
        }
    }
}
