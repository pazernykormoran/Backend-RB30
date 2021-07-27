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
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("api/v1/transactions/{transactionId}")]
        public async Task<IActionResult> getTransactionById([FromRoute]int transactionId)
        {
            var transaction = await _transactionService.getTransactionById(transactionId);

            if(transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpGet("api/v1/transactions")]
        public async Task<IActionResult> getTransactions()
        {
            return Ok(await _transactionService.getTransactions());
        }

        [HttpDelete("api/v1/transactions/{transactionId}")]
        public async Task<IActionResult> deleteTransaction([FromRoute] int transactionId)
        {
            var wasDeleted = await _transactionService.deleteTransaction(transactionId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("api/v1/transactions")]
        public async Task<IActionResult> createTransaction([FromBody] TransactionRequest request)
        {
            var transaction = new Transaction { Test = request.Test };

           await _transactionService.createTransaction(transaction);
          
            return Ok(transaction);
        }

        [HttpPut("api/v1/transactions/{transactionId}")]
        public async Task<IActionResult> updateTransaction([FromRoute] int transactionId, [FromBody] TransactionRequest request)
        {
            var transaction = new Transaction { Id = transactionId, Test = request.Test };

            var wasUpdated = await _transactionService.updateTransaction(transaction);

            if (!wasUpdated)
            {
                return NotFound();
            }

            return Ok(transaction);
        }


    }
}
