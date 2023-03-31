using System;


namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            GetNumberAndCheckStatistics();
        }
    }

    private static void getNumberAndCheckStatistics()
    {
        System.Console.Write("Please enter a integer number to run statistics and press enter:");
        string stringNumberRaw = System.Console.ReadLine();
        int digitsAverage = 0;
        int smallestDigit = -1;
        int countDivideIn3 = 0;
        int countBiggerThenUnitPlace = 0;
        int sumAllDigit = 0;
        bool isSuccessParseString = int.TryParse(stringNumberRaw, out int o_numberToCheck);
        while (!isSuccessParseString)
        {
            System.Console.Write("invalid integer number,try again and press enter:");
            stringNumberRaw = System.Console.ReadLine();
            isSuccessParseString = int.TryParse(stringNumberRaw, out o_numberToCheck);
        }

        int digitAmount = stringNumberRaw.Length;
        string unitDigitRaw = stringNumberRaw.Substring(stringNumberRaw.Length - 1);
        int.TryParse(unitDigitRaw, out int unitDigit);
        for(int i = 0; i < digitAmount; i++)
        { 
            string currentDigitString= stringNumberRaw[i].ToString();
            int.TryParse(currentDigitString, out int currentDigit);
           sumAllDigit += currentDigit;
           if(currentDigit % 3 == 0)
           {
               countDivideIn3++;
           }
           if(smallestDigit < currentDigit)
           {
               smallestDigit = currentDigit;
           }
           if(currentDigit > unitDigit)
           {
               countBiggerThenUnitPlace++;
           }
        }

        System.Console.WriteLine(
            @"Number Statistic:
            number of digit");

    }
}
