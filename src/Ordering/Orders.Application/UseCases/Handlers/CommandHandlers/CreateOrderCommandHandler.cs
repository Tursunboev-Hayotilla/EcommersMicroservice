using MediatR;
using Orders.Application.Abstractions;
using Orders.Application.UseCases.Commands;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.UseCases.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseModel>
    {
        private readonly IOrdersDbContext _context;
        public CreateOrderCommandHandler(IOrdersDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderModel
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
                ProductCount = request.ProductCount,
                OrderedDate = request.OrderedDate,
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Succesfully Created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
