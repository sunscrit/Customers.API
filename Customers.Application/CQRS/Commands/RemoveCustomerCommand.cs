using Customers.Domain;
using Customers.Domain.Interfaces;
using MediatR;

namespace Customers.Application.CQRS.Commands
{
    public class RemoveCustomerCommand : IRequest<Unit>
    {
        public RemoveCustomerCommand(int customerId)
        {
            CustomerId = customerId;
        }
        public int CustomerId { get; set; }
    }

    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand, Unit>
    {
        private readonly IRepository<Customer> _customerRepository;

        public RemoveCustomerCommandHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.RemoveAsync(request.CustomerId);
            return Unit.Value;
        }
    }
}
