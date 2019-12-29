﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Data.Model
{
    public class CustomerCreditInfo
    {
        public int ID { get; set; }
        public string TCKN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CreditApprovalStatus { get; set; }
        public double CreditAmount { get; set; }
    }
}
