using Adisyon_OnionArch.Project.Application.Features.Category.Command.Create;
using Adisyon_OnionArch.Project.Application.Features.Product.Command.Create;
using Adisyon_OnionArch.Project.Application.Features.Product.Command.Delete;
using Adisyon_OnionArch.Project.Application.Features.Product.Command.Update;
using Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adisyon_OnionArch.Project.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "admin")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        //[Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Authorize(Roles = "admin")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        //[Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete]
        [Authorize(Roles = "admin")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
                                     //[Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        //[Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
