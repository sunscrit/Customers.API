using Mapster;
using Customers.Application.Models;
using Customers.Domain;
using Customers.Domain.Interfaces;
using MediatR;

namespace Customers.Application.CQRS.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto?>
    {
        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
        public int CustomerId { get; set; }
    }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
    {
        private readonly IRepository<Customer> _customerRepository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Customer? customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            return customer?.Adapt<CustomerDto>();
        }
    }
}
