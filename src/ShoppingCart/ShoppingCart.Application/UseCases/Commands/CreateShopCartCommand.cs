using MediatR;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.Commands
{
    public class CreateShopCartCommand:IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
        public double Price { get; set; }
        public bool IsSold { get; set; } = false;
    }
}
