using System.Diagnostics.CodeAnalysis;

namespace Number_to_binary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //used to keep the user in the loop until they exit with the choice '3'
            while (true)
            {
                //asks the user what they want to do
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1 to convert decimal to binary");
                Console.WriteLine("2 to convert binary to a decimal");
                Console.WriteLine("3 to exit");
                //stores user input in the 'userChoice' string
                string userChoice = Console.ReadLine();
                Console.Clear();
                //acts according to the value in 'userChoice' executing the correct code
                switch (userChoice)
                {
                    case "1":
                        DecimalToBinaryConversion();
                        break;
                    case "2":
                        BinaryToDecimalConversion();
                        break;
                    case "3":
                        //exits the program
                        Environment.Exit(0);
                        break;
                    default:
                        //clears the text to display an error in case of invalid input
                        Console.Clear();
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                //this method is called when the user inputs '1'
                //this method converts decimal to binary
                static void DecimalToBinaryConversion()
                {
                    //used to check if user input is in correct format
                    bool isValidInput = false;
                    //this do-while loop makes sure the program doesn't close in case of a wrong input
                    do
                    {
                        Console.Write("Enter a decimal number: ");
                        string decimalInput = Console.ReadLine();
                        try
                        {
                            int decimalNumber = int.Parse(decimalInput);
                            string binaryNumber = DecimalToBinary(decimalNumber);
                            Console.Clear();
                            Console.WriteLine($"Binary representation of the number {decimalInput}: {binaryNumber}");
                            //changes the boolean to true so the program exits the loop
                            isValidInput = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                        }
                        //keeps looping until user gives valid input
                    } while (!isValidInput);
                }

                //this method is called when the user inputs '2'
                //this method does everything virtually the same as the previous method, except this one is used for converting binary to decimal
                static void BinaryToDecimalConversion()
                {
                    bool isValidInput = false;
                    do
                    {

                        Console.Write("Enter a binary number: ");
                        string binaryInput = Console.ReadLine();

                        try
                        {
                            int decimalNumber = BinaryToDecimal(binaryInput);
                            Console.Clear();
                            Console.WriteLine($"Decimal representation of the binary {binaryInput}: {decimalNumber}");
                            isValidInput = true;
                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input. Please enter a valid binary number.");
                        }
                    } while (!isValidInput);
                }
            }

            //this method does the math for the decimal to binary conversion
            static string DecimalToBinary(int decimalNumber)
            {
                //in case user inputs a 0, runs this code(0 in decimal is 0 in binary)
                if (decimalNumber == 0)
                {
                    return "0";
                }
                //this empty string will store the binary
                string binary = "";
                //runs the while loop as long as 'decimalNumber' is greater than 0
                while (decimalNumber > 0)
                {
                    //calculates the remainder when 'decimalNumber' is divided by 2
                    int remainder = decimalNumber % 2;

                    //adds the remainder to the start of the binary string so that it builds the binary from right to left
                    binary = remainder + binary;

                    //divides 'decimalNumber' by 2, so it moves to the right
                    decimalNumber /= 2;
                }
                //the final answer is stored in the 'binary' variable and this returns it
                return binary;
            }


            //this method checks if the input is a valid binary number
            static bool IsBinaryNumber(string input)
            {
                //checks each character in the input string
                foreach (char digit in input)
                {
                    //if the digit is anything different than a '0' or '1' this will return false
                    if (digit != '0' && digit != '1')
                    {
                        return false;
                    }
                }
                return true;
            }


            //this method does the math for the binary to decimal conversion
            static int BinaryToDecimal(string binaryNumber)
            {
                //checks if 'binaryNumber' is valid using the previous(IsBinaryNumber) method
                if (!IsBinaryNumber(binaryNumber))
                {
                    //if the input was invalid, throws this exception
                    throw new FormatException("Invalid binary input.");
                }
                //initializes the 'decimalNumber' variable to store the result of the conversion
                int decimalNumber = 0;
                //sets 'binaryBase' to 2 because it's converting from binary to decimal
                int binaryBase = 2;

                //the loop starts from the rightmost bit and goes towards the leftmost bit
                //'binaryIndex' is the index of the current bit and 'powerOfTwo' is used to determine the position of the bit in the binary number
                for (int binaryIndex = binaryNumber.Length - 1, powerOfTwo = 0; binaryIndex >= 0; binaryIndex--, powerOfTwo++)
                {
                    //'binaryDigit' is assigned the integer value of the current binary digit at position 'binaryIndex'
                    int binaryDigit = int.Parse(binaryNumber[binaryIndex].ToString());
                    //calculates the contribution of the current bit to the decimal number using the formula binaryDigit * 2^powerOfTwo and add it to the decimalNumber.
                    //'powerOfTwo' is added to keep track of the position of the bit in the binary number
                    decimalNumber += binaryDigit * (int)Math.Pow(binaryBase, powerOfTwo);
                }
                //when the loop completes this returns the final 'decimalNumber'
                return decimalNumber;
            }

        }
    }
}