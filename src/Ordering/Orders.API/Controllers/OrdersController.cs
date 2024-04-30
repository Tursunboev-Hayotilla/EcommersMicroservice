using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.UseCases.Commands;
using Orders.Application.UseCases.Queries;

namespace Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CrateOrder(CreateOrderCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            var res = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var res = _mediator.Send(new GetOrderByIdQuery() { Id = id });
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderCommand command)
        {
            if (command.Id == id)
            {
                return BadRequest();
            }
            var res = new UpdateOrderCommand
            {
                Id = id,
                ProductId = command.ProductId,
                UserId = command.UserId,
                ProductCount = command.ProductCount,
                OrderedDate = command.OrderedDate,
            };
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = _mediator.Send(new DeleteOrderCommand { Id = id });
            return Ok(res);
        }
    }
}
