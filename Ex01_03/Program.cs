using System;
using System.Text;

namespace Ex01_03
{ 
    public class Program
    {
        public static void Main()
        {
            printDiamondWithCustomizeHeight();
        }

        private static void printDiamondWithCustomizeHeight()
        {
            int diamondHeight = getValidDiamondHeightInput();

            Ex01_02.Program.PrintDiamondRhombus(diamondHeight);
        }

        private static int getValidDiamondHeightInput()
        {
            string stringNumberRaw;
            bool isSuccessParseString;

            Console.Write("Please enter the desire diamond height(non negative integer) and press enter:");
            stringNumberRaw = Console.ReadLine();
            isSuccessParseString = int.TryParse(stringNumberRaw, out int o_diamondHeight);
            while (!isSuccessParseString || o_diamondHeight < 0)
            {
                Console.Write("invalid height-must be non negative integer ,try again and press enter:");
                stringNumberRaw = Console.ReadLine();
                isSuccessParseString = int.TryParse(stringNumberRaw, out o_diamondHeight);
            }

            if (o_diamondHeight % 2 == 0)
            {
                o_diamondHeight++;
            }

            return o_diamondHeight;
        }
    }
}
