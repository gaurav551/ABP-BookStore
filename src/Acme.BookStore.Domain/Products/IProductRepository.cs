using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Domain.Products
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task<Product> FindByNameAsync(string name);
        Task<List<Product>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null);
    }
}