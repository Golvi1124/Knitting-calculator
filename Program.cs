namespace Knitting_calculator;

class Program
{
    // Shared across methods
    static string measureSystem = "";
    static bool validEntry = false;
    static string? input;
    static int stitchesCount, rowsCount, castOnCountPattern, lengthPerSkein, stitchesPerMeasurePattern, weightPerSkein, desiredWidth, desiredLength, numberOfFrogged, desiredRowCount, desiredStitchesCount;
    static double width, length, stitchesPerMeasure, newCastOnCount, weightOfProject, lengthOfFrogged, skeinsAmount;

    static void Main(string[] args)
    {
        string menuSelection = ""; // support data entry

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
            }

            switch (menuSelection)
            {
                case "1": // Gauge calculator

                    Yellow("You have selected: Gauge calculator.");
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

                    Yellow("You have selected: Calculate new Cast-On stitches.");
                    InOrCm();
                    GetStitchesCountPerMeasurement();
                    GetStitchesCountPerMeasurementPattern();
                    GetCastOnCountPattern();

                    CastOnCalculations();

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                case "3": // How much yarn would you need based on: stitch length 
                    Yellow("You have selected: How much yarn would you need based on stitch length.");
                    InOrCm();
                    GetLengthPerSkein();
                    GetWeightPerSkein();
                    GetNumberOfFrogged();
                    GetLengthOfFrogged();
                    GetDesiredRowCount();
                    GetDesiredStitchesCount();

                    HowMuchYarnPerStitches();

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                case "4": // How much yarn would you need based on: weight of product 

                    Yellow("You have selected: How much yarn would you need based on weight of product.");
                    InOrCm();
                    GetLengthPerSkein();
                    GetWeightPerSkein();
                    GetProjectWeight();

                    HowMuchYarnPerWeight();

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;

                case "5": // Blanket size calculator 

                    Yellow("You have selected: Blanket size calculator.");
                    InOrCm();
                    GetStitchesCount();
                    GetRowsCount();
                    GetWidth();
                    GetLength();
                    GetDesiredWidth();
                    GetDesiredLength();

                    BlanketCalculations();

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    input = Console.ReadLine();
                    break;
                
                 case "exit":
                    break; // Exit the switch statement immediately

                default:
                    Magenta("Invalid input! Please enter a number between 1 and 5!");
                    Console.WriteLine("\nPress the Enter key to try again...");
                    Console.ReadLine();
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
                    Yellow("You selected: Imperial (in)");
                    validEntry = true;
                }
                else if (measureSystem == "cm")
                {
                    Yellow("You selected: Metric (cm)");
                    validEntry = true;
                }
                else
                {
                    Magenta($" \"{measureSystem}\" is invalid input!");
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
            string? input = Console.ReadLine();

            if (int.TryParse(input, out stitchesCount) && stitchesCount > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive whole number.");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetRowsCount()
    {
        do
        {
            Console.WriteLine("How many rows have you made?");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out rowsCount) && rowsCount > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive whole number.");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetWidth()
    {
        do
        {
            Console.WriteLine($"What is the width of your piece - {measureSystem}?");
            string? input = Console.ReadLine();

            if (double.TryParse(input, out width) && width > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
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
                Magenta("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
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
            else //(measureSystem == "cm")
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
                Magenta("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetStitchesCountPerMeasurementPattern()
    {
        do
        {
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "How many stitches pattern asks to have per 4 inches?";
            }
            else //(measureSystem == "cm")
            {
                prompt = "How many stitches pattern asks to have per 10 cm?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out stitchesPerMeasurePattern) && stitchesPerMeasurePattern > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive whole number!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetCastOnCountPattern()
    {
        do
        {
            Console.WriteLine("How many Cast-on stitches pattern asks for?");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out castOnCountPattern) && castOnCountPattern > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a whole positive number!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetLengthPerSkein()
    {
        do
        {
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "Check the label of your yarn. How many yards are in one skein?";
            }
            else //(measureSystem == "cm")
            {
                prompt = "Check the label of your yarn. How many meters are in one skein?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out lengthPerSkein) && lengthPerSkein > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive whole number!");
                validEntry = false;
            }
        } while (!validEntry);

    }
    
    public static void GetWeightPerSkein()
    {
        do
        {
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "Check the label of your yarn. How many ounces does it weight?";
            }
            else //(measureSystem == "cm")
            {
                prompt = "Check the label of your yarn. How many grams does it weight?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out weightPerSkein) && weightPerSkein > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive whole number!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetProjectWeight()
    {
        do
        {
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "How many ounces does the finished project weight?";
            }
            else //(measureSystem == "cm")
            {
                prompt = "How many grams does the finished project weight?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, out weightOfProject) && weightOfProject > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetDesiredWidth()
    {
        do
        {
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "How wide do you want your blanket to be in inches?";
            }
            else //(measureSystem == "cm")
            {
                prompt = "How wide do you want your blanket to be in centimeters?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out desiredWidth) && desiredWidth > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive whole number!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetDesiredLength()
    {
        do
        {
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "How long do you want your blanket to be in inches?";
            }
            else //(measureSystem == "cm")
            {
                prompt = "How long do you want your blanket to be in centimeters?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out desiredLength) && desiredLength > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive whole number!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetLengthOfFrogged()
    {
        do
        {
            Console.WriteLine("Cut tread. Frogg(un-do) all made stithces, measure.");
            string prompt;

            if (measureSystem == "in")
            {
                prompt = "What is the length in inches of yarn tread from frogged stithes?";
            }
            else //(measureSystem == "cm")
            {
                prompt = "What is the length in centimetres of yarn tread from frogged stithes?";
            }

            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, out lengthOfFrogged) && lengthOfFrogged > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive number and/or use ',' instead of '.'!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetNumberOfFrogged()
    {
        Console.WriteLine("Make any amount of stithes (at least 10).");
        do
        {
            Console.WriteLine("What is the amount of stitches you made?");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out numberOfFrogged) && numberOfFrogged > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a positive whole number!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetDesiredRowCount()
    {
        do
        {
            Console.WriteLine("How many rows are you planning to make?");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out desiredRowCount) && desiredRowCount > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a whole positive number!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    public static void GetDesiredStitchesCount()
    {
        do
        {
            Console.WriteLine("How many stithes per row/round are you planning to make?");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out desiredStitchesCount) && desiredStitchesCount > 0)
            {
                validEntry = true;
            }
            else
            {
                Magenta("Invalid input. Please enter a whole positive number!");
                validEntry = false;
            }
        } while (!validEntry);
    }

    #endregion
    #region Outputs

    public static void GaugeCalculations()
    {
        double stitchesPerUnit, rowsPerUnit;

        if (measureSystem == "cm")
        {
            stitchesPerUnit = stitchesCount / width;
            rowsPerUnit = rowsCount / length;
        }
        else //(measureSystem == "in")
        {
            double cmToInch = 2.54;
            width = width / cmToInch;
            length = length / cmToInch;
            stitchesPerUnit = stitchesCount / width;
            rowsPerUnit = rowsCount / length;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nResults. If needed, round up accordingly to pattern.");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Stitches per cm = {stitchesPerUnit:F2}");
        Console.WriteLine($"Rows per cm = {rowsPerUnit:F2}");
        Console.WriteLine($"\nStitches per 10 cm = {stitchesPerUnit * 10:F2}");
        Console.WriteLine($"Rows per 10 cm = {rowsPerUnit * 10:F2}");

        double stitchesPerInch = stitchesPerUnit * (measureSystem == "cm" ? 2.54 : 1);
        double rowsPerInch = rowsPerUnit * (measureSystem == "cm" ? 2.54 : 1);
      
        Console.WriteLine($"\nStitches per inch = {stitchesPerInch:F2}");
        Console.WriteLine($"Rows per inch = {rowsPerInch:F2}");
        Console.WriteLine($"\nStitches per 4 inch = {stitchesPerInch * 4:F2}");
        Console.WriteLine($"Rows per 4 inch = {rowsPerInch * 4:F2}");
        Console.ResetColor();
    }

    public static void CastOnCalculations()
    {
        double castOnLength;

        if (measureSystem == "in")
        {
            castOnLength = castOnCountPattern * 4 / stitchesPerMeasurePattern;
            newCastOnCount = stitchesPerMeasure * castOnLength / 4;
        }
        else // (measureSystem == "cm")
        {
            castOnLength = castOnCountPattern * 10 / stitchesPerMeasurePattern;
            newCastOnCount = stitchesPerMeasure * castOnLength / 10;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nResults. If needed, round up accordingly to pattern.");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"New count of Cast-on stitches: {newCastOnCount}. Adjust as needed!");
        Console.ResetColor();
    }

    public static void HowMuchYarnPerWeight()
    {
        double ozOfProject, grOfProject, yardsOfProject, metersOfProject;
        string otherSystem;

        skeinsAmount = weightOfProject / weightPerSkein;

        if (measureSystem == "in")
        {
            yardsOfProject = Math.Round(skeinsAmount * lengthPerSkein, 1);
            metersOfProject = Math.Round(yardsOfProject * 0.9144, 1);
            grOfProject = Math.Round(weightOfProject * 28.349523, 1);
            otherSystem = $"Metric system it would weight {grOfProject} grams.";
        }
        else // (measureSystem == "cm")
        {
            metersOfProject = Math.Round(skeinsAmount * lengthPerSkein, 1);
            yardsOfProject = Math.Round(metersOfProject * 1.093613, 1);
            ozOfProject = Math.Round(weightOfProject * 0.035274, 1);
            otherSystem = $"Imperial system it would weight {ozOfProject} ounces.";
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nResults. To make this project it was required:");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"{metersOfProject} meters of yarn.");
        Console.WriteLine("...or in other measurement system:");
        Console.WriteLine($"{yardsOfProject} yards of yarn.");
        Console.WriteLine($"\nTotal amount of skeins: {skeinsAmount} ");
        Console.WriteLine($"If you are wondering in {otherSystem}"); 
        Console.ResetColor();
    }

    public static void BlanketCalculations()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nResults. To make a blacket:");
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Total stitches needed: {stitchesCount * (desiredWidth / width)}");
        Console.WriteLine($"Total rows needed: {rowsCount * (desiredLength / length)}");
        Console.ResetColor();
    }

    public static void HowMuchYarnPerStitches()
    {
        double lengthOfOneStitch;
        double lengthOfOneRow;
        double totalLength;
        double skeinsAmount;
        double totalBigLength; // For yards or meters
        string measIn;
        string bigMeasIn;
        string weightIn;

        if (measureSystem == "in")
        {
            lengthOfOneStitch = lengthOfFrogged / numberOfFrogged;
            lengthOfOneRow = lengthOfOneStitch * desiredStitchesCount;
            totalLength = lengthOfOneRow * desiredRowCount;
            skeinsAmount = totalLength / (lengthPerSkein * 36);
            totalBigLength = totalLength / 36;
            measIn = "inches";
            bigMeasIn = "yards";
            weightIn = "ounces";
        }
        else //(measureSystem == "cm") 
        {
            lengthOfOneStitch = lengthOfFrogged / numberOfFrogged;
            lengthOfOneRow = lengthOfOneStitch * desiredStitchesCount;
            totalLength = lengthOfOneRow * desiredRowCount;
            skeinsAmount = totalLength / (lengthPerSkein * 100);
            totalBigLength = totalLength / 100;
            measIn = "centimeters";
            bigMeasIn = "meters";
            weightIn = "grams";
        }

        skeinsAmount = Math.Ceiling(skeinsAmount); // Round up to the nearest whole skein

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nResults. Everything you need to know for your project.");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"In total you gonna need {skeinsAmount} skeins of yarn.");
        Console.WriteLine($"Length of yarn used to make 1 stitch: {lengthOfOneStitch:F1} {measIn}");
        Console.WriteLine($"Length of yarn used to make 1 row/round: {lengthOfOneRow:F1} {measIn}");
        Console.WriteLine($"Total approx length of yarn used: {totalLength:F1} {measIn} (or {totalBigLength:F2} {bigMeasIn})");
        Console.WriteLine($"Your finished project will weight approximately {skeinsAmount * weightPerSkein} {weightIn}");
        Console.ResetColor();
    }
    #endregion

    #region Extras
    public static void Yellow(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void Magenta(string text)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    #endregion
}



