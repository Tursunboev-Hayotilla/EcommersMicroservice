using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.Commands
{
    public class DeleteCatalogCommand:IRequest<ResponseModel>
    {
        public Guid CatalogId { get; set; }
    }
}
