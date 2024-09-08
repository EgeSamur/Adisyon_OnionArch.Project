using Adisyon_OnionArch.Project.Application.Features.Auth.Command.Register;
using Adisyon_OnionArch.Project.Application.Features.Category.Command.Create;
using Adisyon_OnionArch.Project.Application.Features.Category.Command.Delete;
using Adisyon_OnionArch.Project.Application.Features.Category.Command.Update;
using Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetAllCategoriesWithPaging;
using Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adisyon_OnionArch.Project.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        [Authorize(Roles = "admin", Policy = "AdminCanManageCategory")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById([FromQuery] GetCategoryByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesByPaging([FromQuery] GetAllCategoriesWithPagingQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
