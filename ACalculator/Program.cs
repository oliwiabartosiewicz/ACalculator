namespace ACalculator;
using System.Collections.Generic;



class Program
{
    static List<string> history = new List<string>();
    
    
    
    static void Main(string[] args)
    {
        bool running = true;
        
        Console.WriteLine("CALCULATOR");

        while (running)
        {
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Modulus");
            Console.WriteLine("6. Powers");
            Console.WriteLine("7. Square Root");
            Console.WriteLine("8. Percentages");
            Console.WriteLine("9. Averages");
            Console.WriteLine("10. Largest and Smallest");
            Console.WriteLine("11. Factorial");
            Console.WriteLine("12. Trigonometry");
            Console.WriteLine("13. Rounding");
            Console.WriteLine("14. View History");
            Console.WriteLine("15. Clear History");
            Console.WriteLine("16. Exit");

            int choice = GetInteger("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    BasicCalculation("+");
                    break;

                case 2:
                    BasicCalculation("-");
                    break;

                case 3:
                    BasicCalculation("*");
                    break;

                case 4:
                    BasicCalculation("/");
                    break;

                case 5:
                    BasicCalculation("%");
                    break;
                case 6:
                    CalculatePower("%");
                    break;

                case 7:
                    SquareRoot();
                    break;

                case 8:
                    Percentages();
                    break;

                case 9:
                    CalculateAverage();
                    break;

                case 10:
                    FindLargestAndSmallest();
                    break;

                case 11:
                    CalculateFactorial();
                    break;

                case 12:
                    Trigonometry();
                    break;

                case 13:
                    RoundNumber();
                    break;

                case 14:
                    ViewHistory();
                    break;

                case 15:
                    history.Clear();
                    Console.WriteLine("History cleared.");
                    break;

                case 16:
                    running = false;
                    Console.WriteLine("Thank you for using the calculator baddie");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
                
            }
        }
    } 
    
    static double GetNumber( string message )
    {
        double number;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out number) &&
                !double.IsNaN(number) &&
                !double.IsInfinity(number))
                {
                    return number;
                }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        
   
    
    
    
}