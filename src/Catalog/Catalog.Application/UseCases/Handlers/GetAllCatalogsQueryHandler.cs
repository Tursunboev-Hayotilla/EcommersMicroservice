using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.Queries;
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
    public class GetAllCatalogsQueryHandler : IRequestHandler<GetAllCatalogsQuery, List<ProductCatalog>>
    {
        private ICatalogDbContext _catalogDbContext;

        public GetAllCatalogsQueryHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }
        public async Task<List<ProductCatalog>> Handle(GetAllCatalogsQuery request, CancellationToken cancellationToken)
        {
            return await _catalogDbContext.Catalogs.ToListAsync(cancellationToken);
        }
    }
}
