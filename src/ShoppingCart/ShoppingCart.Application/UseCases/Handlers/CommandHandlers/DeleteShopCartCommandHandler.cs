using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Application.UseCases.Commands;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.Handlers.CommandHandlers
{
    public class DeleteShopCartCommandHandler : IRequestHandler<DeleteShopCartCommand, ResponseModel>
    {
        private readonly IShopCardDbContext _context;
        public DeleteShopCartCommandHandler(IShopCardDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteShopCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (cart == null)
            {
                return new ResponseModel
                {
                    Message = "Cart not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel
            {
                Message = "Succesfully Deleted",
                StatusCode = 201,
                IsSuccess = true
            };
        }

    }
}
