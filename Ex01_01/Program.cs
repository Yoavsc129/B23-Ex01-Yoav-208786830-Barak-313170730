using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            RunBinaryCheck();
        }

        public static void RunBinaryCheck()
        {
            const int k_NumOfNumbers = 3;
            string inputInBinary;
            int numOfZeroes = 0;
            int numOfOnes = 0;
            int numOfDivisiablesBy4 = 0;
            int numOfDescendingDigits = 0;
            int numOfPalindromes = 0;
            int[] allInputsInDecimal = new int[3];
            Console.WriteLine("Please enter 3 binary numbers with 8 digits each:");
            for(int i = 0; i < k_NumOfNumbers; i++)
            {
                inputInBinary = getInputFromUser(out int inputInDecimal);
                countZeroesAndOnesInBinaryNumber(inputInBinary, ref numOfZeroes, ref numOfOnes);
                checkIfDivisableByFour(inputInDecimal, ref numOfDivisiablesBy4);
                checkIfDigitsAreDescending(inputInDecimal, ref numOfDescendingDigits);
                checkIfPalindrome(inputInDecimal, ref numOfPalindromes);
                allInputsInDecimal[i] = inputInDecimal;
            }

            sortArrayOfIntegers(ref allInputsInDecimal);
            string stringOfNumbers = addIntegersToString(allInputsInDecimal);
            string msg = string.Format(
@"The decimal numbers are {0}
The avarege number of zeroes in a binary number is {1}
The avarege number of ones in a binary number is {2}
there are {3} numbers which are divisable by 4
there are {4} numbers whose digits are in a descending order
there are {5} numbers whose digits make a palindrome",
                stringOfNumbers,
                (float)numOfZeroes / k_NumOfNumbers,
                (float)numOfOnes / k_NumOfNumbers,
                numOfDivisiablesBy4,
                numOfDescendingDigits,
                numOfPalindromes);
            Console.WriteLine(msg);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static string getInputFromUser(out int o_DecimalNumber)
        {
            bool inputIsInvalid = true;
            const string k_InvalidInputMsg = "The input you entered is invalid. Please try again.";
            string userInput = string.Empty;
            o_DecimalNumber = 0;
            while (inputIsInvalid)
            {
                userInput = Console.ReadLine();
                if (checkAndConvertToDecimalIfBinaryNumber(userInput, out o_DecimalNumber))
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

        private static bool checkAndConvertToDecimalIfBinaryNumber(string i_UserInput, out int o_DecimalNumber)
        {
            const int k_Base = 2;
            int stringLen = i_UserInput.Length;
            bool isValidInput = true;
            o_DecimalNumber = 0;
            if(stringLen != 8)
            {
                isValidInput = false;
            }

            for (int i = stringLen - 1; i >= 0 && isValidInput; i--)
            {
                if(i_UserInput[i] > '1' || i_UserInput[i] < '0')
                {
                    isValidInput = false;
                }
                else
                {
                    o_DecimalNumber += int.Parse(i_UserInput[i].ToString()) * (int)Math.Pow(k_Base, stringLen - i - 1);
                }
            }

            return isValidInput;
        }

        private static void countZeroesAndOnesInBinaryNumber(string i_BinaryNumber, ref int r_NumOfZeroes, ref int r_NumOfOnes)
        {
            for(int i = 0; i < i_BinaryNumber.Length; i++)
            {
                if(i_BinaryNumber[i] == '0')
                {
                    r_NumOfZeroes++;
                }
                else
                {
                    r_NumOfOnes++;
                }
            }
        }

        private static void checkIfDivisableByFour(int i_DecimalNumber, ref int r_NumOfDivisiablesBy4)
        {
            if(i_DecimalNumber % 4 == 0)
            {
                r_NumOfDivisiablesBy4 += 1;
            }
        }

        private static void checkIfDigitsAreDescending(int i_DecimalNumber, ref int r_NumOfDescendingDigits)
        {
            string decimalNumberAsString = i_DecimalNumber.ToString();
            char currentChar = decimalNumberAsString[0];
            bool isDescending = true;
            for (int i = 1; i < decimalNumberAsString.Length && isDescending; i++)
            {
                if(currentChar <= decimalNumberAsString[i])
                {
                    isDescending = false;
                }

                currentChar = decimalNumberAsString[i];
            }

            if (isDescending)
            {
                r_NumOfDescendingDigits += 1;
            }
        }

        private static void checkIfPalindrome(int i_DecimalNumber, ref int r_numOfPalindromes)
        {
            string decimalNumberAsString = i_DecimalNumber.ToString();
            bool isPalindrome = true;
            for(int i = 0; i < decimalNumberAsString.Length / 2 && isPalindrome; i++)
            {
                if(decimalNumberAsString[i] != decimalNumberAsString[decimalNumberAsString.Length - i - 1])
                {
                    isPalindrome = false;
                }
            }

            if (isPalindrome)
            {
                r_numOfPalindromes += 1;
            }
        }

        private static void sortArrayOfIntegers(ref int[] r_array)
        {
            const int k_NumOfNumbers = 3;
            for(int i = 0; i < k_NumOfNumbers - 1; i++)
            {
                for(int j = 0; j < k_NumOfNumbers - i - 1; j++)
                {
                    if(r_array[j] < r_array[j + 1])
                    {
                        int temp = r_array[j];
                        r_array[j] = r_array[j + 1];
                        r_array[j + 1] = temp;
                    }
                }
            }
        }

        private static string addIntegersToString(int[] i_Integers)
        {
            StringBuilder stringOfNumbers = new StringBuilder();
            stringOfNumbers.AppendFormat("{0} {1} {2}", i_Integers[0], i_Integers[1], i_Integers[2]);
            return stringOfNumbers.ToString();
        }
    }
}
