using System;

namespace Lab10
{
    public static class Extensions
    {
        public static void PrintReversed(this double Num)
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

        public static void PrintReversed(this int Num)
        {
            string str = Num.ToString();

            for (int i = str.Length - 1; i >= 0; i--)
                Console.Write(str[i]);
            Console.WriteLine();
        }

        public static void PrintReversed(this string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
                Console.Write(str[i]);
            Console.WriteLine();
        }

        public static void PrintReversed(this string str, char Pivot)
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

        public static void Reverse(this int[] InputArray, out int[] OutArray)
        {
            int Size = InputArray.Length;
            OutArray = new int[Size];

            for (int i = 0; i < InputArray.Length; i++)
            {
                OutArray[i] = InputArray[Size - 1];
                Size--;
            }
        }

        public static void Sort(this int[] InputArray)
        {
            int size = InputArray.Length;
            int temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (InputArray[j] < InputArray[j + 1])
                    {
                        // меняем элементы местами
                        temp = InputArray[j];
                        InputArray[j] = InputArray[j + 1];
                        InputArray[j + 1] = temp;
                    }
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int[] Array1 = { 1 , 3, 2 , 4 , 3, 5 , 2 };
            int[] Array2;

            Array1.Reverse(out Array2);
            for (int i = 0; i < Array2.Length; ++i)
                Console.Write("{0} ", Array2[i]);
            Console.WriteLine();

            124.765.PrintReversed();
            1337.PrintReversed();
            "ReverseThisText".PrintReversed();
            "Rever,seThi,sText".PrintReversed(',');

            Array1.Sort();
            for (int i = 0; i < Array1.Length; ++i)
                Console.Write("{0} ", Array1[i]);
            Console.WriteLine();

            Console.Read();
        }
    }
}
