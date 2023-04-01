using System;
using System.Globalization;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            RunStringAnalysis();
        }

        public static void RunStringAnalysis()
        {
            Console.WriteLine("Please enter a string of either 6 digits or 6 letters:");
            string userInput = getInputFromUser();
            StringBuilder stringAnalysis = new StringBuilder();
            stringAnalysis.Append("Is the string a palindrome? ").Append(checkIfPalindrome(userInput)).Append(Environment.NewLine);
            if(int.TryParse(userInput, out int parsedInteger))
            {
                stringAnalysis.Append("Is the number divisable by 3? ").Append(checkIfDivisableBy3(parsedInteger)).Append(Environment.NewLine);
            }
            else
            {
                stringAnalysis.Append("The Number of uppercase letters is: ").Append(countUppercaseLetters(userInput)).Append(Environment.NewLine);
            }

            Console.WriteLine(stringAnalysis);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static string getInputFromUser()
        {
            bool inputIsInvalid = true;
            const string k_InvalidInputMsg = "The input you entered is invalid. Please try again.";
            string userInput = string.Empty;
            while (inputIsInvalid)
            {
                userInput = Console.ReadLine();
                if (checkUserInput(userInput))
                {
                    inputIsInvalid = false;
                }
                else
                {
                    Console.WriteLine(k_InvalidInputMsg);
                }
            }
            
            return userInput;
        }

        private static bool checkUserInput(string i_userInput, int i_ValidStringLength = 6)
        {
            bool isValidInput = true;
            bool isLetter = char.IsLetter(i_userInput[0]);
            if (!char.IsLetterOrDigit(i_userInput[0]) || i_userInput.Length != i_ValidStringLength)
            {
                isValidInput = false;
            }

            for(int i = 1; i < i_userInput.Length && isValidInput; i++)
            {
                if((!isLetter && !char.IsDigit(i_userInput[i])) || (isLetter && !char.IsLetter(i_userInput[i])))
                {
                    isValidInput = false;
                }
            }

            return isValidInput;
        }

        private static bool checkIfPalindrome(string i_userInput)
        {
            bool isPalindrome;

            if(i_userInput.Length < 2)
            {
                isPalindrome = true;
            }
            else
            {
                isPalindrome = (i_userInput[0] == i_userInput[i_userInput.Length - 1]) && checkIfPalindrome(i_userInput.Substring(1, i_userInput.Length - 2));
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
