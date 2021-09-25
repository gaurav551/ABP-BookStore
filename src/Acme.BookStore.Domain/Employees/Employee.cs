using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Domain.Employees
{
    public class Employee : AuditedAggregateRoot<Guid>
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string EmployeeCode { get; set; }
        public string Department { get; set; }
    }
}