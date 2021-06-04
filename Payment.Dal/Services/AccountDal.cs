using Payment.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Payment.Dal.Models;
using System.Threading.Tasks;

namespace Payment.Dal.Services
{
    public class AccountDal : IAccountDal
    {
        private readonly IPaymentDataService _paymentDataService;
        public AccountDal(IPaymentDataService paymentDataService)
        {
            _paymentDataService = paymentDataService;
        }

        public DbAccount GetByAccountNumber(string accountNumber)
        {
            return _paymentDataService.Accounts
                    .Where(a => a.AccountNumber == accountNumber)
                    .FirstOrDefault();
        }
    }
}
