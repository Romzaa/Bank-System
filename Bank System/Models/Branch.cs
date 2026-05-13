using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    internal class Branch
    {
        [Key]
        public string Code { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public  string Address { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }

        // Manager Relation
        public Manager BranchManager { get; set; } = null!;
        public int ManagerId { get; set; }


        // Accounts Relation
        public ICollection<Account> Accounts { get; set; } 


    }
}
