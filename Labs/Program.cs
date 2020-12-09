using System;

namespace Labs
{
    class Program
    {
        //Вариант 26 (11 в задании)
        static void Main(string[] args)
        {
            Console.Write("Введите секунды для превращения в формат часы.минуты.секунды: ");
            Int64 Seconds;
            if (Int64.TryParse(Console.ReadLine(), out Seconds))
            {
                Seconds = Math.Max(0, Seconds);
                Int64 Minutes = Seconds / 60;
                Int64 Hours = Minutes / 60;
                Seconds %= 60;
                Minutes %= 60;
                Console.WriteLine("Результат: {0} ч. {1} мин. {2} сек.", Hours, Minutes, Seconds);
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные!");
            }
            Console.WriteLine("Нажмите Enter что бы выйти");
            Console.Read();
        }
    }
}
