using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.Queries
{
    public class GetAllCatalogsQuery:IRequest<List<ProductCatalog>>
    {
    }
}
