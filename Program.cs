using System;

namespace CalculatorConsole
{
    internal class Program
    {
        private double FirstNumber;
        private double SecondNumber;
        private string Operation;
        private double Result;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.UserInput();
            program.ComputeInputs();
            Console.ReadKey();
        }

        private void UserInput()
        {
            Console.WriteLine("$--- Simple Calculator ---$");

            FirstNumber = GetNumberFromUser("Enter first number: ");

            Operation = GetOperationFromUser("Enter operation (+, -, *, /, %): ");

            SecondNumber = GetNumberFromUser("Enter second number: ");

            Console.WriteLine("$----------------------------$");
        }

        private double GetNumberFromUser(string prompt)
        {
            double number;
            Console.WriteLine(prompt);

            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.WriteLine(prompt);
            }

            return number;
        }

        private string GetOperationFromUser(string prompt)
        {
            string operation;
            Console.WriteLine(prompt);

            while (true)
            {
                operation = Console.ReadLine();
                if (IsValidOperation(operation))
                    break;

                Console.WriteLine("Invalid operation. Please enter one of the following operations: +, -, *, /, %");
                Console.WriteLine(prompt);
            }

            return operation;
        }

        private bool IsValidOperation(string operation)
        {
            return operation == "+" || operation == "-" || operation == "*" || operation == "/" || operation == "%";
        }

        private void ComputeInputs()
        {
            try
            {
                switch (Operation)
                {
                    case "*":
                        Result = FirstNumber * SecondNumber;
                        break;
                    case "+":
                        Result = FirstNumber + SecondNumber;
                        break;
                    case "-":
                        Result = FirstNumber - SecondNumber;
                        break;
                    case "/":
                        if (SecondNumber == 0)
                            throw new DivideByZeroException("Cannot divide by zero.");
                        Result = FirstNumber / SecondNumber;
                        break;
                    case "%":
                        Result = FirstNumber % SecondNumber;
                        break;
                }

                Console.WriteLine("\nOutput");
                Console.WriteLine($"{FirstNumber} {Operation} {SecondNumber} = {Result}");
                Console.WriteLine("\nPress any key to exit...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
