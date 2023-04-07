using System;
using System.Globalization;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            runStringAnalysis();
        }

        private static void runStringAnalysis()
        {
            string userInput = string.Empty;
            StringBuilder stringAnalysis = new StringBuilder();

            Console.WriteLine("Please enter a string of either 6 digits or 6 letters:");
            userInput = getValidSixCharStringInputOfLetterOrNumbersOnlyFromUser();
            stringAnalysis.Append("Is the string a palindrome? ").Append(checkIfStringIsPalindrome(userInput)).Append(Environment.NewLine);
            if(int.TryParse(userInput, out int parsedInteger))
            {
                stringAnalysis.Append("Is the number divisible by 3? ").Append(checkIfDivisibleBy3(parsedInteger)).Append(Environment.NewLine);
            }
            else
            {
                stringAnalysis.Append("The Number of uppercase letters is: ").Append(countUppercaseLetters(userInput)).Append(Environment.NewLine);
            }

            Console.WriteLine(stringAnalysis);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static string getValidSixCharStringInputOfLetterOrNumbersOnlyFromUser()
        {
            bool isInvalidInputLettersOnlyOrNumbersOnly = false;
            string userInput = string.Empty;

            while (!isInvalidInputLettersOnlyOrNumbersOnly)
            {
                userInput = Console.ReadLine();
                isInvalidInputLettersOnlyOrNumbersOnly = checkIfUserInputIsNumberOnlyOrLetterOnly(userInput);
                if(!isInvalidInputLettersOnlyOrNumbersOnly)
                {
                    Console.WriteLine("The input you entered is invalid. Please try again.");
                }
            }
            
            return userInput;
        }

        private static bool checkIfUserInputIsNumberOnlyOrLetterOnly(string i_UserInput, int i_ValidStringLength = 6)
        {
            bool isLetter = char.IsLetter(i_UserInput[0]);
            bool isValidInput = char.IsLetterOrDigit(i_UserInput[0]) && i_UserInput.Length == i_ValidStringLength;

            for (int i = 1; i < i_UserInput.Length && isValidInput; i++)
            {
                if((!isLetter && !char.IsDigit(i_UserInput[i])) || (isLetter && !char.IsLetter(i_UserInput[i])))
                {
                    isValidInput = false;
                }
            }

            return isValidInput;
        }

        private static bool checkIfStringIsPalindrome(string i_UserInput)
        {
            bool isPalindrome;

            if(i_UserInput.Length < 2)
            {
                isPalindrome = true;
            }
            else
            {
                isPalindrome = (i_UserInput[0] == i_UserInput[i_UserInput.Length - 1])
                               && checkIfStringIsPalindrome(i_UserInput.Substring(1, i_UserInput.Length - 2));
            }

            return isPalindrome;
        }

        private static bool checkIfDivisibleBy3(int i_UserInput)
        {
            return i_UserInput % 3 == 0;
        }

        private static int countUppercaseLetters(string i_UserInput)
        {
            int uppercaseCount = 0;

            for(int i = 0; i < i_UserInput.Length; i++)
            {
                if (char.IsUpper(i_UserInput[i]))
                {
                    uppercaseCount++;
                }
            }

            return uppercaseCount;
        }
    }
}
