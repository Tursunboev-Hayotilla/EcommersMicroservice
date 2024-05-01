using MediatR;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Application.UseCases.Queries;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.Handlers.QueryHandlers
{
    public class GetShopCartsByIdQueryHandler : IRequestHandler<GetShopCartByIdQuery, ShopCartModel>
    {
        private readonly IShopCardDbContext _context;
        public GetShopCartsByIdQueryHandler(IShopCardDbContext context)
        {
            _context = context;
        }
        public async Task<ShopCartModel> Handle(GetShopCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.Id == request.Id);
            if (cart == null)
            {
                throw new Exception("Cart not found");
            }
            return cart;
        }
    }
}
