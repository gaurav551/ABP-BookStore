using System;
using System.Threading.Tasks;
using Acme.BookStore.Application.Contracts.Products;
using Acme.BookStore.Authors;
using Acme.BookStore.Domain.Books;
using Acme.BookStore.Domain.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Application.Products
{
    [Authorize]
    public class ProductAppService : BookStoreAppService, IProductAppService
    {
        private readonly IProductRepository _product;
        //For Book Repository
       
        private readonly IAuthorRepository authorRepository;

        public ProductAppService(
            IProductRepository product,
           
            IAuthorRepository authorRepository
            )
        {
            _product = product;
         
            this.authorRepository = authorRepository;
        }

        public async Task<CreateUpdateProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            var product = await _product.InsertAsync(new Product(){Name=input.Name,Description=input.Description});
            var productDto  = ObjectMapper.Map<Product, CreateUpdateProductDto>(product);
            
            return productDto;
             
         
        }

        public async Task<string> DeleteAsync(int id)
        {
        
           System.Console.WriteLine("Current User is "+ CurrentUser.Id);
           return CurrentUser.Id.ToString();
        }

        public Task<ProductDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(int id, CreateUpdateProductDto input)
        {
            throw new System.NotImplementedException();
        }
    }
}