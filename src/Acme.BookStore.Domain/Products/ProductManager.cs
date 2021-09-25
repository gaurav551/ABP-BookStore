// using System;
// using System.Diagnostics.CodeAnalysis;
// using System.Threading.Tasks;
// using JetBrains.Annotations;
// using Volo.Abp;
// using Volo.Abp.Domain.Services;

// namespace Acme.BookStore.Domain.Products
// {
//     public class ProductManager : DomainService
//     {
//         private readonly IProductRepository _authorRepository;

//         public ProductManager(IProductRepository authorRepository)
//         {
//             _authorRepository = authorRepository;
//         }

//         public async Task<Product> CreateAsync(
//             [NotNull] string name,
//             DateTime birthDate,
//             [CanBeNull] string shortBio = null)
//         {
//             Check.NotNullOrWhiteSpace(name, nameof(name));

//             var existingAuthor = await _authorRepository.FindByNameAsync(name);
//             if (existingAuthor != null)
//             {
//                 throw new UserFriendlyException(name);
//             }

//             return new Author(
               
//                 name,
//                 birthDate,
//                 shortBio
//             );
//         }

//         public async Task ChangeNameAsync(
//             [NotNull] Author author,
//             [NotNull] string newName)
//         {
//             Check.NotNull(author, nameof(author));
//             Check.NotNullOrWhiteSpace(newName, nameof(newName));

//             var existingAuthor = await _authorRepository.FindByNameAsync(newName);
//             if (existingAuthor != null && existingAuthor.Id != author.Id)
//             {
//                 throw new AuthorAlreadyExistsException(newName);
//             }

//             author.ChangeName(newName);
//         }
        
//     }
// }