using ExceptionErrorExercicio.Entities;
using ExceptionErrorExercicio.Entities.Exceptions;
using System.Globalization;

namespace ExceptionErrorExercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data: ");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string? holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine());
                Console.Write("Withdraw limit: ");
                double withrawLimit = double.Parse(Console.ReadLine());
                Account account = new Account(number, holder, balance, withrawLimit);
                Console.WriteLine();
                Console.WriteLine("Do you want to deposit any amount? y/n");
                char depositBoolean = char.Parse(Console.ReadLine());
                if(depositBoolean == 'y')
                {
                    Console.Write("Enter amount for deposit: ");
                    double deposit = double.Parse(Console.ReadLine());
                    account.Deposit(deposit);
                }
                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amountWithdraw = double.Parse(Console.ReadLine());

                account.Withdraw(amountWithdraw);
                Console.WriteLine("New balance: " + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (DomainException error)
            {
                Console.WriteLine(error.Message);
            }
            catch (FormatException error)
            {
                Console.WriteLine("Format error: " + error.Message);
            }
            catch (Exception error)
            {
                Console.WriteLine("Unexpected error: " + error.Message);
            }


        }
    }
}