using MediatR;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Application.UseCases.Commands;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.Handlers.CommandHandlers
{
    public class UpdateShopCartCommandHandler : IRequestHandler<UpdateShopCartCommand, ResponseModel>
    {
        private readonly IShopCardDbContext _context;
        public UpdateShopCartCommandHandler(IShopCardDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateShopCartCommand request, CancellationToken cancellationToken)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.Id == request.Id);
            if (cart == null)
            {
                return new ResponseModel
                {
                    Message = "Cart not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }
            cart.UserId = request.UserId;
            cart.Price = request.Price;
            cart.IsSold = request.IsSold;

            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            return new ResponseModel
            {
                Message = "Succesfully Updated",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
