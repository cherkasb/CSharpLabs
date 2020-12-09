using System;

namespace Lab3
{
    class Program
    {
        // Варіант 26 (5 в завданні)
        // Перевірити істинність вислову: "Дане ціле число є парним двозначним числом".
        static void Main(string[] args)
        {
            Console.Write("Enter two-digit number to check if it is even: ");
            Int16 Num;
            if (Int16.TryParse(Console.ReadLine(), out Num))
            {
                if (Num / 100 == 0 && Num / 10 > 0)  //two-digit
                {
                    Console.WriteLine(Num % 2 == 0 ? "True" : "False");
                }
                else
                {
                    Console.WriteLine("Not two-digit");
                }
            }
            else
            {
                Console.WriteLine("Invalid input data!");
            }
            Console.WriteLine("Press Enter to exit");
            Console.Read();
        }
    }
}
