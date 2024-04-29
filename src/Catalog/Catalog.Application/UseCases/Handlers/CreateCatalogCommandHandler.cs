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
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _catalogDbContext;

        public CreateCatalogCommandHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }
        public async Task<ResponseModel> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var catalog = new ProductCatalog
                {
                    Name = request.Name,
                    Description = request.Description,
                };

                await _catalogDbContext.Catalogs.AddAsync(catalog, cancellationToken);
                await _catalogDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Name} => Catalog Created",
                    IsSuccess = true
                };
            }
            return new ResponseModel
            {
                Message = "Catalog  might be  null",
                StatusCode = 400,
                IsSuccess = false

            };

        }
    }
}
