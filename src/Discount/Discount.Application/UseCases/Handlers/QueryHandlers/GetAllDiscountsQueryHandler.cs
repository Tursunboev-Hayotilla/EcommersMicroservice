using Discount.Application.Abstractions;
using Discount.Application.UseCases.Queries;
using Discount.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Handlers.QueryHandlers
{
    public class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQuery, IEnumerable<ProductDiscount>>
    {
        private readonly IDiscountDbContext _context;
        public GetAllDiscountsQueryHandler(IDiscountDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductDiscount>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var discounts = await _context.Discounts.ToListAsync(cancellationToken);

            return discounts;
        }
    }
}
