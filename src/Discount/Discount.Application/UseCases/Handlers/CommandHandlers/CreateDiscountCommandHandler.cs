using Discount.Application.Abstractions;
using Discount.Application.UseCases.Commands;
using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.Handlers.CommandHandlers
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, ResponseModel>
    {
        private readonly IDiscountDbContext _context;
        public CreateDiscountCommandHandler(IDiscountDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = new ProductDiscount()
            {
                ProductId = request.ProductId,
                CuponCode = request.CuponCode,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };
            await _context.Discounts.AddAsync(discount,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

             return new ResponseModel 
            {
                Message = "Succesfully created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
