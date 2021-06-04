using Payment.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Dal.Interfaces
{
    public interface IPaymentDataService
    {
        List<DbAccount> Accounts { get; set; }
        List<DbPayment> Payments { get; set; }
    }
}