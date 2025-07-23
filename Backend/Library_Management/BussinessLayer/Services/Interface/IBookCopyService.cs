using BussinessLayer.DTOs.BookCopy;
using BussinessLayer.DTOs.NewFolder1;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IBookCopyService
    {
        Task<BookCopy> CreateAsync(BookCopyCreateDto dto);
        Task UpdateAsync(string id, BookCopyUpdateDto dto);
        Task DeleteAsync(string id);
        Task<IEnumerable<BookCopy>> GetByBookIdAsync(string bookId);
    }
}
