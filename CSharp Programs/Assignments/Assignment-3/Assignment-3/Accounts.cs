using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Accounts
    {
        static int account_no;
        static int amount;
        static int balance;
        static String transaction_type, customer_name, account_type;
        public Accounts(int Account_no, String Customer_name, String Account_type)
        {
            account_no = Account_no;
            customer_name = Customer_name;
            account_type = Account_type;
        }
        void Debit(int amount)
        {
            
                if (amount > balance)
                {
                Console.WriteLine("************************");
                    Console.WriteLine("Insufficient amount:");
                Console.WriteLine("************************");
            }
                else
                {
                    balance = balance - amount;
                    Console.WriteLine("****************************************");
                    Console.WriteLine("The amount" + amount + "withdrawn successfully:");
                    Console.WriteLine("****************************************");
                }

            

        }
        void Credit(int amount)
        {
            
            
            
                balance = balance + amount;
                Console.WriteLine("****************************************");
                Console.WriteLine("The amount" + amount + "deposited successfully:");
                Console.WriteLine("****************************************");

            
        }
        void UpdateBalance(int amount )
        {
            if(transaction_type == "Deposit")
            {
                Credit(amount);
            }
            else
            {
                if(transaction_type == "Withdraw")
                {
                    Debit(amount);
                }
            }
            
            

        }
        void ShowData()
        {
            Console.WriteLine("The account number is:" + account_no);
            Console.WriteLine("The customer name is:" + customer_name);
            Console.WriteLine("The account type is:" + account_type);
            Console.WriteLine("The transaction type is:" + transaction_type);
            Console.WriteLine("The amount is:" + amount);
            Console.WriteLine("The available balance is:" + balance);

        }

        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the account number:");
            account_no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the customer name:");
            customer_name = Console.ReadLine();
            Console.WriteLine("Enter the account type:");
            account_type = Console.ReadLine();
            Console.WriteLine("Enter the amount:");
            amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the transaction type Withdraw or Deposit:");
            transaction_type = Console.ReadLine();

            Accounts a = new Accounts(account_no, customer_name, account_type);
            a.UpdateBalance(amount);
            a.ShowData();
            Console.Read();
        }
    }
}
