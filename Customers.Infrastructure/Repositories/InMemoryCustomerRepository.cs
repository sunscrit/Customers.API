using Customers.Domain;
using Customers.Domain.Interfaces;

namespace Customers.Infrastructure.Repositories
{
    public class InMemoryCustomerRepository : IRepository<Customer>
    {
        private readonly IDictionary<int, Customer> _customers;

        public InMemoryCustomerRepository(IDictionary<int, Customer> customers)
        {
            _customers = customers;
        }

        public Task<int> AddAsync(Customer customer)
        {
            customer.Id = _customers.Keys.Count + 1;
            _customers.Add(customer.Id, customer);
            return Task.FromResult(customer.Id);
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Customer>>(_customers.Values);
        }

        public Task<Customer?> GetByIdAsync(int id)
        {
            _customers.TryGetValue(id, out Customer result);
            return Task.FromResult(result);
        }

        public Task RemoveAsync(int id)
        {
            _customers.Remove(id);
            return Task.CompletedTask;
        }
    }
}
