using System;

namespace Lab2
{
    class Program
    {
        //Вариант 26 (2 в задании)
        static void Main(string[] args)
        {
            Int32 LoopBegin; //nn
            Int32 LoopEnd; //nk

            Console.Write("Enter starting index nn: ");
            if (!Int32.TryParse(Console.ReadLine(), out LoopBegin))
            {
                Console.WriteLine("Invalid number! Using 0 as nn");
                LoopBegin = 0;
            }
            Console.Write("Enter last index nk: ");
            if (!Int32.TryParse(Console.ReadLine(), out LoopEnd))
            {
                Console.WriteLine("Invalid number! Using 0 as nk");
                LoopEnd = 0;
            }
            if (LoopBegin >= 0 && LoopEnd >= LoopBegin)
            {
                double Result = 0;
                for (Int32 k = LoopBegin; k <= LoopEnd; ++k)
                {
                    Result += (k * k + Math.Pow(-1.0, k) * k - 1) / (k * k + 1);
                }
                Console.WriteLine("Result of loop: {0}", Result);
            }
            else
            {
                Console.WriteLine("Error: nk < nn or nk < 0. Exiting");
            }
            Console.WriteLine("Press Enter to exit");
            Console.Read();
        }
    }
}
