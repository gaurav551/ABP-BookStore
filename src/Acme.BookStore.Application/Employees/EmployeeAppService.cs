using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.Application.Contracts.Employees;
using Acme.BookStore.Domain.Employees;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Application.Employees
{
    public class EmployeeAppService : BookStoreAppService , IEmployeeAppService
    {
         private readonly IEmployeeRepository employeeRepository;
        public EmployeeAppService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;

        }
        public async Task<string> CreateEmployee(CreateEmployeeDto input)
        {
            // 
             var employee = ObjectMapper.Map<CreateEmployeeDto,Employee>(input);
            var emp =  await employeeRepository.InsertAsync(employee);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return emp.Id.ToString();
        }public async Task<List<Employee>> GetEmployees(GetEmployeeListDto input)
        {
            // 
             var result = new List<Employee>();//await employeeRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
             return result;
           // await employeeRepository.InsertAsync(employee);
        }
        public async Task<string> GetById(Guid id)
        {
             return await employeeRepository.GetEmployeeNameById(id);
        }
        
    }
}