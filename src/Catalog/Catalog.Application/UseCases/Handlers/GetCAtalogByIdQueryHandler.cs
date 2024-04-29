using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.Queries;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.Handlers
{
    internal class GetCAtalogByIdQueryHandler : IRequestHandler<GetCatalogByIdQuery, ProductCatalog>
    {
        private readonly ICatalogDbContext _catalogDbContext;

        public GetCAtalogByIdQueryHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }
        public async Task<ProductCatalog> Handle(GetCatalogByIdQuery request, CancellationToken cancellationToken)
        {
            var res =  _catalogDbContext.Catalogs.FirstOrDefault(x => x.Id == request.Id);
            if (res == null)
            {
                throw new Exception("Not found");
            }
            return res;
        }
    }
}
