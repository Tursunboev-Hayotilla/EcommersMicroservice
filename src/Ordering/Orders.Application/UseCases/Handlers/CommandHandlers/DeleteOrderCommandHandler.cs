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
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ResponseModel>
    {
        private readonly IOrdersDbContext _context;
        public DeleteOrderCommandHandler(IOrdersDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == request.Id);
            if (order == null)
            {
                return new ResponseModel()
                {
                    Message = "Order not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return new ResponseModel
            {
                Message = "Saccessfully deleted",
                IsSuccess = true,
                StatusCode = 201
            };
        }
    }
}
