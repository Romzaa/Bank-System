using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    internal class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public AccType AccountType { get; set; } 
        public DateOnly OpeningDate { get; set; }

        // Branch Relation
        public Branch Branch { get; set; } 
        public string BranchId { get; set; } 

        // Customers Relation
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } 

        // Transactions Relation
        public ICollection<Transaction> Transactions { get; set; } 

    }
}
