using Payment.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Dal.Interfaces
{
    public interface IAccountDal
    {
        DbAccount GetByAccountNumber(string accountNumber);
    }
}
