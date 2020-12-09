using System;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        // Варіант 26 (26 в завданні)
        // Даний масив цілих чисел розміру N. Перетворити масив, збільшивши 1) першу; 2) останню 3) всі серії найбільшої довжини на один елемент. 
        static void Main(string[] args)
        {
            List<Int32> Array = new List<Int32>();

            Console.WriteLine("Enter array elements: ");
            string Line = Console.ReadLine();
            string[] Numbers = Line.Split(' ');
            Int32 ArraySize = Numbers.GetLength(0);
            if (ArraySize < 1)
            {
                Console.WriteLine("Too small array size!");
                Console.WriteLine("Press enter to exit");
                Console.Read();
                return;
            }
            for (int i = 0; i < ArraySize; ++i)
            {
                Int32 TempNum;
                if (!Int32.TryParse(Numbers[i], out TempNum))
                {
                    TempNum = 0;
                }
                Array.Add(TempNum);
            }

            Console.WriteLine("Your array:");
            for (int i = 0; i < ArraySize; ++i)
            {
                Console.Write("{0} ", Array[i]);
            }

             // Change array
            {
                Int32 i = 0;
                Int32 CurrentSerieNumber = Array[0];
                Int32 CurrentSerieSize = 0;
                Int32 MaxSerieSize = 0;

                //Find longest serie
                for (i = 1; i < ArraySize - 1; ++i)
                {
                    if (Array[i] != CurrentSerieNumber)
                    {
                        MaxSerieSize = Math.Max(CurrentSerieSize, MaxSerieSize);
                        CurrentSerieNumber = Array[i];
                        CurrentSerieSize = 0;
                    }
                    else
                        CurrentSerieSize++;
                }

                // Find first serie
                for (i = 0; i < ArraySize - 1; ++i)
                {
                    if (Array[i] == Array[i + 1])
                        break;
                }
                Int32 FirstSerieStart = i;
               
                // Last serie
                for (i = ArraySize - 1; i > 0; --i)
                {
                    if (Array[i] == Array[i - 1])
                        break;
                }
                Int32 LastSerieStart = i;

                //increase longest series
                if (MaxSerieSize > 0)
                {
                    i = 0;
                    while (i < ArraySize - MaxSerieSize)
                    {
                        if (Array[i] == Array[i + MaxSerieSize])
                        {
                            int j = 0;
                            while (i + j < ArraySize - 1 && Array[i + j] == Array[i + j + 1])
                                ++j;
                            if (j == MaxSerieSize)
                            {
                                for (int k = 0; k <= j; ++k)
                                    Array[i + k]++;
                            }
                            i += j;
                        }
                        else
                            ++i;
                    }
                }

                //increase first one
                for (i = FirstSerieStart ; i < ArraySize - 1 && Array[i] == Array[i + 1]; ++i)
                {
                    Array[i]++;
                }
                if (i != FirstSerieStart)
                    Array[i]++;

                //increase last one
                for (i = LastSerieStart ; i > 0 && Array[i] == Array[i - 1]; --i)
                {
                    Array[i]++;
                }
                if (i != LastSerieStart)
                    Array[i]++;
            }

            Console.WriteLine("Your array after changes:");
            for (int i = 0; i < ArraySize; ++i)
            {
                Console.Write("{0} ", Array[i]);
            }

            Console.WriteLine("Press enter to exit");
            Console.Read();
        }
    }
}
