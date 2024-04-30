using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ResponseModel>
    {
        private readonly IOrdersDbContext _context;
        public UpdateOrderCommandHandler(IOrdersDbContext context) 
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (order == null)
            {
                return new ResponseModel
                {
                    Message = "Order not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }
            order.ProductId = request.ProductId;
            order.UserId = request.UserId;
            order.ProductCount = request.ProductCount;
            order.OrderedDate = request.OrderedDate;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return new ResponseModel
            {
                Message = "Succesfully updated",
                IsSuccess = true,
                StatusCode = 201
            };
        }
    }
}
