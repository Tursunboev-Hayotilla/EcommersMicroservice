using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.UseCases.Commands;
using ShoppingCart.Application.UseCases.Queries;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCartsController : Controller
    {
        private readonly IMediator _mediart;

        public ShopCartsController(IMediator mediator)
        {
            _mediart = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewShopCart(CreateShopCartCommand command)
        {
            var res = await _mediart.Send(command);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShopCarts()
        {
            var res = await _mediart.Send(new GetAllShopCartsQuery());
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShopCartByid(Guid id)
        {
            var res = await _mediart.Send(new GetShopCartByIdQuery() { Id = id });
            return Ok(res);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShopCart(Guid id, UpdateShopCartCommand command)
        {
            if (command.Id == id)
            {
                return BadRequest();
            }
            var res = new UpdateShopCartCommand()
            {
                Id = id,
                UserId = command.UserId,
                Price = command.Price,
                IsSold = command.IsSold,
            };
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = _mediart.Send(new DeleteShopCartCommand() { Id = id });
            return Ok(res);
        }
    }
}
