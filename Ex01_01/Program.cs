using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        private const int k_NumOfInputNumbers = 3;
        private const int k_BaseBinary = 2;
        private const int k_RequireBinaryNumberLength = 8;

        public static void Main()
        {
            runBinaryCheckOnInputNumberFromUser();
        }

        private static void runBinaryCheckOnInputNumberFromUser()
        {
            string inputInBinary;
            int numOfZeroes = 0;
            int numOfOnes = 0;
            int numOfDivisibleBy4 = 0;
            int numOfDescendingDigits = 0;
            int numOfPalindromes = 0;
            int[] allInputsInDecimal = new int[k_NumOfInputNumbers];
            string stringOfNumbers = string.Empty;

            Console.WriteLine($"Please enter {k_NumOfInputNumbers} binary numbers with {k_RequireBinaryNumberLength} digits each:");
            for(int i = 0; i < k_NumOfInputNumbers; i++)
            {
                inputInBinary = getValidIntegerInputFromUser(out int inputInDecimal);
                countZeroesAndOnesInBinaryNumber(inputInBinary, ref numOfZeroes, ref numOfOnes);
                checkIfDivisibleByFour(inputInDecimal, ref numOfDivisibleBy4);
                checkIfDigitsAreDescending(inputInDecimal, ref numOfDescendingDigits);
                checkIfNumberIsPalindrome(inputInDecimal, ref numOfPalindromes);
                allInputsInDecimal[i] = inputInDecimal;
            }

            sortArrayOfIntegersUsingBobbleSort(ref allInputsInDecimal);
             stringOfNumbers = createRowStringFrom3NumberInIntegerArray(allInputsInDecimal);
            printResultToConsole(
                stringOfNumbers, 
                (float)numOfZeroes / k_NumOfInputNumbers,
                (float)numOfOnes / k_NumOfInputNumbers,
                numOfDivisibleBy4,
                numOfDescendingDigits,
                numOfPalindromes);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static void printResultToConsole(
            string i_NumberString,
            float i_AverageNumberOfZeros,
            float i_AverageNumberOfOnes,
            int i_NumOfDivisibleBy4,
            int i_NumOfDescendingDigits,
            int i_NumOfPalindromes)
        {
            string resultMassageToUser = string.Format(
                                             @"The decimal numbers are {0}
The average number of zeroes in a binary number is {1}
The average number of ones in a binary number is {2}
there are {3} numbers which are dividable by 4
there are {4} numbers whose digits are in a descending order
there are {5} numbers whose digits make a palindrome",
                                             i_NumberString,
                                             i_AverageNumberOfZeros,
                                             i_AverageNumberOfOnes,
                                             i_NumOfDivisibleBy4,
                                             i_NumOfDescendingDigits, 
                                             i_NumOfPalindromes);
            Console.WriteLine(resultMassageToUser);
        }

        private static string getValidIntegerInputFromUser(out int o_DecimalNumber)
        {
            bool isInvalidInput = false;
            string userInput = string.Empty;

            o_DecimalNumber = 0;
            while (!isInvalidInput)
            {
                userInput = Console.ReadLine();
                isInvalidInput = checkAndConvertToDecimalIfBinaryNumber(userInput, out o_DecimalNumber);
                if(!isInvalidInput)
                {
                    Console.WriteLine("The input you entered is invalid. Please try again.");
                }
            }

            return userInput;
        }

        private static bool checkAndConvertToDecimalIfBinaryNumber(string i_UserInput, out int o_DecimalNumber)
        {
            int stringInputLength = i_UserInput.Length;
            bool isValidBinaryStringInput = stringInputLength == k_RequireBinaryNumberLength;

            o_DecimalNumber = 0;
            for (int i = stringInputLength - 1; i >= 0 && isValidBinaryStringInput; i--)
            {
                isValidBinaryStringInput = i_UserInput[i] == '1' || i_UserInput[i] == '0';
                if(isValidBinaryStringInput)
                {
                    o_DecimalNumber += int.Parse(i_UserInput[i].ToString()) * (int)Math.Pow(k_BaseBinary, stringInputLength - i - 1);
                }
            }

            return isValidBinaryStringInput;
        }

        private static void countZeroesAndOnesInBinaryNumber(string i_BinaryNumber, ref int i_NumOfZeroes, ref int i_NumOfOnes)
        {
            for(int i = 0; i < i_BinaryNumber.Length; i++)
            {
                if(i_BinaryNumber[i] == '0')
                {
                    i_NumOfZeroes++;
                }
                else if(i_BinaryNumber[i] == '1')
                {
                    i_NumOfOnes++;
                }
            }
        }

        private static void checkIfDivisibleByFour(int i_DecimalNumber, ref int i_NumOfDivisibleBy4)
        {
            if(i_DecimalNumber % 4 == 0)
            {
                i_NumOfDivisibleBy4++;
            }
        }

        private static void checkIfDigitsAreDescending(int i_DecimalNumber, ref int i_NumOfDescendingDigits)
        {
            string decimalNumberAsString = i_DecimalNumber.ToString();
            char currentDigit = decimalNumberAsString[0];
            bool isDescending = true;

            for (int i = 1; i < decimalNumberAsString.Length && isDescending; i++)
            {
                isDescending = currentDigit > decimalNumberAsString[i];
                currentDigit = decimalNumberAsString[i];
            }

            if (isDescending)
            {
                i_NumOfDescendingDigits += 1;
            }
        }

        private static void checkIfNumberIsPalindrome(int i_DecimalNumber, ref int i_NumOfPalindromes)
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
                i_NumOfPalindromes += 1;
            }
        }

        private static void sortArrayOfIntegersUsingBobbleSort(ref int[] i_Array)
        {
            for(int i = 0; i < i_Array.Length - 1; i++)
            {
                for(int j = 0; j < i_Array.Length - i - 1; j++)
                {
                    if(i_Array[j] < i_Array[j + 1])
                    {
                        int temp = i_Array[j];
                        i_Array[j] = i_Array[j + 1];
                        i_Array[j + 1] = temp;
                    }
                }
            }
        }

        private static string createRowStringFrom3NumberInIntegerArray(int[] i_Integers)
        {
            StringBuilder stringOfNumbers = new StringBuilder();

            stringOfNumbers.AppendFormat("{0} {1} {2}", i_Integers[0], i_Integers[1], i_Integers[2]);

            return stringOfNumbers.ToString();
        }
    }
}
