using BussinessLayer.DTOs.Author;
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
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _authorRepository;

        public AuthorService(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // Cập nhật AddAuthor để trả về Author đã tạo
        public async Task<Author> AddAuthor(AuthorDto authorDto) // Thay đổi kiểu trả về
        {
            if (authorDto == null)
            {
                throw new ArgumentNullException(nameof(authorDto), "Author data cannot be null.");
            }

            var author = new Author
            {
                AuthorName = authorDto.AuthorName,
                // Id, CreatedAt, UpdatedAt sẽ được BaseEntity tự động khởi tạo
            };
            await _authorRepository.CreateAsync(author); // CreateAsync gọi SaveAsync bên trong, nên author.Id sẽ có giá trị
            return author; // Trả về đối tượng Author đã được tạo
        }

        // Các phương thức khác giữ nguyên
        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> GetAuthorById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "Author ID cannot be null or empty.");
            }
            var author = await _authorRepository.GetAsync(a => a.Id == id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }
            return author;
        }

        public async Task RemoveAuthor(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "Author ID cannot be null or empty.");
            }

            var authorToRemove = await _authorRepository.GetAsync(a => a.Id == id);
            if (authorToRemove == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }
            await _authorRepository.RemoveAsync(authorToRemove);
        }

        public async Task UpdateAuthor(string id, AuthorDto authorDto)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "Author ID cannot be null or empty.");
            }
            if (authorDto == null)
            {
                throw new ArgumentNullException(nameof(authorDto), "Author data cannot be null.");
            }

            var authorToUpdate = await _authorRepository.GetAsync(a => a.Id == id);
            if (authorToUpdate == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }

            authorToUpdate.AuthorName = authorDto.AuthorName;
            authorToUpdate.UpdatedAt = DateTime.Now;

            await _authorRepository.UpdateAsync(authorToUpdate);
        }
    }
}
