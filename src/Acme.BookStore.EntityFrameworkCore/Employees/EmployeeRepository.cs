using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Acme.BookStore.Domain.Employees;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Linq;
using Microsoft.EntityFrameworkCore;

namespace Acme.BookStore.EntityFrameworkCore.Employees
{
    public class EmployeeRepository : EfCoreRepository<BookStoreDbContext, Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<string> GetEmployeeNameById(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            var emp =  await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return emp.Fullname;
        }

        public Tuple<string, string> GetEmployeeNameWithCodeById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}