using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Domain.Products
{
    public class Product : AuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}