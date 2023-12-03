using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        NumberFromDigits();
        NumberFromString();

    }

    static void NumberFromString()
    {
        //The filepath for the Input file
        string filepath = @"..\..\..\Input2.txt";
        //Variable to store the sum
        int totalSum = 0;

        //Read each line from the file
        foreach (string line in File.ReadAllLines(filepath))
        {

            string processedLine = ReplaceNumberWords(line.ToUpper());

            int firstDigit = ExtractFirstDigit(processedLine);
            int lastDigit = ExtractLastDigit(processedLine);
            totalSum += firstDigit * 10 + lastDigit;


        }
        Console.WriteLine($"The total sum is: {totalSum}");
    }

    // Method to extract the first digit (in word form) from the line and convert it to a numeric value
    static int ExtractFirstDigit(string line)
    {
        // /d searches for any digital character
        var match = Regex.Match(line, @"\d");
        return match.Success ? int.Parse(match.Value) : 0;
    }

    // Method to extract the last digit (in word form) from the line and convert it to a numeric value
    static int ExtractLastDigit(string line)
    {
        //Reverse the array to find the first digit   
        char[] charArray = line.ToCharArray();
        Array.Reverse(charArray);
        string reversedLine = new string(charArray);

        // Use Regex.Match to find the first digit in the reversed string
        var match = Regex.Match(reversedLine, @"\d");
        return match.Success ? int.Parse(match.Value) : 0;
    }

    // Method to replace number words with a unique format
    static string ReplaceNumberWords(string input)
    {
        // Each line replaces a specific number word with a unique format.
        // The format is the first letter of the number word, followed by its numeric value, and then a part of the word.
        // This is done to uniquely identify each number word even in overlapping scenarios.
        input = Regex.Replace(input, "ONE", "ON1E");
        input = Regex.Replace(input, "TWO", "T2WO");
        input = Regex.Replace(input, "THREE", "T3EE");
        input = Regex.Replace(input, "FOUR", "F4UR");
        input = Regex.Replace(input, "FIVE", "F5VE");
        input = Regex.Replace(input, "SIX", "S6IX");
        input = Regex.Replace(input, "SEVEN", "S7EN");
        input = Regex.Replace(input, "EIGHT", "E8HT");
        input = Regex.Replace(input, "NINE", "N9NE");
        return input;
    }


    static void NumberFromDigits()
    {
        //The filepath for the Input file
        string filepath = @"..\..\..\Input.txt";
        //Store the total sum of the digits
        int totalSum = 0;

        //Read each line from the file
        foreach (string line in File.ReadAllLines(filepath))
        {
            int firstDigit = -1, lastDigit = -1;

            //Iterrate through each character in the line to find the first and the last digit
            foreach (char c in line)
            {
                //Check if the character is a digit
                if (char.IsDigit(c))
                {
                    //**********//
                    //Convert character to integer
                    firstDigit = c - '0';
                    break;//stop the loop after finding the first integer
                }
            }
            //Check if the first digit is found, if yes search for the last digit backwards
            if (firstDigit != -1)
            {
                //Itterate backwards through the line to find the last digit
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if ((char.IsDigit(line[i])))//check if the character is digit
                    {
                        //Converts the character to integer
                        lastDigit = line[i] - '0';
                        break;//Stop the loop after finding the last integer
                    }
                }
                //If the lastDigit was not found set the last digit equal with the first one
                if (lastDigit == -1)
                {
                    lastDigit = firstDigit;

                }
                //************//
                //Add the two-digit number formed by firstDigit and lastDigit
                //multiply the first digit by 10. E.g. firstDigit=1, lastDigit=5 => 10+5=15
                totalSum += firstDigit * 10 + lastDigit;
                //Console.WriteLine($"{line}\t number:{firstDigit * 10 + lastDigit} \t totalSum {totalSum} ");
            }


        }
        Console.WriteLine($"The total sum is {totalSum} \n");
    }
}