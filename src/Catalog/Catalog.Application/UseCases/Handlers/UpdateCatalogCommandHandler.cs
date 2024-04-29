using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.Commands;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.Handlers
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _catalogDbContext;
        public UpdateCatalogCommandHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }
        public async Task<ResponseModel> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var res = await _catalogDbContext.Catalogs.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return new ResponseModel
                {
                    StatusCode = 404,
                    Message = $"{request.Name} => Catalog not found",
                    IsSuccess = false
                };
            }
            res.Id = request.Id;
            res.Name = request.Name; 
            res.Description = request.Description;

            _catalogDbContext.Catalogs.Update(res);
            await _catalogDbContext.SaveChangesAsync(cancellationToken);
            return new ResponseModel
            {
                StatusCode = 201,
                Message = $"{request.Name} => Catalog updated",
                IsSuccess = true
            };

        }
    }
}
