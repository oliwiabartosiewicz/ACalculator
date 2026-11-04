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
    
    
    /*
     *NUMBER INPUT METHOD
     * Requests a number from the user
     * uses double so decimal numbers are accepted
     * uses TryParse to check uf the input is valid
     * a while loop repeats if the input is incorrect
     * prevents NaN and infinity values
     */
    
    
    static double GetNumber( string message )
    {
        double number;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out number) &&
                !double.IsNaN(number) && // if not a number 
                !double.IsInfinity(number)) // if not infinity
                {
                    return number;
                }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        
        /* Integer INPUT METHOD
         used when program needs a whole number 
         repeats until a valid integer is entered 
         EXAMPLES
         Menu choices and factorial values
        */
        
        static int GetInteger(string message)
        {
            int number;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    
    /*
     * CALCULATION METHODS
     * These methods perform the actual calculations
     * They are called from the main program
     */
    
    static void BasicCalculation(string operation)
    {
        double a = GetNumber("Enter first number: ");
        double b = GetNumber("Enter second number: ");
        
        double result = 0;

        switch (operation)
        {
            case "+":
                result = a + b;
                break;
            case "-":
                result = a - b;
                break;
            case "*":
                result = a * b;
                break;
            case "/":
                if (b == 0) // division by 0 is not allowed 
                {
                    Console.WriteLine("Error: Division by zero.");
                    return;

                }

                result = a / b;
                break;

            case "%":
                // modules also requires a non- zero divisor
                if (b == 0)
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                    return;

                }

                result = a % b;
                break;
        }
        DisplayResult (a + " " + operation + " " + b + " = " + result);

    }
    
    
    
    /* Section 6
     allows a user to raise a number  to a chosen power 
     uses math.pow()
     
     EXAMPLE :
     2 to the power of 3 = 8 
     
     */

    static void CalculatePower(string operation)
    {
        double number = GetNumber("Enter a number: ");
        double power = GetNumber("Enter exponent: ");
        double result = Math.Pow(number, power);

        DisplayResult(number + "^" + power, result);
    }
    
    /*
     * SECTION 7 - SQUARE ROOT
     * CALCULATES THE SQUARE ROOT OF A NUMBER
     * Uses Math.Sqrt().
     * Checks that the number is not negative
     *
     * EXAMPLE
     * Square root of 25 is 5 
     */

    static void SquareRoot()
    {

        double number = GetNumber("Enter number");
        if (number < 0)
        {
            Console.WriteLine("Error: Square root of a negative number is not allowed.");
            return;
        }

        double result = Math.Sqrt(number);
        
        DisplayResult("Square root of " + number, result);
        
    }
    
    /*
     * SECTION 8 - PERCENTAGES
     * CALCULATES THE PERCENTAGE OF A NUMBER
     * Divides a percentage by 100.
     * Multiplies the result by the total 
     *
     * EXAMPLE
     * 100% of 50 = 50
     */
    
    static void Percentages()
    
    }
    
    
}