using System;
using System.Threading.Tasks;
using Acme.BookStore.Application.Contracts.Books.Acme.BookStore.Books;
using Acme.BookStore.Domain.Books;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books
{
    public class BookAppService :
        CrudAppService<
            Book, //The Book entity
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto>, //Used to create/update a book
        IBookAppService //implement the IBookAppService
    {
        private IRepository<Book, Guid> _repository;
        public BookAppService(IRepository<Book, Guid> repository)
            : base(repository)
        {
             _repository = repository;
            // GetPolicyName = BookStorePermissions.Books.Default;
            // GetListPolicyName = BookStorePermissions.Books.Default;
            // CreatePolicyName = BookStorePermissions.Books.Create;
            // UpdatePolicyName = BookStorePermissions.Books.Edit;
            // DeletePolicyName = BookStorePermissions.Books.Delete;
        }
        //[Authorize("BookStore.Create")]

        public async Task IncrementPriceAsync(Guid id)
        {
           //Unif Of Work Implemented
           var book = await _repository.FirstOrDefaultAsync(x=>x.Id.Equals(id));
           book.Name =  "Tintin adventure";

           await _repository.InsertAsync(new Book(){Name = "New BookCOmingUp", Type = BookType.Fantastic, PublishDate=DateTime.Now,Price=1212 });

           Logger.LogInformation("Product Updated");
           //throw new UserFriendlyException("Sorry Something went wrong");
        }
       
    }
}
