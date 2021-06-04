using Payment.BL.Interfaces;
using Payment.BL.Models;
using Payment.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Payment.Dal.Models;
using System.Threading.Tasks;

namespace Payment.BL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDal _accountDal;
        private readonly IPaymentDal _paymentDal;
       
        public PaymentService(IAccountDal accountDal, IPaymentDal paymentDal)
        {
            _accountDal = accountDal;
            _paymentDal = paymentDal;
        }

        public bool CheckAccountExists(string accountNumber)
        {
            var account = _accountDal.GetByAccountNumber(accountNumber);
            return account == null ? false : true;
        }

        public AccountDetails GetAccountBalance(string accountNumber)
        {
            var account = _accountDal.GetByAccountNumber(accountNumber);
            AccountDetails accountDetail = null;
            if (account != null)
            {
                accountDetail = new AccountDetails 
                { 
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    Status = account.Status,  
                    StatusString = account.Status ? "Open": "Closed",
                    Reason = account.Reason
                };

                var payments = GetPayments(account);
                if (payments != null && payments.Any())
                    accountDetail.Balance = payments.Sum(p => p.Amount);
            }
            return accountDetail;
        }

        public List<Models.Payment> GetPayments(string accountNumber)
        {
            var account =  _accountDal.GetByAccountNumber(accountNumber);
            return GetPayments(account);
        }
      
        private List<Models.Payment> GetPayments(DbAccount account)
        {
            List<Models.Payment> paymentList = null;
            if (account != null)
            {
                var payments = _paymentDal.GetPayments(account.Id);
                if (payments != null && payments.Any())
                {
                    paymentList = new List<Models.Payment>();
                    foreach (var pay in payments)
                        paymentList.Add(new Models.Payment
                        {
                            Id = pay.Id,
                            AccountId = pay.AccountId,
                            Amount = pay.Amount,
                            Description = pay.Description
                        });
                }
            }
            return paymentList;
        }
    }
}
