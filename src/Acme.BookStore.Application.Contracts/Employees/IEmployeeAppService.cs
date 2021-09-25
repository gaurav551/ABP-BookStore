using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Application.Contracts.Employees
{
    public interface IEmployeeAppService : IApplicationService
    {
            Task<string> CreateEmployee(CreateEmployeeDto input);
            //Task<PagedResultDto<Employee>> Get();

    }
}