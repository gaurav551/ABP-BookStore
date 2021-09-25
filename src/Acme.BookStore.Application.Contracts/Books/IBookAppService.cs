using System;
using System.Threading.Tasks;
using Acme.BookStore.Application.Contracts.Books.Acme.BookStore.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books
{
    public interface IBookAppService :
        ICrudAppService< //Defines CRUD methods
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto> //Used to create/update a book
    {
        Task IncrementPriceAsync(Guid id);

    }
}
