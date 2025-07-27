using AutoMapper;
using BussinessLayer.DTOs.Book;
using BussinessLayer.DTOs.BookFavorite;
using BussinessLayer.DTOs.BorrowRecord;
using BussinessLayer.DTOs.Cart;
using BussinessLayer.DTOs.Category;
using BussinessLayer.DTOs.User;
using DataLayer.Entities;

namespace BussinessLayer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Book entity to BookDto
            CreateMap<Book, BookDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? src.Author.AuthorName : null))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null))
            .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher != null ? src.Publisher.PublisherName : null));

            // Map CreateBookDto to Book entity
            CreateMap<CreateBookDto, Book>();

            // Map UpdateBookDto to Book entity (for updating existing entity)
            CreateMap<UpdateBookDto, Book>();
            // Map BookFavourite
            CreateMap<BookFavoriteCreateDto, BookFavorite>()
              .ForMember(dest => dest.AddedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<BookFavorite, BookFavoriteDto>()
   .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
   .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Book.Author!.AuthorName))
   .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Book.ImageUrl));

            //Map User
            CreateMap<User, UserDto>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            //Map BorrowBook
            CreateMap<BorrowRecord, BorrowRecordDto>()
            .ForMember(dest => dest.BorrowId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Copy.Book.Title))
            .ForMember(dest => dest.CopyCode, opt => opt.MapFrom(src => src.Copy.CopyCode));

            // Map Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            //map cart
            CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Book.Author.AuthorName));
        }
    }
}