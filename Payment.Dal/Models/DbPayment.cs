﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Dal.Models
{
    public class DbPayment
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}