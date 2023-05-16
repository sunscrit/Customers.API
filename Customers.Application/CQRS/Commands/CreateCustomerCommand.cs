using Mapster;
using Customers.Application.Models;
using Customers.Domain;
using Customers.Domain.Interfaces;
using MediatR;

namespace Customers.Application.CQRS.Commands
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public CreateCustomerCommand(CreateCustomerRequest customer)
        {
            Customer = customer;
        }
        public CreateCustomerRequest Customer { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IRepository<Customer> _customerRepository;

        public CreateCustomerCommandHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToAdd = request.Customer.Adapt<Customer>();
            return await _customerRepository.AddAsync(customerToAdd);
        }
    }
}
