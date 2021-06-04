using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Dal.Models
{
    public class DbAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public bool Status { get; set; }
        public string Reason { get; set; }
    }
}