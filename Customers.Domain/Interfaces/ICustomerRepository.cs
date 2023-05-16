namespace Customers.Domain.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(Customer customer);
        Task RemoveAsync(int id);
    }
}
