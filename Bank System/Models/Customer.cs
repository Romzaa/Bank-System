using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public int NationalId { get; set; }
        public CustomerType CustomerType { get; set; } 


        // Account Relation
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } 


    }
}
