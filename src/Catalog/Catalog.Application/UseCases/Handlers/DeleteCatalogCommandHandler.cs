using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.Commands;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.Handlers
{
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, ResponseModel>

    {
        private readonly ICatalogDbContext _catalogDbContext;
        public DeleteCatalogCommandHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }
        public async Task<ResponseModel> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _catalogDbContext.Catalogs.Remove(_catalogDbContext.Catalogs.FirstOrDefault(x => x.Id == request.CatalogId)!);
                await _catalogDbContext.SaveChangesAsync(cancellationToken);
                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.CatalogId} => Catalog Deleted",
                    IsSuccess = true
                };
            }
            catch
            {
                return new ResponseModel
                {
                    StatusCode = 404,
                    Message = $"{request.CatalogId} => Catalog Not deleted",
                    IsSuccess = false
                };
            }
        }
    }
}
