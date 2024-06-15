using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PlayerClient
{
    public class Callback : ServiceReference.IPlayerServiceCallback
    {
        public void MessageArrived(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        static ServiceReference.PlayerServiceClient playerClient;
        static void Main(string[] args)
        {
            InstanceContext ic = new InstanceContext(new Callback());
            playerClient = new ServiceReference.PlayerServiceClient(ic);
            string playerUUID = Guid.NewGuid().ToString();

            while (true)
            {

                int number1 = GetNumber("Enter your first number (0-10): ");
                int number2;

                while (true)
                {
                    number2 = GetNumber("Enter your second number (0-10): ");
                    if (number2 != number1)
                    {
                        break;
                    }
                    Console.WriteLine("The second number cannot be the same as the first number. Please enter a different number.");
                }
                double amount = GetAmount("Enter the amount to bet: ");

                playerClient.InitPlayer(playerUUID, number1, number2, amount);
                
            }

            Console.WriteLine("Thank you for playing!");
            Console.ReadLine();
        }

        static int GetNumber(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out number) && number >= 0 && number <= 10)
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a number between 0 and 10.");
            }
        }

        static double GetAmount(string prompt)
        {
            double amount;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out amount) && amount > 0)
                {
                    return amount;
                }
                Console.WriteLine("Invalid input. Please enter a positive amount.");
            }
        }
    }
    
}
