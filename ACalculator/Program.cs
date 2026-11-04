using System.Data;

namespace ACalculator;
using System.Collections.Generic;



class Program
{
    static List<string> history = new List<string>();
    
    
    
    static void Main(string[] args)
    {
        bool running = true;
        
       

        while (running)
        {
            
            Console.Clear();
            Console.WriteLine("------CALCULATOR------");
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
            
            if (running)
            {
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
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


    static double GetNumber(string message)
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
        DisplayResult (a + " " + operation + " " + b, result);

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
    {

        double percentage = GetNumber("Enter percentage: ");
        double total = GetNumber("Enter total: ");
        double result= (percentage / 100) * total;
        
        DisplayResult(percentage +"% of" + total, result);
    }
    
    /*
     * SECTION 9 - AVERAGE
     * CALCULATES THE AVERAGE OF TWO NUMBERS
     * Divides the sum of the two numbers by the total number of numbers
     *
     * EXAMPLE
     * Average of 10 and 20 = 15
     */


    static void CalculateAverage()
    {
        int amount = GetInteger("Enter the number of numbers: ");
        if (amount <= 0)
        {
            Console.WriteLine( "Enter at least one number");
            return;
        }
        double total = 0;
        
        for (int i = 1; i <= amount; i++)
        {
            total += GetNumber("Enter number" + i + ": ");
            
        }

        double average = total / amount;
        DisplayResult("Average of " + amount + " numbers", average);
    }
    
    
    /*
     * SECTION 10 - FIND LARGEST AND SMALLEST
     * CALCULATES THE LARGEST AND SMALLEST NUMBER IN A LIST
     * Uses the built-in functions min() and max()
     *
     * EXAMPLE
     * Largest number in the list is 100
     * Smallest number in the list is 1
     */

    static void FindLargestAndSmallest()
    {
        int amount = GetInteger("Enter the number of numbers: ");
        if (amount <= 0)
        {
            Console.WriteLine("Enter at least one number");
            return;
        }
        double largest = GetNumber("Enter number:1 ");
        double smallest = largest;

        for (int i = 2; i <= amount; i++)
        {
            double number =GetNumber("Enter number" + i + ": ");
            if (number > largest)
                largest = number;
            if (number < smallest)
                smallest = number;
        }
        Console.WriteLine("Largest number in the list is " + largest);
        Console.WriteLine("Smallest number in the list is " + smallest);
    }
    /*
     * SECTION 11 - FACTORIAL
     * CALCULATES THE FACTORIAL OF A NUMBER
     * Uses the built-in function factorial()
     *
     * EXAMPLE
     * Factorial of 5 is 120
     */


    static void CalculateFactorial()
    {
        int number = GetInteger("Enter a number (0-170): ");
        if (number < 0 || number > 170)
        {
            Console.WriteLine("Error: Factorial is not defined for numbers greater than 170.");
            return;
        }

        double result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        DisplayResult(number + "! = ",result);
    }
    
    /*
     * SECTION 12 - Trigonometry
     * CALCULATES THE SINE, COSINE, AND TANGENT OF A NUMBER55
     * Uses the built-in functions sin(), cos(), tan(), and asin()
     *
     * uses a switch statement to select
     * checks when tangest is undefined
     * FORMULA
     * Radians = Degrees * PO/180
     * 
     * EXAMPLE
     * Sine of 0 is 0
     * Cosine of 90 degrees is 1
     */

    static void Trigonometry()

    {
        Console.WriteLine("Options");
        Console.WriteLine("1. Sine");
        Console.WriteLine("2. Cosine");
        Console.WriteLine("3. Tangent");

        int choice = GetInteger("Enter your choice: ");
        double degrees = GetNumber("Enter angle in degrees: ");
        // converts degrees into radians 
        double radians = degrees * Math.PI / 180;
        double result;
        switch (choice)
        {
            case 1:
                result = Math.Sin(radians);
                DisplayResult("Sin(" + degrees + ")", result);
                break;
            case 2:
                result = Math.Cos(radians);
                DisplayResult("Cos(" + degrees + ")", result);
                break;
            case 3:
                //Tangent is undefined  when cosine is zero.
                if (Math.Abs(Math.Cos(radians)) < 0.0000001)
                {
                    Console.WriteLine("Error: Tangent is undefined at this angle.");
                    return;
                }

                result = Math.Tan(radians);
                DisplayResult("Tan(" + degrees + ")", result);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    /*
     * SECTION 13 - ROUNDING
     * ROUNDS A NUMBER TO THE NEAREST INTEGER
     * Uses the built-in function Math.Round()
     *
     * EXAMPLE
     * Rounding 3.1415926535897932384626433832795 is 3.14
     */


    static void RoundNumber()
    {
        double number = GetNumber("Enter number");
        int decimals = GetInteger("Decimal places (0-15): ");
        if (decimals < 0 || decimals > 15)
        {
            Console.WriteLine("Error: Decimal places must be between 0 and 15.");
            return;
        }

        double result = Math.Round(number, decimals);
        DisplayResult("Rounded number" + number, result);
    }
    
    /*
     * SECTION 14 - VIEW HISTORY
     * DISPLAYS THE HISTORY OF CALCULATIONS
     * Uses a list to display each calculation
     * Uses history.Count to check if the listcontains any saved calculations
     * Uses for each to display every item
     *
     * EXAMPLE
     * 1 + 2 = 3
     * 3 - 2 = 1
     */


    static void ViewHistory()
    {
        Console.WriteLine("CALCULATION HISTORY:");
        if (history.Count == 0)
        {
            Console.WriteLine("No calculations yet.");
            return;
        }
        
        foreach (string item in history)
            {
                Console.WriteLine(item);
            }
    }
    
    
    
    
    
    /*
     * SECTION 15 - DISPLAY RESULT
     * DISPLAYS THE RESULT OF A CALCULATION
     * combines the calculation and result into one string
     * Saves the result in calculation history
     * Checks for invalid numerical results
     *
     * this method is reused by other methods to avoid repeating the same code 

    */

    static void DisplayResult(string calculation, double result)
    {
        if (double.IsNaN(result)|| double.IsInfinity(result))
        {
            Console.WriteLine("Error: Invalid result its outside the supported range.");
            return;
        }
        string output = calculation + " = " + result;
        Console.WriteLine("\n RESULT:"+output);
        //ADDS THE COMPLETED calculation to the history list
        history.Add(output);
    }
    
    
    }
    
    
    
