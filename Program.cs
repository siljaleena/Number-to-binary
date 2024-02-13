namespace Number_to_binary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //used to check if user input is in correct format
            bool isValidInput = false;

            //does a do-while loop in case user inputs in wrong format, so the program doesn't shut down
            do
            {
                //asks for user input and stores it in the string 'userInput'
                Console.Write("Enter a decimal number: ");
                string userInput = Console.ReadLine();

                try
                {
                    //Converts 'userInput' into an integer and then converts it to binary
                    int decimalNumber = int.Parse(userInput);
                    string binaryNumber = DecimalToBinary(decimalNumber);
                    Console.WriteLine($"Binary representation: {binaryNumber}");
                    isValidInput = true;
                }
                catch (FormatException)
                {
                    //displays error to user for wrong input
                    Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                }
             //keeps looping to the question until user gives valid input
            } while (!isValidInput);
        }

        //converts a decimal number to binary
        static string DecimalToBinary(int decimalNumber)
        {
            //in case user inputs a 0, runs this code(0 in decimal is 0 in binary)
            if (decimalNumber == 0)
            {
                return "0";
            }
            string binary = "";
            while (decimalNumber > 0) //runs the while loop until 'decimalNumber' becomes 0
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
    } 
}
    




