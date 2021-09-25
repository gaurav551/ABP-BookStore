using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Application.Contracts.Employees
{
    public class GetEmployeeListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}