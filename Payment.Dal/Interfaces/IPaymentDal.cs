using Payment.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Dal.Interfaces
{
    public interface IPaymentDal
    {
        IEnumerable<DbPayment> GetPayments(int accountId);
    }
}
