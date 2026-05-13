using Bank_System.Configurations;
using Bank_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Transactions;

namespace Bank_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            using var dbContext = new AppDbContext();

            int choice = 0;
            while (true)
            {
                Menu.start();
                while (true) { 
                if (int.TryParse(Console.ReadLine(), out int c))
                { choice = c;  break; }
                    Menu.Invalid();
                    Menu.start();
                };

                if (choice < 0 || choice >= 6)
                {
                    while (true) {
                        Menu.Invalid();
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    switch (choice)
                    {

                        case 0:
                            Console.Clear();
                            Console.WriteLine("Good Bye..");
                            Environment.Exit(0);
                            break;
                        case 1:
                            var nCustomer = Menu.AddCustomer();
                            if(dbContext.Customers.Any(c => c.Id == nCustomer.Id))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Customer Already Exists !! ");
                                Console.ResetColor();
                                Environment.Exit(0);
                            }
                            else { 
                            dbContext.Customers.Add(nCustomer);
                            dbContext.SaveChanges();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"Customer Created Successfulyly :: Customer ID : {nCustomer.Id} \n");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key To Return To Menu ..");
                            Console.ReadKey();
                            Console.Clear();

                            }
                            break;
                        case 2:                         
                            var nAcc = Menu.AddAccount();
                            bool valid = true;
                                foreach (var c in nAcc.CustomerAccounts)
                                {
                                    if(!dbContext.Customers.Any(cm => cm.Id == c.CustomerId)) { 
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Can't Open New Account If The Customer Is Not Registired !!");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Please Return To Menu And Add New Customer First...");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Press Any Key To Return To Main Menu..");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    Console.Clear();
                                    valid = false;
                                    break;
                                }
                                }
                            if (!valid)
                                continue;
                            if (dbContext.Accounts.Any(a => a.AccountNumber == nAcc.AccountNumber))
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Account already exists !!");
                                Console.ResetColor();
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {

                                dbContext.Accounts.Add(nAcc);
                                dbContext.SaveChanges();

                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            foreach (var c in nAcc.CustomerAccounts)
                            {
                                Console.Write($"Account'{nAcc.AccountNumber}' Linked To Customer {c.CustomerId} As A {c.OwnershipType} Owner\n");
                            }
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;
                        case 3:

                            Menu.UpdateAccount(dbContext);

                            break;
                        case 4:
                            Menu.RemoveAccount(dbContext);
                            break;
                        case 5:
                            Menu.ListCutomers(dbContext);

                            break;

                    }

                }

                
               

            }




        }
    }
}
