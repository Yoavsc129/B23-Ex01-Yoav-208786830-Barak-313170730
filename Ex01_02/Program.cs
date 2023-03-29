using System;
using System.Text;

namespace Ex01_02
{ 
    public class Program
    {
        public static void Main()
        {
            PrintDiamondRhombus(9);
        }

        public static void PrintDiamondRhombus(int i_RhombusHeight)
        {
            int staringNumberOfStars = 1;
            printDiamondRhombusHelperRecursive(i_RhombusHeight, staringNumberOfStars);

        }

        private static void printDiamondRhombusHelperRecursive(int i_RhombusHeight,int  i_NumberOfStar)
        {
            if (i_NumberOfStar > i_RhombusHeight  )
            {
                return;
            }

            int lineCharWroteCounter = 0;
            printOneLineOfRhombus(i_RhombusHeight, i_NumberOfStar,ref lineCharWroteCounter);
            printDiamondRhombusHelperRecursive(i_RhombusHeight, i_NumberOfStar + 2);
            if(i_NumberOfStar < i_RhombusHeight)
            {
                printOneLineOfRhombus(i_RhombusHeight, i_NumberOfStar, ref lineCharWroteCounter);

            }
        }

        private static void printOneLineOfRhombus(int i_LineLength, int i_NumberOfStars,ref int io_CharWroteCounter)
        {
            int spaceCharBeforeStarsAmount = (i_LineLength - i_NumberOfStars) / 2;
            
            if (spaceCharBeforeStarsAmount == (i_LineLength - io_CharWroteCounter) && io_CharWroteCounter != 0)
            {
                io_CharWroteCounter = 0;
                System.Console.Write(Environment.NewLine);
                return;
            }

            
            if (spaceCharBeforeStarsAmount > io_CharWroteCounter)
            {
                System.Console.Write(' ');
            }
            else if(spaceCharBeforeStarsAmount +i_NumberOfStars> io_CharWroteCounter)
            {
                System.Console.Write('*');
            }
            io_CharWroteCounter++;
            printOneLineOfRhombus(i_LineLength, i_NumberOfStars, ref io_CharWroteCounter);


        }
    }
}
