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
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, ResponseModel>
    {
        private readonly IDiscountDbContext _context;
        public DeleteDiscountCommandHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = _context.Discounts.FirstOrDefault(x => x.Id == request.Id);
            if (discount == null)
            {
                return new ResponseModel()
                {
                    Message = "Discount not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel
            {
                Message = "Discount Deleted",
                IsSuccess = true,
                StatusCode = 201
            };

        }
    }
}
