using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        // Account Relation
        public Account Account { get; set; } 
        public int AccountId { get; set; }

    }
}
