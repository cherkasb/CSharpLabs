using System;

namespace Lab6
{
    class Program
    {
        static void PrintReversed(double Num)
        {
            string str = Num.ToString();
            Int32 Pivot = 0;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == '.' || str[i] == ',')
                {
                    Pivot = i;
                    break;
                }
            }
            for (int i = Pivot - 1; i >= 0; i--)
                Console.Write(str[i]);
            Console.Write(str[Pivot]);
            for (int i = str.Length - 1; i > Pivot; i--)
                Console.Write(str[i]);
            Console.WriteLine();
        }

        static void PrintReversed(int Num)
        {
            string str = Num.ToString();

            for (int i = str.Length - 1; i >= 0; i--)
                Console.Write(str[i]);
            Console.WriteLine();
        }

        static void PrintReversed(string str)
        {
            for (int i = str.Length - 1; i >=0; i--)
                Console.Write(str[i]);
            Console.WriteLine();
        }

        static void PrintReversed(string str, char Pivot)
        {
            Int32 PivotIndex = str.IndexOf(Pivot, 0);
            Int32 OldPivotIndex = -1;
            while (PivotIndex != -1)
            {
                for (int i = PivotIndex - 1; i > OldPivotIndex; i--)
                    Console.Write(str[i]);
                Console.Write(str[PivotIndex]);
                OldPivotIndex = PivotIndex;
                PivotIndex = str.IndexOf(Pivot, PivotIndex + 1);
            }
            if (OldPivotIndex != -1)
            {
                for (int i = str.Length - 1; i > OldPivotIndex; i--)
                    Console.Write(str[i]);
                Console.WriteLine();
            }
            else
                PrintReversed(str);
        }

        static void Reverse(ref int[] InputArray, out int[] OutArray)
        {
            int Size = InputArray.Length;
            OutArray = new int[Size];

            for (int i = 0; i < InputArray.Length; i++)
            {
                OutArray[i] = InputArray[Size - 1];
                Size--;
            }
        }

        static void Main(string[] args)
        {
            int[] Array1 = { 1, 2, 3, 4, 5 };
            int[] Array2;

            Reverse(ref Array1, out Array2);
            for (int i = 0; i < Array2.Length; ++i)
                Console.Write("{0} ", Array2[i]);
            Console.WriteLine();

            PrintReversed(124.765);
            PrintReversed(1337);
            PrintReversed("ReverseThisText");
            PrintReversed("Rever,seThi,sText", ',');
            Console.Read();
        }
    }
}