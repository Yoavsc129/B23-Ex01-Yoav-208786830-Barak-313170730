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
            string userInput=string.Empty;
            StringBuilder stringAnalysis = new StringBuilder();

            Console.WriteLine("Please enter a string of either 6 digits or 6 letters:");
            userInput = getValidSixCharStringInputOfLetterOrNumbersOnlyFromUser();
            stringAnalysis.Append("Is the string a palindrome? ").Append(checkIfStringIsPalindrome(userInput)).Append(Environment.NewLine);
            if(int.TryParse(userInput, out int parsedInteger))
            {
                stringAnalysis.Append("Is the number divisible by 3? ").Append(checkIfDivisableBy3(parsedInteger)).Append(Environment.NewLine);
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
            bool isInvalidInputLettersOnlyOrNumbersOnly= true;
            string userInput = string.Empty;

            while (isInvalidInputLettersOnlyOrNumbersOnly)
            {
                userInput = Console.ReadLine();
                if (checkUserInput(userInput))
                {
                    isInvalidInputLettersOnlyOrNumbersOnly = false;
                }
                else
                {
                    Console.WriteLine("The input you entered is invalid. Please try again.");
                }
            }
            
            return userInput;
        }

        private static bool checkUserInput(string i_UserInput, int i_ValidStringLength = 6)
        {
            bool isValidInput = true;
            bool isLetter = char.IsLetter(i_UserInput[0]);

            if (!char.IsLetterOrDigit(i_UserInput[0]) || i_UserInput.Length != i_ValidStringLength)
            {
                isValidInput = false;
            }

            for(int i = 1; i < i_UserInput.Length && isValidInput; i++)
            {
                if((!isLetter && !char.IsDigit(i_UserInput[i])) || (isLetter && !char.IsLetter(i_UserInput[i])))
                {
                    isValidInput = false;
                }
            }

            return isValidInput;
        }

        private static bool checkIfStringIsPalindrome(string i_userInput)
        {
            bool isPalindrome;

            if(i_userInput.Length < 2)
            {
                isPalindrome = true;
            }
            else
            {
                isPalindrome = (i_userInput[0] == i_userInput[i_userInput.Length - 1])
                               && checkIfStringIsPalindrome(i_userInput.Substring(1, i_userInput.Length - 2));
            }

            return isPalindrome;
        }

        private static bool checkIfDivisableBy3(int i_userInput)
        {
            return i_userInput % 3 == 0;
        }

        private static int countUppercaseLetters(string i_userInput)
        {
            int uppercaseCount = 0;

            for(int i = 0; i < i_userInput.Length; i++)
            {
                if (char.IsUpper(i_userInput[i]))
                {
                    uppercaseCount++;
                }
            }

            return uppercaseCount;
        }
    }
}
