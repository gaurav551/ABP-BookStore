using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Application.Contracts.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> GetAsync(int id);

        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input);

        Task<CreateUpdateProductDto> CreateAsync(CreateUpdateProductDto input);

        Task UpdateAsync(int id, CreateUpdateProductDto input);

        Task<string> DeleteAsync(int id);
        
    }
}