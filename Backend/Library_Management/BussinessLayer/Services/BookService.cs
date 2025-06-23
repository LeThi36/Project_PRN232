using AutoMapper;
using BussinessLayer.DTOs.Book;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using DataLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IPaginationRepository<Book> _bookPaginationRepository;
        private readonly IGenericRepository<Author> _authorRepository; // Để lấy tên tác giả
        private readonly IGenericRepository<Category> _categoryRepository; // Để lấy tên danh mục
        private readonly IGenericRepository<Publisher> _publisherRepository; // Để lấy tên nhà xuất bản
        private readonly IMapper _mapper; // Sẽ cần AutoMapper để ánh xạ giữa Entity và DTO

        public BookService(
            IGenericRepository<Book> bookRepository,
            IPaginationRepository<Book> bookPaginationRepository,
            IGenericRepository<Author> authorRepository,
            IGenericRepository<Category> categoryRepository,
            IGenericRepository<Publisher> publisherRepository,
            IMapper mapper) // Thêm IMapper vào constructor
        {
            _bookRepository = bookRepository;
            _bookPaginationRepository = bookPaginationRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BookDto>> GetAllBooksAsync(BookFilterAndSearchRequestDto request)
        {
            Expression<Func<Book, bool>>? filter = null;
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                // Tìm kiếm theo Title, Description, AuthorName, CategoryName, PublisherName
                // Cần load Author, Category, Publisher để lọc
                filter = b =>
                    (b.Title.Contains(request.SearchTerm) ||
                    (b.Description != null && b.Description.Contains(request.SearchTerm)) ||
                    (b.Author != null && b.Author.AuthorName.Contains(request.SearchTerm)) ||
                    (b.Category != null && b.Category.CategoryName.Contains(request.SearchTerm)) ||
                    (b.Publisher != null && b.Publisher.PublisherName.Contains(request.SearchTerm))) &&
                    (!request.IncludeDeleted ? b.DeletedAt == null : true); // Lọc sách chưa xóa mềm nếu không yêu cầu
            }
            else
            {
                // Lọc theo CategoryId, AuthorId, PublisherId nếu có
                filter = b =>
                    (string.IsNullOrEmpty(request.CategoryId) || b.CategoryId == request.CategoryId) &&
                    (string.IsNullOrEmpty(request.AuthorId) || b.AuthorId == request.AuthorId) &&
                    (string.IsNullOrEmpty(request.PublisherId) || b.PublisherId == request.PublisherId) &&
                    (!request.IncludeDeleted ? b.DeletedAt == null : true); // Lọc sách chưa xóa mềm nếu không yêu cầu
            }


            // Bao gồm các mối quan hệ Author, Category, Publisher để có thể lấy tên hiển thị trong DTO
            Func<IQueryable<Book>, IQueryable<Book>> includes = query =>
                query.Include(b => b.Author)
                     .Include(b => b.Category)
                     .Include(b => b.Publisher);

            var paginationResult = await _bookPaginationRepository.GetPaginatedAsync(
                request.PageNumber,
                request.PageSize,
                filter,
                includes
            );

            // Ánh xạ từ Book entity sang BookDto
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(paginationResult.Data);

            // Cập nhật tên từ các entities liên quan nếu AutoMapper chưa xử lý hoặc cần tùy chỉnh
            foreach (var bookDto in bookDtos)
            {
                var originalBook = paginationResult.Data.FirstOrDefault(b => b.Id == bookDto.Id);
                if (originalBook != null)
                {
                    bookDto.AuthorName = originalBook.Author?.AuthorName;
                    bookDto.CategoryName = originalBook.Category?.CategoryName;
                    bookDto.PublisherName = originalBook.Publisher?.PublisherName;
                }
            }


            return new PaginationResult<BookDto>(
                bookDtos,
                paginationResult.TotalCount,
                paginationResult.PageNumber,
                paginationResult.PageSize
            );
        }

        public async Task<BookDto?> GetBookByIdAsync(string id)
        {
            // Bao gồm các mối quan hệ Author, Category, Publisher
            Func<IQueryable<Book>, IQueryable<Book>> includes = query =>
                query.Include(b => b.Author)
                     .Include(b => b.Category)
                     .Include(b => b.Publisher);

            var book = await _bookRepository.GetAsync(b => b.Id == id && b.DeletedAt == null, includes);
            if (book == null)
            {
                return null;
            }

            var bookDto = _mapper.Map<BookDto>(book);
            // Gán tên từ các entity liên quan
            bookDto.AuthorName = book.Author?.AuthorName;
            bookDto.CategoryName = book.Category?.CategoryName;
            bookDto.PublisherName = book.Publisher?.PublisherName;

            return bookDto;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            // Kiểm tra xem AuthorId, CategoryId, PublisherId có tồn tại không (tùy chọn)
            if (!string.IsNullOrEmpty(createBookDto.AuthorId))
            {
                var author = await _authorRepository.GetAsync(a => a.Id == createBookDto.AuthorId && a.DeletedAt == null);
                if (author == null)
                {
                    throw new ArgumentException("Author not found.");
                }
            }

            if (!string.IsNullOrEmpty(createBookDto.CategoryId))
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == createBookDto.CategoryId && c.DeletedAt == null);
                if (category == null)
                {
                    throw new ArgumentException("Category not found.");
                }
            }

            if (!string.IsNullOrEmpty(createBookDto.PublisherId))
            {
                var publisher = await _publisherRepository.GetAsync(p => p.Id == createBookDto.PublisherId && p.DeletedAt == null);
                if (publisher == null)
                {
                    throw new ArgumentException("Publisher not found.");
                }
            }

            var book = _mapper.Map<Book>(createBookDto);
            book.Id = Guid.NewGuid().ToString(); // Đảm bảo Id được tạo mới
            book.CreatedAt = DateTime.Now;
            book.UpdatedAt = DateTime.Now;

            await _bookRepository.CreateAsync(book);

            // Sau khi tạo thành công, lấy lại thông tin đầy đủ để trả về DTO
            var createdBook = await _bookRepository.GetAsync(b => b.Id == book.Id, query => query.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher));
            var bookDto = _mapper.Map<BookDto>(createdBook);
            bookDto.AuthorName = createdBook.Author?.AuthorName;
            bookDto.CategoryName = createdBook.Category?.CategoryName;
            bookDto.PublisherName = createdBook.Publisher?.PublisherName;

            return bookDto;
        }

        public async Task<BookDto> UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var existingBook = await _bookRepository.GetAsync(b => b.Id == updateBookDto.Id && b.DeletedAt == null);
            if (existingBook == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            // Kiểm tra các Id liên quan (tùy chọn)
            if (!string.IsNullOrEmpty(updateBookDto.AuthorId) && updateBookDto.AuthorId != existingBook.AuthorId)
            {
                var author = await _authorRepository.GetAsync(a => a.Id == updateBookDto.AuthorId && a.DeletedAt == null);
                if (author == null)
                {
                    throw new ArgumentException("Author not found.");
                }
            }

            if (!string.IsNullOrEmpty(updateBookDto.CategoryId) && updateBookDto.CategoryId != existingBook.CategoryId)
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == updateBookDto.CategoryId && c.DeletedAt == null);
                if (category == null)
                {
                    throw new ArgumentException("Category not found.");
                }
            }

            if (!string.IsNullOrEmpty(updateBookDto.PublisherId) && updateBookDto.PublisherId != existingBook.PublisherId)
            {
                var publisher = await _publisherRepository.GetAsync(p => p.Id == updateBookDto.PublisherId && p.DeletedAt == null);
                if (publisher == null)
                {
                    throw new ArgumentException("Publisher not found.");
                }
            }

            // Ánh xạ các trường từ DTO sang entity hiện có
            _mapper.Map(updateBookDto, existingBook);
            existingBook.UpdatedAt = DateTime.Now;

            await _bookRepository.UpdateAsync(existingBook);

            // Sau khi cập nhật, lấy lại thông tin đầy đủ để trả về DTO
            var updatedBook = await _bookRepository.GetAsync(b => b.Id == existingBook.Id, query => query.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher));
            var bookDto = _mapper.Map<BookDto>(updatedBook);
            bookDto.AuthorName = updatedBook.Author?.AuthorName;
            bookDto.CategoryName = updatedBook.Category?.CategoryName;
            bookDto.PublisherName = updatedBook.Publisher?.PublisherName;

            return bookDto;
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            var bookToDelete = await _bookRepository.GetAsync(b => b.Id == id && b.DeletedAt == null);
            if (bookToDelete == null)
            {
                return false; // Không tìm thấy sách hoặc đã bị xóa
            }

            // Thực hiện soft delete
            bookToDelete.DeletedAt = DateTime.Now;
            bookToDelete.UpdatedAt = DateTime.Now;

            try
            {
                await _bookRepository.UpdateAsync(bookToDelete);
                return true;
            }
            catch
            {
                return false; // Xử lý lỗi nếu không cập nhật được
            }
        }
    }
}