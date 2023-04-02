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

        public static void PrintDiamondWithCustomizeHeight()
        {
            Console.ReadKey();
        
            System.Console.Write("Please enter the desire diamond height and press enter:");
            string stringNumberRaw = System.Console.ReadLine();
            bool isSuccessParseString = int.TryParse(stringNumberRaw, out int o_diamondHeight);
            while(!isSuccessParseString)
            {
                System.Console.Write("invalid height number,try again and press enter:");
                stringNumberRaw = System.Console.ReadLine();
                isSuccessParseString = int.TryParse(stringNumberRaw, out o_diamondHeight);
            }

            if (o_diamondHeight % 2 == 0)
            {
                o_diamondHeight++;
            }

            Ex01_02.Program.PrintDiamondRhombus(o_diamondHeight);
        }
    }
}
