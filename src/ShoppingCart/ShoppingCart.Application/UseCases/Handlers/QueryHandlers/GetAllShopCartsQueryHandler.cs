using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetAllShopCartsQueryHandler : IRequestHandler<GetAllShopCartsQuery, IEnumerable<ShopCartModel>>
    {
        private readonly IShopCardDbContext _context;
        public GetAllShopCartsQueryHandler(IShopCardDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShopCartModel>> Handle(GetAllShopCartsQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Carts.ToListAsync(cancellationToken);
            return res;
        }
    }
}
