using System;
using ntn18001_FinalProject;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    class Program
    {

        static void Main(string[] args)
        {
            {
                Console.Title = "Nhi's ATM";

                //ATM options.
                void printOptions()
                {
                    Console.WriteLine("Please choose from one of the following options:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Show Balance");
                    Console.WriteLine("4. Exit");
                }

                //The behind the scenes of what happens when the user chooses to deposit money."
                void deposit(Clients currentClient)
                {
                    Console.WriteLine("How much would you like to deposit: ");

                    //User inputting amt he/she wants to deposit. 
                    decimal depos = Decimal.Parse(Console.ReadLine());
                    //New balance calculated
                    currentClient.setbalance(currentClient.getbalance() + depos);
                    Console.WriteLine("Thank you for using Nhi's ATM. Your new balance is: $" + currentClient.getbalance());
                }

                //The behind the scenes of what happens when user chooses to withdraw.
                void withdraw(Clients currentClient)
                {
                    Console.WriteLine("How much would you like to withdraw: ");

                    //User inputting amt he/she wants to withdraw. 
                    decimal withdrawal = Decimal.Parse(Console.ReadLine());

                    //Catches whether client is withdrawing more than he/she has.
                    if (currentClient.getbalance() < withdrawal)
                    {
                        Console.WriteLine("Insufficient balance. You only have $" + currentClient.getbalance() + ".");
                    }
                    else
                    {
                        //If amt is feasible, then client's new balance is calculated.
                        currentClient.setbalance(currentClient.getbalance() - withdrawal);
                        Console.WriteLine("Thank you for using Nhi's ATM. Your new balance is: $" + currentClient.getbalance());
                    }
                }

                //The behind the scenes of what happens when user chooses to see balance.
                void balance(Clients currentClient)
                {
                    Console.WriteLine("Your current balance: $" + currentClient.getbalance());
                }

                //Insert text file here.
                string[] clientText = File.ReadAllLines(@"C:\Users\Nhi Nguyen\Desktop\My Visual Projects\Bank Clients.txt");
                List<Clients> clients = new List<Clients>();

                //Split the lines in text file for the different pieces of information. Mainly for validation.
                foreach (string line in clientText)
                {

                    Clients client = new Clients();
                    string[] clientInfo = line.Split(',');
                    client.firstName = clientInfo[0];
                    client.lastName = clientInfo[1];
                    client.accountNumber = clientInfo[2];
                    client.pinNumber = Convert.ToInt32(clientInfo[3]);
                    client.balance = Convert.ToDecimal(clientInfo[4]);

                    clients.Add(client);

                }


                Console.WriteLine("Welcome to Nhi's ATM");
                Console.WriteLine("Please insert your account number: ");
                string debitCardNum = "";
                Clients currentUser;

                //Validate account number.
                while (true)
                {
                    try
                    {
                        debitCardNum = Console.ReadLine();
                        currentUser = clients.FirstOrDefault(a => a.accountNumber == debitCardNum);
                        if (currentUser != null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Card not recognized. Please try again.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Card not recognized. Please try again.");
                    }
                }


                //Validate pin number.
                Console.WriteLine("Please enter your pin: ");
                int userPin = 0;
                while (true)
                {
                    try
                    {
                        userPin = int.Parse(Console.ReadLine());
                        if (currentUser.getpinNumber() == userPin)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Pin is incorrect. Please try again.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Pin is incorrect. Please try again.");
                    }
                }

                //After inpputs are validated, prompt the user to choose an action.
                Console.WriteLine("Welcome back " + currentUser.getfirstName() + " " + currentUser.getlastName() + "!");
                int option = 0;
                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch { }
                    if (option == 1)
                    { deposit(currentUser); }

                    else if (option == 2)
                    { withdraw(currentUser); }

                    else if (option == 3)
                    { balance(currentUser); }

                    else if (option == 4)
                    { break; }

                    else { option = 0; }
                }
                while (option != 4);
                Console.WriteLine("Thank you for using Nhi's ATM. Have a wonderful day!");
            }
        }

    }
}
