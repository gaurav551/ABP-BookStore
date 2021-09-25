using Acme.BookStore.Application.Contracts.Books.Acme.BookStore.Books;
using Acme.BookStore.Application.Contracts.Employees;
using Acme.BookStore.Application.Contracts.Products;
using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Domain.Books;
using Acme.BookStore.Domain.Employees;
using Acme.BookStore.Domain.Products;
using AutoMapper;

namespace Acme.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Product, CreateUpdateBookDto>();
            CreateMap<CreateAuthorDto, Author>().ForMember(dest => dest.BirthDate, source=> source.MapFrom(source=> source.DateOfBirth) );
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();


        }
    }
}