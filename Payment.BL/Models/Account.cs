using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.BL.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber{get; set; }
        public bool Status { get; set; }
        public string StatusString { get; set; }
        public string Reason { get; set; }
    }
}