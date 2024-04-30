using MediatR;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.UseCases.Commands
{
    public class UpdateOrderCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; } 
        public Guid ProductId { get; set; } 
        public Guid UserId { get; set; } 
        public int ProductCount { get; set; }
        public DateTimeOffset OrderedDate { get; set; }
    }
}
