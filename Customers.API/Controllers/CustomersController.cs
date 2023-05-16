using Customers.Application.CQRS.Commands;
using Customers.Application.CQRS.Queries;
using Customers.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomersController> _logger;
        public CustomersController(IMediator mediator, ILogger<CustomersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<IList<CustomerDto>>> GetAll()
        {
            _logger.LogInformation("Get all cutomers");
            return (await _mediator.Send(new GetAllCustomersQuery())).ToList();
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto?>> Get(int id)
        {
            _logger.LogInformation($"Get customer by id:{id}");
            var queryResult = await _mediator.Send(new GetCustomerByIdQuery(id));
            return queryResult == null ? NotFound("Customer not found") : Ok(queryResult);
        }

        // POST api/<customers>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateCustomerRequest customer)
        {
            _logger.LogInformation($"Create customer {JsonSerializer.Serialize(customer)}");
            return await _mediator.Send(new CreateCustomerCommand(customer));
        }

        // DELETE api/<CustomersController>/{id}
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Delete customer with id:{id}");
            await _mediator.Send(new RemoveCustomerCommand(id));
        }
    }
}
