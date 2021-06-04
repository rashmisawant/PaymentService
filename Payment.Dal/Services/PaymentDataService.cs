using Payment.Dal.Interfaces;
using Payment.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Dal.Services
{
    public class PaymentDataService : IPaymentDataService
    {        
        public PaymentDataService()
        {
            Accounts = new List<DbAccount> 
            { 
                new DbAccount { Id = 1, AccountNumber = "45678" , Status = true },
                new DbAccount { Id = 2, AccountNumber = "78956",  Status = true },
                new DbAccount { Id = 3, AccountNumber = "45862" , Status = false },
            };

            Payments = new List<DbPayment>()
            {
                new DbPayment { Id = 1, AccountId = 1, Amount = 100 , Description = "Rent"},
                new DbPayment { Id = 2, AccountId = 1, Amount = -50  , Description = "Shopping"},
                new DbPayment { Id = 3, AccountId = 1, Amount = 1000 , Description = "Salary"},
                new DbPayment { Id = 4, AccountId = 2, Amount = 200 , Description = "Rent"},
                new DbPayment { Id = 5, AccountId = 2, Amount = -50 , Description = "Shopping"},
                new DbPayment { Id = 6, AccountId = 3, Amount = 300 , Description = "Salary"}                
            };
        }

        public List<DbAccount> Accounts { get; set; }
        public List<DbPayment> Payments { get; set; }
    }
}
