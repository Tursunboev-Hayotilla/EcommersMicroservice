using MediatR;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.Commands
{
    public class UpdateShopCartCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; } = Guid.NewGuid();
        public double Price { get; set; }
        public bool IsSold { get; set; } = false;
    }
}
