using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Application.Contracts.Products
{
    public class CreateUpdateProductDto 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
       
    }
}