using MediatR;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.UseCases.Commands
{
    public class CreateOrderCommand:IRequest<ResponseModel>
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; } 
        public int ProductCount { get; set; }
        public DateTimeOffset OrderedDate { get; set; }
    }
}
