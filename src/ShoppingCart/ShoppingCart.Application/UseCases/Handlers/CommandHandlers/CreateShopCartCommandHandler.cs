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
    public class CreateShopCartCommandHandler : IRequestHandler<CreateShopCartCommand, ResponseModel>
    {
        private readonly IShopCardDbContext _context;

        public CreateShopCartCommandHandler(IShopCardDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateShopCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new ShopCartModel()
            {
                UserId = request.UserId,
                Price = request.Price,
                IsSold = request.IsSold,
            };
            await _context.Carts.AddAsync(cart);  
            await _context.SaveChangesAsync();
            return new ResponseModel
            {
                Message = "Succesfully Createde",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
