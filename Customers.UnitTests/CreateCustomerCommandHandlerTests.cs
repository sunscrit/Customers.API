using Moq;
using Customers.Application.CQRS.Commands;
using Customers.Application.Models;
using Customers.Domain;
using Customers.Domain.Interfaces;

namespace Customers.UnitTests
{
    [TestFixture]
    public class CreateCustomerCommandHandlerTests
    {
        private Mock<IRepository<Customer>> _mockCustomerRepository;
        private CreateCustomerCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockCustomerRepository = new Mock<IRepository<Customer>>();
            _handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsCustomerId()
        {
            // Arrange
            var request = new CreateCustomerCommand(new CreateCustomerRequest
            {
                //
            });

            _mockCustomerRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Customer>()))
                .ReturnsAsync(123); // Return a sample customer ID

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.AreEqual(123, result);
            _mockCustomerRepository.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Once);
        }
    }
}