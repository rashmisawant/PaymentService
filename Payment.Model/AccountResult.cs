using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Model
{
    public class AccountResult
    {
        public string AccountNumber { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public double Balance { get; set; }
    }
}
