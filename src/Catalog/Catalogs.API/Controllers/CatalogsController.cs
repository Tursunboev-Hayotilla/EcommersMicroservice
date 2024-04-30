using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.Commands;
using Catalog.Application.UseCases.Queries;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalog(CreateCatalogCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductCatalog>>> GetAllCatalogs()
        {
            var result = await _mediator.Send(new GetAllCatalogsQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCatalog>> GetCatalogById(Guid id)
        {
            var result = await _mediator.Send(new GetCatalogByIdQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatalog(Guid id, UpdateCatalogCommand command)
        {
            if (id == command.Id)
            {
                return BadRequest("Not found");
            }
            var updateCatalog = _mediator.Send(new UpdateCatalogCommand { Id = command.Id, Name = command.Name, Description = command.Description });
            return Ok(updateCatalog);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var res =  await _mediator.Send(new DeleteCatalogCommand() { CatalogId = id });
            if(res == null)
            {
                return NotFound();
            }
            return Ok("Deleted");
        }
    }
}
