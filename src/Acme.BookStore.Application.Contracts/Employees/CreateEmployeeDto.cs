namespace Acme.BookStore.Application.Contracts.Employees
{
    public class CreateEmployeeDto
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string EmployeeCode { get; set; }
        public string Department { get; set; }
    }
}