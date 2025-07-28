using BussinessLayer.DTOs.BookCopy;
using BussinessLayer.DTOs.NewFolder1;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using DataLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
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
        private readonly ProjectPrn232Context _context;

        public BookCopyService(IGenericRepository<BookCopy> copyRepo, ProjectPrn232Context context)
        {
            _copyRepo = copyRepo;
            _context = context;
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

        public async Task<PaginationResult<BookCopyResponseDto>> GetPagedAsync(
    string bookId, string? search, string? status, int page, int pageSize)
        {
            var query = _context.BookCopies
                .Where(c => c.BookId == bookId);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(c => c.CopyCode.Contains(search));

            if (!string.IsNullOrEmpty(status))
                query = query.Where(c => c.Status == status);

            int total = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new BookCopyResponseDto
                {
                    Id = c.Id,
                    CopyCode = c.CopyCode,
                    Status = c.Status,
                    BookId = c.BookId,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();

            return new PaginationResult<BookCopyResponseDto>(items, total, page, pageSize);
        }

    }
}
