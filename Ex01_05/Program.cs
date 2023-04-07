using System;

namespace Ex01_05
{
   public class Program
    {
        private const int k_RequireNumberInputLength = 6;

        public static void Main()
        {
            getNumberAndPrintStatistics();
        } 

        private static void getNumberAndPrintStatistics()
        {
            string stringNumberRaw = getValidSixDigitIntegerNumberFromUser();
            int smallestDigit = getTheSmallestDigitInTheNumber(stringNumberRaw);
            int countDivideIn3 = countDigitThatDivisibleBy3(stringNumberRaw);
            int countBiggerThenUnitPlace = countDigitThatBiggerThenUnitPlace(stringNumberRaw);
            float digitAverage = calculateAllDigitAverage(stringNumberRaw);

            Console.WriteLine(
                $@"Number Statistic:
        number of digit that bigger then unit place: {countBiggerThenUnitPlace}
        the smallest digit: {smallestDigit}
        the number is digits that divide by 3: {countDivideIn3}
        the average of the number digits: {digitAverage}");
        Console.WriteLine("Please press 'Enter' to exit...");
        Console.ReadLine();
        }

        private static int getTheSmallestDigitInTheNumber(string i_NumberAsString)
        {
            int currentDigit;
            string currentDigitString;
            int smallestDigit = int.Parse(i_NumberAsString[0].ToString());

            for (int i = 1; i < i_NumberAsString.Length; i++)
            {
                currentDigitString = i_NumberAsString[i].ToString();
                currentDigit = int.Parse(currentDigitString);
                smallestDigit = Math.Min(smallestDigit, currentDigit);
            }

            return smallestDigit;
        }

        private static int countDigitThatDivisibleBy3(string i_NumberAsString)
        {
            string currentDigitString;
            int countDivisibleBy3 = 0;
      
            for (int i = 0; i < i_NumberAsString.Length; i++)
            {
                currentDigitString = i_NumberAsString[i].ToString();
                if(int.Parse(currentDigitString) % 3 == 0)
                {
                    countDivisibleBy3++;
                }
            }

            return countDivisibleBy3;
        }

        // return -1 if i_NumberAsString is empty string
        private static float calculateAllDigitAverage(string i_NumberAsString)
        {
            string currentDigitString;
            float sumOfDigit = 0;
            float averageDigit = -1;

            for (int i = 0; i < i_NumberAsString.Length; i++)
            {
                currentDigitString = i_NumberAsString[i].ToString();
                sumOfDigit += int.Parse(currentDigitString);
            }

            if(i_NumberAsString.Length != 0)
            {
                averageDigit = sumOfDigit / i_NumberAsString.Length;
            }

            return averageDigit;
        }

        private static int countDigitThatBiggerThenUnitPlace(string i_NumberAsString)
        {
            string currentDigitString;
            int countBiggerThenUnitPlace = 0;
            int unitPlaceDigit = int.Parse(i_NumberAsString[i_NumberAsString.Length - 1].ToString());

            for (int i = 0; i < i_NumberAsString.Length; i++)
            {
                currentDigitString = i_NumberAsString[i].ToString();
                if (int.Parse(currentDigitString) > unitPlaceDigit)
                {
                    countBiggerThenUnitPlace++;
                }
            }

            return countBiggerThenUnitPlace;
        }

        private static string getValidSixDigitIntegerNumberFromUser()
        {
            string stringNumberRaw;
            string massageToUser = "Please enter a six digit of integer number to run statistics and press enter:";
            int o_numberToCheck;
            bool isInputIsNumber, isSixDigitNumber;

            do
            {
                Console.Write(massageToUser);
                stringNumberRaw = Console.ReadLine();
                isInputIsNumber = int.TryParse(stringNumberRaw, out o_numberToCheck);
                isSixDigitNumber = stringNumberRaw.Length == k_RequireNumberInputLength;
                if (!isInputIsNumber)
                {
                    massageToUser = "invalid integer number,try again and press enter:";
                }
                else if (!isSixDigitNumber)
                {
                    massageToUser = string.Format(
                        "invalid number length-must enter {0} of digit number,try again and press enter:",
                        k_RequireNumberInputLength);
                }
            }
            while (!isInputIsNumber || !isSixDigitNumber);

            return stringNumberRaw;
        }
    }
}
