using Payment.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.BL.Interfaces
{
    public interface IPaymentService
    {
        bool CheckAccountExists(string accountNumber);
        AccountDetails GetAccountBalance(string accountNumber);
        List<Models.Payment> GetPayments(string accountNumber);
    }
}