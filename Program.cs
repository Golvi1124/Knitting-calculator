

namespace Knitting_calculator;

class Program
{

    // Class-level fields Shared across methods
    static string measureSystem = "";
    static bool validEntry = false;
    static string? input;
    static int stitchesCount = 0;
    static int rowsCount = 0;

    static void Main(string[] args)

    {
        // variables that support data entry

        string menuSelection = "";




        // display menu options
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Knitting calculator app!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("What would you like to use?");
            Console.WriteLine(" 1. Gauge calculator");
            Console.WriteLine(" 2. Calculate new Cast-On stitches");
            Console.WriteLine(" 3. How much yarn would you need based on: stitch length");
            Console.WriteLine(" 4. How much yarn would you need based on: weight of product");
            Console.WriteLine(" 5. Blanket size calculator");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            input = Console.ReadLine();
            if (input != null)
            {
                menuSelection = input.ToLower();
                // using a conditional statement that only processes the valid entry values, so the do statement is not required here.
            }

            switch (menuSelection)
            {
                case "1": // Gauge calculator

                    Console.WriteLine("You have selected: Gauge calculator.");
                    InOrCm();
                    Console.WriteLine($"You selected: {measureSystem}");
                    GetStitchesCount();
                    GetRowsCount();
                  //  Console.WriteLine($"What is the length in \"{measureSystem}\" of your test piece?");
                  //  Console.WriteLine($"What is the width in \"{measureSystem}\" of your test piece?");


                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                case "2": // Calculate new Cast-On stitches

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                case "3": // How much yarn would you need based on: stitch length

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                case "4": // How much yarn would you need based on: weight of product

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                case "5": // Blanket size calculator

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                default:
                    break;
            }
        } while (menuSelection != "exit");

    }

    public static void InOrCm()
    {
        do
        {
            Console.WriteLine("Which measurement system do you use - Imperial or Metric? Type 'in' or 'cm'");
            string? readResult = Console.ReadLine();

            if (readResult != null)
            {
                measureSystem = readResult.ToLower();
                if (measureSystem == "in" || measureSystem == "cm")
                {
                    validEntry = true;
                }
                else
                {
                    Console.WriteLine($" \"{measureSystem}\" is invalid input!");
                    validEntry = false;
                }
            }

        } while (!validEntry);


    }

    public static void GetStitchesCount()
    {


        do
        {
            Console.WriteLine("How many stitches per 1 row have you made?");
            string? input = Console.ReadLine(); // Read user input

            // Use TryParse to validate and convert the input
            if (int.TryParse(input, out stitchesCount) && stitchesCount > 0)
            {
                validEntry = true; // Input is valid
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive whole number."); // Error message for invalid input
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetRowsCount()
    {


        do
        {
            Console.WriteLine("How many rows have you made?");
            string? input = Console.ReadLine(); // Read user input

            // Use TryParse to validate and convert the input
            if (int.TryParse(input, out rowsCount) && rowsCount > 0)
            {
                validEntry = true; // Input is valid
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive whole number."); // Error message for invalid input
                validEntry = false;
            }
        } while (!validEntry);
    }

}