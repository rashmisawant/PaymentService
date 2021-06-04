using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.BL.Interfaces;
using Payment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Payment.Service.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IPaymentService _paymentService;

        public AccountController(ILogger<AccountController> logger,
            IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpGet("{accountNumber}/balance")]
        [SwaggerResponse(200, Type = typeof(AccountResult))]
        [SwaggerResponse(400, Type = typeof(ErrorResult))]
        [SwaggerResponse(401, Type = typeof(ErrorResult))]
        [SwaggerResponse(500, Type = typeof(ErrorResult))]
        public IActionResult GetBalance(string accountNumber)
        {
            var message = ValidateAcount(accountNumber);
            
            if (!string.IsNullOrEmpty(message))
                return BadRequest(message);

            AccountResult result = null;
            var accountDet = _paymentService.GetAccountBalance(accountNumber);
            
            if (accountDet != null)
                result = new AccountResult
                {
                    AccountNumber = accountDet.AccountNumber,
                    Status = accountDet.StatusString,
                    Reason = string.IsNullOrEmpty(accountDet.Reason)? string.Empty: accountDet.Reason,
                    Balance = accountDet.Balance
                };

            return Ok(result);
        }

        [HttpGet("{accountNumber}/payments")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<PaymentResult>))]
        [SwaggerResponse(400, Type = typeof(ErrorResult))]
        [SwaggerResponse(401, Type = typeof(ErrorResult))]
        [SwaggerResponse(500, Type = typeof(ErrorResult))]
        public IActionResult GetPayments(string accountNumber)
        {
            var message = ValidateAcount(accountNumber);

            if (!string.IsNullOrEmpty(message))
                return BadRequest(message);

            IEnumerable<PaymentResult> result = null;
            var paymenttDet = _paymentService.GetPayments(accountNumber);

            if (paymenttDet != null)
                result = paymenttDet.Select(p => new PaymentResult
                {
                    Amount = p.Amount,
                    Description = p.Description
                });
               
            return Ok(result);
        }

        private string ValidateAcount(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
                return "Account Number can not be empty";

            if (!_paymentService.CheckAccountExists(accountNumber))
                return "Account Number does not exists";

            return string.Empty;
        }      
    }
}
