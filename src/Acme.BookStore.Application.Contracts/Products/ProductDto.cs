using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Application.Contracts.Products
{
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}