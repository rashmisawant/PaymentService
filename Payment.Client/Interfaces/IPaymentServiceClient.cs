using Payment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Client.Interfaces
{
    public interface IPaymentServiceClient
    {
        AccountResult GetBalance(string accountNumber);
        List<PaymentResult> GetPayments(string accountNumber);
    }
}
