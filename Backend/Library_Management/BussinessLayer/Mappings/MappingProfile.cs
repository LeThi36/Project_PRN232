using AutoMapper;
using BussinessLayer.DTOs.Book;
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
        }
    }
}