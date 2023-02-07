using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntn18001_FinalProject
{
    //Defining characteristics of bank clients.
    public class Clients
    {
        public string firstName;
        public string lastName;
        public string accountNumber;
        public decimal balance;
        public int pinNumber;

        //Constructor so that I don't manually have to assign these fields in my program. 
        public Clients(string firstName, string lastName, string accountNumber, decimal balance, int pinNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.accountNumber = accountNumber;
            this.pinNumber = pinNumber;
            this.balance = balance;
        }

        public Clients()
        {
        }


        //Have getters and setters to make validation of account and pin numbers easier.
        public string getfirstName()
        {
            return firstName;
        }
        public string getlastName()
        {
            return lastName;
        }
        public string getaccountNumber()
        {
            return accountNumber;
        }
        public decimal getbalance()
        {
            return balance;
        }
        public int getpinNumber()
        {
            return pinNumber;
        }


        public void setfirstName(String newfirstName)
        {
            firstName = newfirstName;
        }

        public void setlastName(String newlastName)
        {
            lastName = newlastName;
        }
        public void setaccountNumber(String newaccountNumber)
        {
            accountNumber = newaccountNumber;
        }
        public void setbalance(decimal newoutstandingBalance)
        {
            balance = newoutstandingBalance;
        }
        public void setpinNumber(int newpinNumber)
        {
            pinNumber = newpinNumber;
        }
    }
}
