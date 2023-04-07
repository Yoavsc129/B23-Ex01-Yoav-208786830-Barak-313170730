using System;
using System.Text;

namespace Ex01_02
{ 
    public class Program
    {
        private const int k_DimaondHeight = 9;
        private const int k_StaringNumberOfStars = 1;
        private const char k_DiamondFillerChar = ' ';
        private const char k_DiamondCharSign = '*';

        public static void Main()
        {
            PrintDiamondRhombus(k_DimaondHeight);
        }

        public static void PrintDiamondRhombus(int i_RhombusHeight)
        {
            printDiamondRhombusHelperRecursive(i_RhombusHeight, k_StaringNumberOfStars);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static void printDiamondRhombusHelperRecursive(int i_RhombusHeight, int i_NumberOfStar)
        {
            if (i_NumberOfStar > i_RhombusHeight)
            {
                return;
            }

            printOneLineOfTheRhombus(i_RhombusHeight, i_NumberOfStar);
            printDiamondRhombusHelperRecursive(i_RhombusHeight, i_NumberOfStar + 2);
            if(i_NumberOfStar < i_RhombusHeight)
            {
                printOneLineOfTheRhombus(i_RhombusHeight, i_NumberOfStar);
            }
        }

        private static void createStringByCharRepat(char i_CharToRepeat, int i_CharAmount, ref StringBuilder o_OutputString)
        {
            for(int i = 0; i < i_CharAmount; i++)
            {
                o_OutputString.Append(i_CharToRepeat);
            }
        }

        private static void printOneLineOfTheRhombus(int i_LineLength, int i_NumberOfStars)
        {
            int spaceCharBeforeStarsAmount = (i_LineLength - i_NumberOfStars) / 2;
            StringBuilder lineOsStartString = new StringBuilder(i_LineLength);

            createStringByCharRepat(k_DiamondFillerChar, spaceCharBeforeStarsAmount, ref lineOsStartString);
            createStringByCharRepat(k_DiamondCharSign, i_NumberOfStars, ref lineOsStartString);
            Console.WriteLine(lineOsStartString.ToString());
        }
    }
}
