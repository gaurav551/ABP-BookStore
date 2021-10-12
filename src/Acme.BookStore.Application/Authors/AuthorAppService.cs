using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Services;
using Volo.Abp.PermissionManagement;

namespace Acme.BookStore.Authors
{
    //[Authorize(BookStorePermissions.Authors.Default)]
    public class AuthorAppService : BookStoreAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IPermissionGrantRepository _permissionRepo;



        public AuthorAppService(
            IAuthorRepository authorRepository,
            AuthorManager authorManager,
            IPermissionManager permissionManager,
            IPermissionGrantRepository permissionRepo)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
             _permissionManager = permissionManager;
             _permissionRepo = permissionRepo;
        }

        //[Authorize(BookStorePermissions.Authors.Create)]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            _authorRepository.Where(x=>x.Id.Equals("aefaefa"));
            // var author = await _authorManager.CreateAsync(
            //     input.Name,
            //     input.BirthDate,
            //     input.ShortBio
            // );
            System.Console.WriteLine("INput Birth " + input.DateOfBirth);
            System.Console.WriteLine("Input name is " + input.Name);
            var author = ObjectMapper.Map<CreateAuthorDto,Author>(input);
            System.Console.WriteLine("BirhtDate is " + author.BirthDate);



            await _authorRepository.InsertAsync(author);
            //Saving changes to be able to get the auto increment id

            await UnitOfWorkManager.Current.SaveChangesAsync();
             var id = author.Id;


            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task DeleteAsync(Guid id)
        {
           
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }
        [Authorize(Roles ="Admin")]
        public async Task<object> GetListAsync(GetAuthorListDto input)
        {  
           // await _permissionManager.SetForRoleAsync("Admin",BookStorePermissions.Authors.Default,true);
            if(await AuthorizationService.IsGrantedAsync(BookStorePermissions.Authors.Default))
            {
                return "GRANTED";
            }
          
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }

            var authors = await _authorRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _authorRepository.CountAsync()
                : await _authorRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(
                totalCount,
                ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors)
            );
        }
     

        [Authorize(BookStorePermissions.Authors.Edit)]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id);

            if (author.Name != input.Name)
            {
                await _authorManager.ChangeNameAsync(author, input.Name);
            }
           

            author.BirthDate = input.BirthDate;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);
        }

        //...SERVICE METHODS WILL COME HERE...
    }
}
