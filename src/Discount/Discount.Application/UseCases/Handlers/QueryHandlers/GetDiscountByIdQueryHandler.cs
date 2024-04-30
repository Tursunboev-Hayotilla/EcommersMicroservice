using Discount.Application.Abstractions;
using Discount.Application.UseCases.Queries;
using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Handlers.QueryHandlers
{
    public class GetDiscountByIdQueryHandler : IRequestHandler<GetDiscountByIdQuery, ProductDiscount>
    {
        private readonly IDiscountDbContext _context;
        public GetDiscountByIdQueryHandler(IDiscountDbContext context)
        {
            _context = context;
        }
        public async Task<ProductDiscount> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var discount = _context.Discounts.FirstOrDefault(x => x.Id == request.Id);
            if (discount is not null)
            {
                return discount;
            }
            throw new Exception("Not found");

        }
    }
}   