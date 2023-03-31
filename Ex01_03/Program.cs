using System;
using System.Text;

namespace Ex01_03
{ 
    public class Program
    {
        public static void Main()
        {
            printDiamondWithCostumatizeHeight();
            Console.ReadKey();
        }

        public static void printDiamondWithCostumatizeHeight()
        {

        
            System.Console.Write("Please enter the desire diamond height and press enter:");
            string stringNumberRaw = System.Console.ReadLine();
            bool isSuccessParseString = int.TryParse(stringNumberRaw,out int o_diamondHeight);
            while(!isSuccessParseString)
            {
                System.Console.Write("invalid height number,try again and press enter:");
                isSuccessParseString = int.TryParse(stringNumberRaw, out o_diamondHeight);
            }

            if(o_diamondHeight % 2 == 0)// if o_diamondHeight is even 
            {
                o_diamondHeight++;
            }
            Console.WriteLine("height:"+ o_diamondHeight);
            Ex01_02.Program.PrintDiamondRhombus(o_diamondHeight);

        }
    //    public static void PrintDiamondRhombus(int i_RhombusHeight)
    //    {
    //       const int k_StaringNumberOfStars = 1;
    //        printDiamondRhombusHelperRecursive(i_RhombusHeight, k_StaringNumberOfStars);

    //    }

    //    private static void printDiamondRhombusHelperRecursive(int i_RhombusHeight,int  i_NumberOfStar)
    //    {
    //        if (i_NumberOfStar > i_RhombusHeight  )
    //        {
    //            return;
    //        }

    //        printOneLineOfRhombus(i_RhombusHeight, i_NumberOfStar);
    //        printDiamondRhombusHelperRecursive(i_RhombusHeight, i_NumberOfStar + 2);
    //        if(i_NumberOfStar < i_RhombusHeight)
    //        {
    //            printOneLineOfRhombus(i_RhombusHeight, i_NumberOfStar);
    //        }
    //    }

    //    private static void stringOfSingleCharWithRecursion(char i_CharToRepeat, int i_CharAmount,ref StringBuilder o_OutputString)
    //    {

    //        if(i_CharAmount == 0)
    //        {
    //            return;
    //        }
    //        o_OutputString.Append(i_CharToRepeat);
    //        stringOfSingleCharWithRecursion(i_CharToRepeat, i_CharAmount - 1, ref o_OutputString);

    //    }
    //    private static void printOneLineOfRhombus(int i_LineLength, int i_NumberOfStars)
    //    {
    //        int spaceCharBeforeStarsAmount = (i_LineLength - i_NumberOfStars) / 2;
    //        StringBuilder lineOsStartString = new StringBuilder(i_LineLength);
    //        char spaceChar = ' ';
    //        char starChar = '*';

    //        stringOfSingleCharWithRecursion(spaceChar, spaceCharBeforeStarsAmount, ref lineOsStartString);
    //        stringOfSingleCharWithRecursion(starChar, i_NumberOfStars, ref lineOsStartString);
    //        System.Console.WriteLine(lineOsStartString.ToString());

    //        //if (spaceCharBeforeStarsAmount == (i_LineLength - io_CharWroteCounter) && io_CharWroteCounter != 0)
    //        //{
    //        //    io_CharWroteCounter = 0;
    //        //    System.Console.Write(Environment.NewLine);
    //        //    return;
    //        //}


    //        //if (spaceCharBeforeStarsAmount > io_CharWroteCounter)
    //        //{
    //        //    System.Console.Write(' ');
    //        //}
    //        //else if(spaceCharBeforeStarsAmount +i_NumberOfStars> io_CharWroteCounter)
    //        //{
    //        //    System.Console.Write('*');
    //        //}
    //        //io_CharWroteCounter++;

    //        // printOneLineOfRhombus(i_LineLength, i_NumberOfStars, ref io_CharWroteCounter);


    //    }
    }
}
