using System;
using System.Collections.Generic;

namespace Lab7
{
    // Варіант 26 (2 в завданні)
    // Створити ліст трінгових змінних, дозволити можливість заповнення з калвіатури.Вивести індекси змінних рівних перевірочній(теж ввести з клавіатури). Скопіювати ліст в масив.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your strings. To stop entering type STOP!!! ");
            List<string> Strings = new List<string>();

            string TempStr;
            TempStr = Console.ReadLine();
            while (TempStr != "STOP!!!")
            {
                Strings.Add(TempStr);
                TempStr = Console.ReadLine();
            }
            Console.Write("Enter your check string: ");
            TempStr = Console.ReadLine();
            Console.Write("Indexes with coincidences: ");
            for (int i = 0; i < Strings.Count; ++i)
            {
                if (Strings[i] == TempStr)
                {
                    Console.Write("{0}, ", i);
                }
            }
            Console.WriteLine();

            string[] StringsArr = new string[Strings.Count];

            Strings.CopyTo(StringsArr);
        }
    }
}
