using CQRS_WebApi.Usecases.Command;
using CQRS_WebApi.Usecases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBillerCommand command)
        {
            var billerId = await _mediator.Send(command);
            return Ok(billerId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Biller>> Get(int id)
        {
            var query = new GetBillerByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
