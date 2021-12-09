using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RetireBefore30.Controllers;
using RetireBefore30.Services;
using Xunit;

namespace RetireBefore30.UnitTests.Controllers
{
    public class TransactionControllerTests
    {
        private Mock<ITransactionService> transactionServiceMock;

        public TransactionControllerTests()
        {
            transactionServiceMock = new Mock<ITransactionService>();
        }

        [Fact]
        public async void GetTransactionByIdShouldReturnCorrectTransaction()
        {
            var transactions = new List<Models.Transaction>
            {
                new Models.Transaction 
                {
                    Direction = 1,
                    Price = 11.11,
                    MoneyState = 123.33,
                    Amount = 1,
                    Timestamp = System.DateTime.Now
                },
                new Models.Transaction
                {
                    Direction = 1,
                    Price = 11.11,
                    MoneyState = 123.33,
                    Amount = 1,
                    Timestamp = System.DateTime.Now
                }
            };

            transactionServiceMock
                .Setup(x => x.getTransactionById(It.IsAny<int>()))
                .ReturnsAsync((int x) => transactions.FirstOrDefault(y => y.Id == x));

            var result = await CreateController().getTransactionById(1);

            var response = Assert.IsType<OkObjectResult>(result);
            var transaction = Assert.IsAssignableFrom<Models.Transaction>(response.Value);
            Assert.Equal(transaction, transactions[0]);
        }

        private TransactionController CreateController() 
        {
            return new TransactionController(transactionServiceMock.Object);
        }
    }
}
