using System;

namespace Bank_Management_System {
  class Account {

    string[] name = new string[100];
    string[] accountID = new string[100];
    double[] accountBalance = new double[100];
    string[] type = new string[100];

    static int count = -1;

    public Account() { }

    public void Create_Account() {

      count++;
      Console.WriteLine("Enter Your Name : ");
      name[count] = Console.ReadLine();

      Console.WriteLine("Enter Account Type : ");
      type[count] = Console.ReadLine();
      i: Console.WriteLine("Enter Initial Ammount : ");
      double initial = Convert.ToDouble(Console.ReadLine());
      if (initial >= 500) {
        accountBalance[count] += initial;
      }
      else {
        Console.WriteLine("Initial Amount has to be more than 500.");
        Console.WriteLine();
        goto i;
      }

      accountID[count] = name[count] + "2020" + type[count] + count;

      Console.WriteLine(accountID[count]);
      Console.WriteLine();
    }
    public void deposit(double amount) {
      d: Console.WriteLine("Enter the Account Number : ");
      string s = Console.ReadLine();
      for (int i = 0; i <= count; i++) {
        if (s == accountID[i]) {
          accountBalance[i] += amount;
          Console.WriteLine("{0} Added to your Account ", amount);
          Console.WriteLine("New Balance : {0} ", accountBalance[i]);
          Console.WriteLine();
          break;

        }
        else {
          Console.WriteLine("Invalid Account Number");
          Console.WriteLine();
          goto d;

        }
      }
    }
    public void withdraw(double amount) {
      w: Console.WriteLine("Enter the Account Number : ");
      string s = Console.ReadLine();
      for (int i = 0; i <= count; i++) {
        if (s == accountID[i]) {
          if (accountBalance[i] - 500 >= amount) {
            accountBalance[i] -= amount;
            Console.WriteLine("{0} Withdrawn from your Account ", amount);
            Console.WriteLine("New Balance : {0} ", accountBalance[i]);
            Console.WriteLine();
            break;
          }
          else {
            Console.WriteLine("You hane to keep atleast 500 in your account");
            goto w;
          }

        }
        else {
          Console.WriteLine("Invalid Account Number");
          Console.WriteLine();
          goto w;
        }
      }
    }
    public void showAccountInfo() {
      for (int i = 0; i <= count; i++) {
        if (count != -1) {
          Console.WriteLine("Account ID : " + accountID[i]);
          Console.WriteLine("Name : " + name[i]);
          Console.WriteLine("Account Type : " + type[i]);
          Console.WriteLine("Balance Amount : " + accountBalance[i]);
          Console.WriteLine();
        }
        else {
          Console.WriteLine("No Accounts ");
          Console.WriteLine();
        }
      }
    }
    public void transferMoney(double amount) {
      x: Console.WriteLine("Enter Senders Bank Account ID: ");
      string sender = Console.ReadLine();
      Console.WriteLine("Enter Recivers Bank Account ID: ");
      string reciver = Console.ReadLine();
      for (int i = 0; i <= count; i++) {
        for (int j = 0; j <= count; j++) {
          if (String.Equals(sender, accountID[i]) && String.Equals(reciver, accountID[j])) {
            if (accountBalance[i] - 500 > amount) {
              accountBalance[i] -= amount;
              accountBalance[j] += amount;
            }
          }
          else {
            Console.WriteLine("Invalid BankID. Try Again.");
            goto x;
          }
        }
      }
      Console.WriteLine(" The Amount han been Transfered.... ");

      Console.WriteLine();
    }
  };

  class Program: Account {
    public static void menu() {
      Console.WriteLine("1. Create Account.");
      Console.WriteLine("2. Deposit Money.");
      Console.WriteLine("3. Withdraw Money.");
      Console.WriteLine("4. Show All Accounts.");
      Console.WriteLine("5. Transfer Money.");
      Console.WriteLine("6. Exit.");
      Console.WriteLine();
    }
    static void Main(string[] args) {
      bool x = true;
      double ammount = 0;
      Account acc = new Account();
      while (x == true) {
        m:
        Console.Clear();
        menu();
        Console.WriteLine();
        Console.WriteLine("Enter an Option : ");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice) {
        case 1:
          Console.Clear();
          Console.WriteLine("CREATING A NEW ACCOUNT....");
          Console.WriteLine();
          acc.Create_Account();
          break;
        case 2:
          Console.Clear();
          Console.WriteLine("Money Deposit....");
          Console.WriteLine();
          Console.WriteLine("\t\tEnter Ammount : ");
          ammount = Convert.ToDouble(Console.ReadLine());
          acc.deposit(ammount);
          break;
        case 3:
          Console.Clear();
          Console.WriteLine("Money Withdrawl...");
          Console.WriteLine();
          Console.WriteLine("\t\tEnter Ammount : ");
          ammount = Convert.ToDouble(Console.ReadLine());
          acc.withdraw(ammount);
          break;
        case 4:
          Console.Clear();
          Console.WriteLine("Loading All Accounts...");
          Console.WriteLine();
          acc.showAccountInfo();
          break;
        case 5:
        Console.Clear();
          Console.WriteLine("Loading Transfer Window...");
          Console.WriteLine();
          Console.WriteLine("Enter Ammount You Want to Transfer : ");
          ammount = Convert.ToDouble(Console.ReadLine());
          acc.transferMoney(ammount);
          break;
        case 6:
          System.Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Wrong Input Try Again.");
          goto m;
        }
      }
    }
  }
}