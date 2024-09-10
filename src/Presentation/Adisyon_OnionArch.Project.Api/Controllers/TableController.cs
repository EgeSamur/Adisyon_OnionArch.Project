using Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Create;
using Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Delete;
using Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetAllTablesByPaging;
using Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetTableById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adisyon_OnionArch.Project.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "admin")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> CreateTable(CreateTableCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        [Authorize(Roles = "admin")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> DeleteTable(DeleteTableCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> GetTableById([FromQuery] GetTableByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")] // policy belirlememiz gerekiyor category oluşturma claimi var ise yapablicek
        public async Task<IActionResult> GetTablesByPaging([FromQuery] GetAllTablesByPagingQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
