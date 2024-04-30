using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Entities
{
    public class OrderModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public Guid UserId {  get; set; } = Guid.NewGuid();
        public int ProductCount { get; set; }
        public DateTimeOffset OrderedDate {  get; set; } = DateTimeOffset.UtcNow;
    }
}
