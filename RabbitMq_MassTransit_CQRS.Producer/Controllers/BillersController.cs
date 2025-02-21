using Microsoft.AspNetCore.Mvc;
using RabbitMq_MassTransit_CQRS.Producer.Models;
using RabbitMq_MassTransit_CQRS.Producer.RabbitMQ;
using RabbitMq_MassTransit_CQRS.Producer.Services;
using RabbitMq_MassTransit_CQRS.Producer.Usecases.Command;

namespace RabbitMq_MassTransit_CQRS.Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillersController : ControllerBase
    {
        private readonly IBillerService _billerService;
        private readonly IRabitMQProducer _rabitMQProducer;

        public BillersController(IBillerService billerService, IRabitMQProducer rabbitMqProd)
        {
            _billerService = billerService;
            _rabitMQProducer = rabbitMqProd;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBillerCommand command)
        {
            var result = await _billerService.AddBiller(command);
            await _rabitMQProducer.SendProductMessageAsync(result);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Biller>> Get(int id)
        {
            var result = await _billerService.GetBillerById(id);
            await _rabitMQProducer.SendProductMessageAsync(result);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
