using BussinessLayer.DTOs.BookFavorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IBookFavoriteService
    {
        Task<BookFavoriteDto> AddFavoriteAsync(BookFavoriteCreateDto dto);
        Task<IEnumerable<BookFavoriteDto>> GetFavoritesByStudentCodeAsync(string studentCode);
        Task<bool> RemoveFavoriteByStudentCodeAsync(string bookId, string studentCode);
    }
}
