using BussinessLayer.DTOs.Book;
using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IBookService
    {
        Task<PaginationResult<BookDto>> GetAllBooksAsync(BookFilterAndSearchRequestDto request);
        Task<BookDto?> GetBookByIdAsync(string id);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<BookDto> UpdateBookAsync(UpdateBookDto updateBookDto);
        Task<bool> DeleteBookAsync(string id);
    }
}