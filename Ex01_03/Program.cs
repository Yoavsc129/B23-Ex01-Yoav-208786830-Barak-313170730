using System;
using System.Text;

namespace Ex01_03
{ 
    public class Program
    {
        public static void Main()
        {
            PrintDiamondWithCustomizeHeight();
        }

        private static void PrintDiamondWithCustomizeHeight()
        {
            int diamondHeight = getValidDiamondHeightInput();

            Ex01_02.Program.PrintDiamondRhombus(diamondHeight);
        }

        private static int getValidDiamondHeightInput()
        {
            System.Console.Write("Please enter the desire diamond height(non negative integer) and press enter:");
            string stringNumberRaw = System.Console.ReadLine();
            bool isSuccessParseString = int.TryParse(stringNumberRaw, out int o_diamondHeight);
            while (!isSuccessParseString || o_diamondHeight < 0)
            {
                System.Console.Write("invalid non negative height number,try again and press enter:");
                stringNumberRaw = System.Console.ReadLine();
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
