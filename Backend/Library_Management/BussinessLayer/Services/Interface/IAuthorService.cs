using BussinessLayer.DTOs.Author;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthor();
        Task<Author> GetAuthorById(string id);
        Task<Author> AddAuthor(AuthorDto authorDto);
        Task UpdateAuthor(string id, AuthorDto authorDto);
        Task RemoveAuthor(string id);
    }
}
