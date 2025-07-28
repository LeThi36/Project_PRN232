using AutoMapper;
using BussinessLayer.DTOs.BookFavorite;
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
    public class BookFavoriteService : IBookFavoriteService
    {
        private readonly ProjectPrn232Context _context;
        private readonly IMapper _mapper;

        public BookFavoriteService(ProjectPrn232Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookFavoriteDto> AddFavoriteAsync(string bookId, string userId)
        {
            // Check existence using userId and bookId, which are trusted from the server context
            var exists = await _context.BookFavorites
                .AnyAsync(f => f.BookId == bookId && f.UserId == userId);

            if (exists)
                throw new InvalidOperationException("Book is already in favorites.");

            // Create the entity directly with the provided trusted IDs
            var entity = new BookFavorite
            {
                BookId = bookId,
                UserId = userId,
                // Assuming CreatedAt, UpdatedAt are handled by EF Core or a base entity
            };
            await _context.BookFavorites.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Retrieve the result, including related Book data
            var result = await _context.BookFavorites
                .Include(f => f.Book)
                .FirstAsync(f => f.BookId == bookId && f.UserId == userId);

            return _mapper.Map<BookFavoriteDto>(result);
        }

        public async Task<IEnumerable<BookFavoriteDto>> GetFavoritesByStudentCodeAsync(string studentCode)
        {
            var favorites = await _context.BookFavorites
                .Include(f => f.Book)
                    .ThenInclude(b => b.Author)
                .Include(f => f.User)
                .Where(f => f.User.StudentCode == studentCode)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BookFavoriteDto>>(favorites);
        }
        public async Task<bool> RemoveFavoriteByStudentCodeAsync(string bookId, string studentCode)
        {
            var favorite = await _context.BookFavorites
                .Include(f => f.User)
                .FirstOrDefaultAsync(f => f.BookId == bookId && f.User.StudentCode == studentCode);

            if (favorite == null)
                return false;

            _context.BookFavorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
