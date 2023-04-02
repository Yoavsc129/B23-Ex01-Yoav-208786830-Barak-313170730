using System;

namespace Ex01_05
{
   public class Program
    {
        public static void Main()
        {
            getNumberAndCheckStatistics();
        } 

        private static void getNumberAndCheckStatistics()
        {
            string stringNumberRaw;
            int smallestDigit = 10;
            int countDivideIn3 = 0;
            int countBiggerThenUnitPlace = 0;
            int sumAllDigit = 0;
            bool isInputIsNumber, isSixDigitNumber;
            string massageToUser = "Please enter a six digit of integer number to run statistics and press enter:";
            int o_numberToCheck;
            const int reqireNumberInputLength = 6;

            do
            {
                System.Console.Write(massageToUser);
                stringNumberRaw = System.Console.ReadLine();
                isInputIsNumber = int.TryParse(stringNumberRaw, out o_numberToCheck);
                isSixDigitNumber = stringNumberRaw.Length == reqireNumberInputLength;
                if(!isInputIsNumber)
                {
                    massageToUser = "invalid integer number,try again and press enter:";
                }
                else if(!isSixDigitNumber)
                {
                    massageToUser = string.Format(
                        "invalid number length-must enter {0} of digit number,try again and press enter:",
                        reqireNumberInputLength);
                }
            }
            while(!isInputIsNumber || !isSixDigitNumber);

            int digitAmount = stringNumberRaw.Length;
            string unitDigitRaw = stringNumberRaw.Substring(stringNumberRaw.Length - 1);
            int.TryParse(unitDigitRaw, out int unitDigit);

            for(int i = 0; i < digitAmount; i++)
            {
                string currentDigitString = stringNumberRaw[i].ToString();
                int.TryParse(currentDigitString, out int currentDigit);
                sumAllDigit += currentDigit;
                if(currentDigit % 3 == 0)
                {
                    countDivideIn3++;
                }

                smallestDigit = Math.Min(smallestDigit, currentDigit);

                if (currentDigit > unitDigit)
                {
                    countBiggerThenUnitPlace++;
                }
            }

            System.Console.WriteLine(
                $@"Number Statistic:
        number of digit that bigger then unit place: {countBiggerThenUnitPlace}
        the smallest digit: {smallestDigit}
        the number is digits that divide in 3 :{countDivideIn3}
        the average of the number digits: {sumAllDigit / digitAmount}"); 

        Console.WriteLine("Please press 'Enter' to exit...");
        Console.ReadLine();
        }
    }
}
