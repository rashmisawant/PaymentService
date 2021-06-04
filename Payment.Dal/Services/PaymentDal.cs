using Payment.Dal.Interfaces;
using Payment.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Payment.Dal.Services
{
    public class PaymentDal : IPaymentDal
    {
        private readonly IPaymentDataService _paymentDataService;
        public PaymentDal(IPaymentDataService paymentDataService)
        {
            _paymentDataService = paymentDataService;
        }

        public IEnumerable<DbPayment> GetPayments(int accountId)
        {
            return _paymentDataService.Payments
                .Where(p => p.AccountId == accountId);        
        }
    }
}