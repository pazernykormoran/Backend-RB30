using Microsoft.AspNetCore.Mvc;
using RetireBefore30.Contracts.Transactions;
using RetireBefore30.Models;
using RetireBefore30.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        [HttpGet("v1/mock_transactions")]
        public string getMockTransactions()
        {
            var mock_transactions = "\n [\n   {\n     \"id\": 1, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"long\", \n     \"price\": 1.17856,\n     \"money_state\": 1000,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-04-05 15:00:00\"\n   },   {\n     \"id\": 2, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"short\", \n     \"price\": 1.20322,\n     \"money_state\": 1024.66,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-04-19 15:00:00\"\n   },   {\n     \"id\": 3, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"long\", \n     \"price\": 1.20760,\n     \"money_state\": 1024.66,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-04-30 17:00:00\"\n   },   {\n     \"id\": 4, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"short\", \n     \"price\": 1.20322,\n     \"money_state\": 1020.17,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-05-06 09:00:00\"\n   },   {\n     \"id\": 5, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"long\", \n     \"price\": 1.21068,\n     \"money_state\": 1020.17,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-05-14 09:00:00\"\n   },   {\n     \"id\": 6, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"short\", \n     \"price\": 1.21862,\n     \"money_state\": 1012.07,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-05-21 07:00:00\"\n   },   {\n     \"id\": 7, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"long\", \n     \"price\": 1.22172,\n     \"money_state\": 1012.07,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-05-24 23:00:00\"\n   },   {\n     \"id\": 8, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"short\", \n     \"price\": 1.21951,\n     \"money_state\": 1008.93,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-06-02 07:00:00\"\n   },   {\n     \"id\": 9, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"long\", \n     \"price\": 1.18888,\n     \"money_state\": 1008.93,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-06-21 11:00:00\"\n   },   {\n     \"id\": 10, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"short\", \n     \"price\": 1.19538,\n     \"money_state\": 1015.48,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-06-25 15:00:00\"\n   },   {\n     \"id\": 11, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"long\", \n     \"price\": 1.17685,\n     \"money_state\": 1015.48,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-07-23 17:00:00\"\n   },   {\n     \"id\": 12, \n     \"strategy_instance_id\": 1,\n     \"direction\": \"short\", \n     \"price\": 1.18802,\n     \"money_state\": 1026.82,\n     \"amonut\": 1,\n     \"timestamp\": \"2021-08-03 07:00:00\"\n   }\n   ] ";

            return mock_transactions;
        }

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("v1/transactions/{transactionId}")]
        public async Task<IActionResult> getTransactionById([FromRoute]int transactionId)
        {
            var transaction = await _transactionService.getTransactionById(transactionId);

            if(transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpGet("v1/transactions")]
        public async Task<IActionResult> getTransactions()
        {
            return Ok(await _transactionService.getTransactions());
        }

        [HttpDelete("v1/transactions/{transactionId}")]
        public async Task<IActionResult> deleteTransaction([FromRoute] int transactionId)
        {
            var wasDeleted = await _transactionService.deleteTransaction(transactionId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("v1/transactions")]
        public async Task<IActionResult> createTransaction([FromBody] TransactionRequest request)
        {
            var transaction = new Transaction { 
                Direction = request.Direction,
                Price = request.Price,
                MoneyState = request.MoneyState,
                Amount = request.Amount,
                Timestamp = DateTime.Now,
                StrategyInstanceId = request.StrategyInstanceId
            };

           await _transactionService.createTransaction(transaction);
          
            return Ok(transaction);
        }

        [HttpPut("v1/transactions")]
        public async Task<IActionResult> updateTransaction(TransactionRequest request)
        {
            var transaction = new Transaction
            {
                Direction = request.Direction,
                Price = request.Price,
                MoneyState = request.MoneyState,
                Amount = request.Amount,
                Timestamp = DateTime.Now,
                StrategyInstanceId = request.StrategyInstanceId
            };

            var wasUpdated = await _transactionService.updateTransaction(transaction);

            if (!wasUpdated)
            {
                return NotFound();
            }

            return Ok(transaction);
        }


    }
}
