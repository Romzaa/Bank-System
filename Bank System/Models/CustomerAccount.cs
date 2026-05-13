using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    internal class CustomerAccount
    {
        // Accounts Relation
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        // Customers Relation
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public DateTime OwnershipDate { get; set; }
        public OwnerType OwnershipType { get; set; }
        public AccStatus AccountStatus { get; set; }

    }
}
