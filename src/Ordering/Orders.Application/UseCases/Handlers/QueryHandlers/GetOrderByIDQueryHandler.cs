using MediatR;
using Orders.Application.Abstractions;
using Orders.Application.UseCases.Queries;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.UseCases.Handlers.QueryHandlers
{
    public class GetOrderByIDQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderModel>
    {
        private readonly IOrdersDbContext _context;
        public GetOrderByIDQueryHandler(IOrdersDbContext context)
        {
            _context = context;
        }
        public async Task<OrderModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order =   _context.Orders.FirstOrDefault(o => o.Id == request.Id);
            if (order != null)
            {
                return order;
            }
            throw new Exception("Order not found");
        }
    }
}
