using MediatR;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.Queries
{
    public class GetShopCartByIdQuery:IRequest<ShopCartModel>
    {
        public Guid Id { get; set; }
    }
}