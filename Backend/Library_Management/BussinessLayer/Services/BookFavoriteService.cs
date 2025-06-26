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

        public async Task<BookFavoriteDto> AddFavoriteAsync(BookFavoriteCreateDto dto)
        {
            var exists = await _context.BookFavorites
                .AnyAsync(f => f.BookId == dto.BookId && f.UserId == dto.UserId);

            if (exists)
                throw new InvalidOperationException("Book is already in favorites.");

            var entity = _mapper.Map<BookFavorite>(dto);
            await _context.BookFavorites.AddAsync(entity);
            await _context.SaveChangesAsync();

            var result = await _context.BookFavorites
                .Include(f => f.Book)
                .FirstAsync(f => f.BookId == dto.BookId && f.UserId == dto.UserId);

            return _mapper.Map<BookFavoriteDto>(result);
        }

        public async Task<IEnumerable<BookFavoriteDto>> GetFavoritesByUserAsync(string userId)
        {
            var favorites = await _context.BookFavorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Book)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BookFavoriteDto>>(favorites);
        }
    }
}
