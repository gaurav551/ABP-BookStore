using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Application.Contracts.Products
{
    public class GetProductListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}