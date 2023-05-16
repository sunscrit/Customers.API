using Customers.Domain.Interfaces;

namespace Customers.Domain
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }
}