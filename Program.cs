namespace Knitting_calculator;

class Program
{
    // Shared across methods
    static string measureSystem = "";
    static bool validEntry = false;
    static string? input;
    static int stitchesCount = 0;
    static int rowsCount = 0;
    static double width = 0;
    static double length = 0;
    static double stitchesPerUnit = 0;
    static double rowsPerUnit = 0;
    static double stitchesPerMeasure;
    static double stitchesPerMeasurePattern;
    static int castOnCountPattern;
    static double castOnCount;

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
                    GetStitchesCount();
                    GetRowsCount();
                    GetWidth();
                    GetLength();

                    GaugeCalculations();

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                case "2": // Calculate new Cast-On stitches

                    Console.WriteLine("You have selected: Calculate new Cast-On stitches.");
                    InOrCm();
                    GetStitchesCountPerMeasurement();
                    GetStitchesCountPerMeasurementPattern();
                    // GetCastOnCountPattern();

                    //  CastOnCalculations();

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

    #region Input Methods
    public static void InOrCm()
    {
        do
        {
            Console.WriteLine("Which measurement system do you use - Imperial or Metric? Type 'in' or 'cm'");
            string? readResult = Console.ReadLine();

            if (readResult != null)
            {
                measureSystem = readResult.ToLower();
                if (measureSystem == "in")
                {
                    Console.WriteLine("You selected: Imperial (in)");
                    validEntry = true;
                }
                else if (measureSystem == "cm")
                {
                    Console.WriteLine("You selected: Metric (cm)");
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

    public static void GetWidth()
    {
        do
        {
            Console.WriteLine($"What is the width of your piece - {measureSystem}?");
            string? input = Console.ReadLine(); // Read user input

            // Use TryParse to validate and convert the input
            if (double.TryParse(input, out width) && width > 0)
            {
                validEntry = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetLength()
    {
        do
        {
            Console.WriteLine($"What is the length of your piece - {measureSystem}?");
            string? input = Console.ReadLine();

            if (double.TryParse(input, out length) && length > 0)
            {
                validEntry = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetStitchesCountPerMeasurement()
    {
        do
        {
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "How many stitches do you have per 4 inches?";
            }
            else
            {
                prompt = "How many stitches do you have per 10 cm?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, out stitchesPerMeasure) && stitchesPerMeasure > 0)
            {
                validEntry = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetStitchesCountPerMeasurementPattern()
    {
         {
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "How many stitches pattern asks to have per 4 inches?";
            }
            else
            {
                prompt = "How many stitches pattern asks to have per 10 cm?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, out stitchesPerMeasurePattern) && stitchesPerMeasurePattern > 0)
            {
                validEntry = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
                validEntry = false;
            }
        } while (!validEntry);
    }



    
    public static void GetCastOnCountPattern()
    {
        do
        {
            Console.WriteLine($"How many Cast-on stitches pattern asks for?");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out castOnCountPattern) && castOnCountPattern > 0)
            {
                validEntry = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a whole positive number!");
                validEntry = false;
            }
        } while (!validEntry);
    }


    #endregion

    #region Outputs
    public static void GaugeCalculations()
    {
        double stitchesPerUnit, rowsPerUnit;

        // Check the measurement system and perform calculations accordingly
        if (measureSystem == "cm")
        {
            stitchesPerUnit = stitchesCount / width;
            rowsPerUnit = rowsCount / length;
        }
        else
        {
            double cmToInch = 2.54;
            width = width / cmToInch;
            length = length / cmToInch;
            stitchesPerUnit = stitchesCount / width;
            rowsPerUnit = rowsCount / length;
        }


        // Display results for cm or inch depending on the selected system
        Console.WriteLine("Results. If needed, round up accordingly to pattern.");
        Console.WriteLine("----------------------------------------------------");

        // Display stitches per unit (cm or inch)
        Console.WriteLine($"Stitches per cm = {stitchesPerUnit:F2}");
        Console.WriteLine($"Rows per cm = {rowsPerUnit:F2}");
        Console.WriteLine();

        // Calculate for 10 cm or 10 inches
        Console.WriteLine($"Stitches per 10 cm = {stitchesPerUnit * 10:F2}");
        Console.WriteLine($"Rows per 10 cm = {rowsPerUnit * 10:F2}");
        Console.WriteLine();

        // Calculate for 1 inch or 1 cm
        double stitchesPerInch = stitchesPerUnit * (measureSystem == "cm" ? 2.54 : 1);
        double rowsPerInch = rowsPerUnit * (measureSystem == "cm" ? 2.54 : 1);
        Console.WriteLine($"Stitches per inch = {stitchesPerInch:F2}");
        Console.WriteLine($"Rows per inch = {rowsPerInch:F2}");
        Console.WriteLine();

        // Calculate for 4 inches or 4 cm
        Console.WriteLine($"Stitches per 4 inch = {stitchesPerInch * 4:F2}");
        Console.WriteLine($"Rows per 4 inch = {rowsPerInch * 4:F2}");

    }


/* 
    static double stitchesPerMeasure;
    static double stitchesPerMeasurePattern;
    static int castOnCountPattern;
    result: static double castOnCount;*/
    public static void CastOnCalculations()
    {

         double stitchesPerUnit, rowsPerUnit;

        // Check the measurement system and perform calculations accordingly
        if (measureSystem == "cm")
        {
            stitchesPerUnit = stitchesCount / width;
            rowsPerUnit = rowsCount / length;
        }
        else
        {
            double cmToInch = 2.54;
            width = width / cmToInch;
            length = length / cmToInch;
            stitchesPerUnit = stitchesCount / width;
            rowsPerUnit = rowsCount / length;
        }

        Console.WriteLine("Results. If needed, round up accordingly to pattern.");
        Console.WriteLine("----------------------------------------------------");

        Console.WriteLine($"New count of Cast-on stitches: {castOnCount}");

    }
    #endregion
}