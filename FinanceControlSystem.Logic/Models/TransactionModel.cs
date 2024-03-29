﻿using FinanceControlSystem.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControlSystem.Logic.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date {  get; set; }
        public int ClientFinanceId { get; set; }
        public int CategoryId { get; set; }
        public TransactionType Type { get; set; }
        public bool IsApproved { get; set; }
    }
}
