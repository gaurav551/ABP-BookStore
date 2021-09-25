using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Domain.Employees
{
    public interface IEmployeeRepository : IRepository<Employee,Guid>
    {
        //Implementation Of Repository
         Task<string> GetEmployeeNameById(Guid id);
         Tuple<string,string> GetEmployeeNameWithCodeById(Guid id);
    }
}