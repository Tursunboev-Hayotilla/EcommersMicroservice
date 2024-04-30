using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Commands
{
    public class CreateDiscountCommand:IRequest<ResponseModel>
    {
        public Guid ProductId { get; set; }
        public string CuponCode { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
