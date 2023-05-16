using Mapster;
using Customers.Application.Models;
using Customers.Domain;
using Customers.Domain.Interfaces;
using MediatR;

namespace Customers.Application.CQRS.Queries
{
    public class GetAllCustomersQuery : IRequest<IList<CustomerDto>>
    {
        public GetAllCustomersQuery()
        {
        }
    }

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IList<CustomerDto>>
    {
        private readonly IRepository<Customer> _customerRepository;

        public GetAllCustomersQueryHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IList<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAllAsync();
            return customer.Adapt<IList<CustomerDto>>();
        }
    }
}
