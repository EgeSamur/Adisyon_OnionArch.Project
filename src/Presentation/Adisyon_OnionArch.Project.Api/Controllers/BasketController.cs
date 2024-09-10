using Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.AddItemsToBaskets;
using Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.AddMoreThanOneItemsToBaskets;
using Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.PayForBasket;
using Adisyon_OnionArch.Project.Application.Features.Category.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adisyon_OnionArch.Project.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> AddItemToBasket(AddItemsToBasketCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        //[Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> AddMoreThanOneItemsToBasket(AddMoreThanOneItemsToBasketsCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        //[Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> PayForBasket(PayForBasketCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
