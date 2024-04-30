using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Commands
{
    public class DeleteDiscountCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
