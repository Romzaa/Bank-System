using Bank_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Configurations
{
    public static class Menu
    {

        internal static void start() {
            Console.WriteLine(
                "==================================================\n" +
                "             National Bank - Management           \n" +
                "==================================================\n" +
                "1) Add New Customer\n" +
                "2) Open A New Account For A Customer\n" +
                "3) Update Account Status From A Customer\n" +
                "4) Remove An Account From A Customer\n" +
                "5) List All Customers (With Accounts)\n" +
                "0) Exit \n" +
                "--------------------------------------------------\n" +
                "Enter Choice   :  \n" +
                "\n"
                );
        }

        internal static void Invalid()
        {
            Console.WriteLine("Invalid Input...");
            Console.ReadKey(true);
            Console.Clear();
        }

        internal static Customer AddCustomer()
        {
            string fName=string.Empty;
            int nId=0;
            DateOnly bd = DateOnly.Parse("10-10-2010");
            string email= string.Empty;
            int phone=0;
            string address= string.Empty;
            CustomerType cmType=0;

            while (true)
            {
                Console.Clear();
                Console.Write(
                "---- Add New Customer ----\n" +
                $"Full Name     : ");
                var nameinput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nameinput))
                {
                    fName = nameinput;
                    break;
                }
                ;
                Menu.Invalid();
            }
            while (true)
            {
                Console.Write(
                $"NationalId    : "
                );
                if (int.TryParse(Console.ReadLine(), out int natId))
                { nId = natId; break; }
                Menu.Invalid();
            }
            ;
            while (true)
            {
                Console.Write(
                $"Date Of Birth : "
                );
                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly bdo))
                { bd = bdo; break; }
                Menu.Invalid();
            }
            while (true)
            {
                Console.Write(
                $"Email         : "
                );
                var emailinput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(emailinput))
                {
                    email = emailinput;
                    break;
                }
                Menu.Invalid();
            }
            ;
            while (true)
            {
                Console.Write(
                $"Phone         : "
            );
                if (int.TryParse(Console.ReadLine(), out int tele))
                { phone = tele; break; }
                Menu.Invalid();
            }
            ;
            while (true)
            {
                Console.Write(
                $"Address       : "
                );
                var addressInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(addressInput))
                { address = addressInput; break; }

                Menu.Invalid();
            }
            ;
            while (true)
            {
                Console.Write(
                $"Customer Type :\n" +
                $"   1) Individual \n" +
                $"   2) Business   \n" +
                $"                Choice : "
                );
                if (int.TryParse(Console.ReadLine(), out int cmt) && cmt > 0 && cmt < 3)
                { cmType = (CustomerType)cmt; break; }
                Menu.Invalid();
            }
            ;
            return (
            new Customer
            {
                FullName = fName,
                NationalId = nId,
                DateOfBirth = bd,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                CustomerType = cmType

            }
            );
        }

        internal static Account AddAccount()
        {
            int accNo = 0;
            AccType acntype = 0;
            string branchCode = "";
            int customerId = 0;
            OwnerType onType;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Open New Account ---\n" +
                                  "Account Number : ");

                if (int.TryParse(Console.ReadLine(), out int acc))
                { accNo = acc; break; }

                Menu.Invalid();
            }
            while (true)
            {
                Console.Write(
                    $"Account Type   :        \n" +
                    $"        1) Savings      \n" +
                    $"        2) Current      \n" +
                    $"        3) Business     \n" +
                    $"               Choice : ");

                if (int.TryParse(Console.ReadLine(), out int acc) && acc > 0 && acc < 4)
                { acntype = (AccType)acc; break; }
                Menu.Invalid();

            }
            while (true)
            {
                Console.Write(
                    $"Branch Code    : ");
                var code = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(code))
                { branchCode = code; break; }
                Menu.Invalid();

            }

            while (true)
            {
                Console.Write(
                    $"Customer ID    : ");

                if (int.TryParse(Console.ReadLine(), out int cm))
                { customerId = cm; break; }
                Menu.Invalid();

            }
            while (true)
            {
                Console.Write(
                    $"Ownership Role :             \n" +
                    $"         1) Primary          \n" +
                    $"         2) Co-Holder        \n" +
                    $"                 Choice : ");

                if (int.TryParse(Console.ReadLine(), out int ot) && ot > 0 && ot < 3)
                { onType = (OwnerType)ot; break; }
                Menu.Invalid();

            }

            return (
            new Account
            {
                //AccountNumber = accNo,
                AccountType = acntype,
                BranchId = branchCode,
                CustomerAccounts = new List<CustomerAccount>
                                {
                                    new CustomerAccount
                                    {
                                        CustomerId = customerId,
                                        OwnershipType = onType,
                                        OwnershipDate = DateTime.Now,
                                        AccountStatus = AccStatus.Active
                                    }
                                }
            }
            );
        }

        internal static void UpdateAccount(AppDbContext dbContext)
        {
            int accId;
            int cmId;
            AccStatus newStatus;

            while (true) {
                Console.Clear();
                Console.Write("--- Update Account Status ---\n" +
                                  "Account Number : ");

                if (int.TryParse(Console.ReadLine(), out int acc))
                { accId = acc; break; }
                Menu.Invalid();
            }
            while (true)
            {
                Console.Write("Customer Id    : ");

                if (int.TryParse(Console.ReadLine(), out int cm))
                { cmId = cm; break; }
                Menu.Invalid();
            }
            while (true)
            {
                Console.Write("New Status     ::\n" +
                                "     1) Active\n" +
                                "     2) Closed \n" +
                                "             Choice : ");

                if (int.TryParse(Console.ReadLine(), out int at))
                { newStatus = (AccStatus)at; break; }
                Menu.Invalid();
            }
            var cmAcc = dbContext.Accounts.Include(a => a.CustomerAccounts
                                           .Where(c => c.CustomerId == cmId))
                                           .FirstOrDefault(a => a.AccountNumber == accId);

            while (true) { 
            if (cmAcc != null) 
            { 
                foreach(var acc  in cmAcc.CustomerAccounts)
                {
                    acc.AccountStatus = newStatus;
                    dbContext.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Status Now Updated To {acc.AccountStatus}");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key To Return To Menu ..");
                    Console.ReadKey();
                    Console.Clear();
                        

                }
                    break;


                }

                else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There Is No Account With This ID !! ");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Press Any Key To Return To Main Menu ...");
                Console.ReadKey();
                Console.Clear();
                    break;
            }


            }


        }

        internal static void RemoveAccount(AppDbContext dbContext) {

            int accId;
            int cmId;

            while (true)
            {

                Console.Clear();
                Console.Write("--- Remove Account From Customer ---\n" +
                              "Account Number :");
                if(int.TryParse(Console.ReadLine(), out int acc))
                {
                    accId = acc; break;
                }
                else { Invalid(); }

            }
            while (true)
            {

                Console.Write("Customer ID    :");
                if (int.TryParse(Console.ReadLine(), out int cm))
                {
                    cmId = cm; break;
                }
                else { Invalid(); }

            }

            if (cmId != 0 && accId != 0)
            {
                var accs = dbContext.Customers.Include(c => c.CustomerAccounts)
                                              .FirstOrDefault(c => c.Id == cmId);

                foreach(var cmAcc in accs.CustomerAccounts)
                {
                    if(cmAcc.CustomerId == cmId && cmAcc.AccountId == accId)
                    {
                        dbContext.Remove(cmAcc);
                        dbContext.SaveChanges();
                        break;
                    }
                    
                }

                if(dbContext.Customers.Include(c => c.CustomerAccounts.Where(ca => ca.AccountId == accId)).Count() > 0) { 

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Ownership Link Deleted");
                }else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Ownership Link Deleted");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"            This Was The Last Owner..");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key To Return To Main Menu ...");
                    Console.ReadKey();
                    Console.Clear();


                }

            }

        }

        internal static void ListCutomers(AppDbContext dbContext)
        {
            var customers = dbContext.Customers.Include(c => c.CustomerAccounts).ThenInclude(ca => ca.Account).ThenInclude(a => a.Branch);
            int i = 0;

            Console.Clear();

            foreach ( var cm in customers)
            {
                 ++i;

                Console.WriteLine($"#{i} {cm.FullName} :: ({cm.CustomerType})");

        
                    if (cm.CustomerAccounts.Any()) 
                    {

                    foreach (var acc in cm.CustomerAccounts)
                    {
                        Console.WriteLine($"{acc.AccountId} :: Current Balance {acc.Account.CurrentBalance} :: {acc.Account.AccountType} :: {acc.AccountStatus} :: {acc.Account.Branch.Name} ");
                    }
                    }
                    else
                    {
                        Console.WriteLine(" No Accounts ...");
                    }

                
            }

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Return To Main Menu ...");
            Console.ReadKey();
            Console.Clear();
        }



    }
}
