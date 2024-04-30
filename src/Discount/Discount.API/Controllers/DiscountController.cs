using Discount.Application.UseCases.Commands;
using Discount.Application.UseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDiscountAsync(CreateDiscountCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscountsAsync()
        {
            var res = await _mediator.Send(new GetAllDiscountsQuery());
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDiscountById(Guid id)
        {
            var res = await _mediator.Send(new GetDiscountByIdQuery() { Id = id });
            return Ok(res);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDiscount(Guid id, UpdateDiscountCommand command)
        {
            if (command.Id != id)
            {
                var res = await _mediator.Send(new UpdateDiscountCommand
                {
                    Id = id,
                    ProductId = command.ProductId,
                    CuponCode = command.CuponCode,
                    StartDate = command.StartDate,
                    EndDate = command.EndDate,
                });
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDiscount(Guid id)
        {

            var res = await _mediator.Send(new DeleteDiscountCommand() { Id = id });
            return Ok(res);

        }
    }
}
