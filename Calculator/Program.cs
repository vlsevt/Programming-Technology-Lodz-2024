using NUnit.Framework;

namespace CalculatorProgram
{
    class Program
    {

        static void Main(string[] args)
        {

            Calculator calculator = new Calculator();


            Console.WriteLine("Enter the first number:");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int number2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter operation (+ or -):");
            string operation = Console.ReadLine();

            int result;

            switch (operation)
            {
                case "+":
                    result = calculator.Add(number1, number2);
                    break;
                case "-":
                    result = calculator.Subtract(number1, number2);
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    return;
            }

            Console.WriteLine($"The result is: {result}");
            Console.WriteLine($"Type anything to close the console");
            while (true)
            {
                string close = Console.ReadLine();
                if (close != null)
                {
                    break;
                }
            }
        }
    }
}
