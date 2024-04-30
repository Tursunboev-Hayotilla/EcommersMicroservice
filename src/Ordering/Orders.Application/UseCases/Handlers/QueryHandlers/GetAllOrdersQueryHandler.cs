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
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderModel>>
    {
        private readonly IOrdersDbContext _context;

        public GetAllOrdersQueryHandler(IOrdersDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _context.Orders.ToList();
            return orders;
        }
    }
}
