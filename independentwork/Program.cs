using System;
using System.Collections.Generic;

namespace independentwork
{

    /*
    **  Варіант 26 (9 в завданні)
    ** 9.	Створити клас Provider, в якому представлені 5тарифів інтернету.
    ** В кожного з тарифів є 4характеристики: ціна за підключення, абонплата на місяць, швидкість інтернету.
    ** Четверту характеристику оберіть самі. Реалізувати можливість для клієнта обрати тариф згідно з одним з двох параметрів(абонплата-швикдість).
    ** Вивести всі варіанти які йому підходять, якщо не підходить жоден – вивести відповідне повідомлення.. 
    */

    class Tariff
    {
        public string name;
        public int ConnectionPrice;
        public int SubscriptionFee;
        public int Speed;
        public int Stability; //0 - 100%
    }

    class Provider
    {
        Tariff Economy = new Tariff { name = "Economy", ConnectionPrice = 0, SubscriptionFee = 100, Speed = 50, Stability = 60 };
        Tariff Stable = new Tariff { name = "Stable", ConnectionPrice = 0, SubscriptionFee = 130, Speed = 60, Stability = 100 };
        Tariff Default = new Tariff { name = "Default", ConnectionPrice = 500, SubscriptionFee = 120, Speed = 100, Stability = 85 };
        Tariff YourFavourite = new Tariff { name = "Your Favourite", ConnectionPrice = 100, SubscriptionFee = 150, Speed = 150, Stability = 80 };
        Tariff Fast = new Tariff { name = "Fast", ConnectionPrice = 750, SubscriptionFee = 150, Speed = 300, Stability = 80 };
        Tariff Ultrafast = new Tariff { name = "Ultrafast", ConnectionPrice = 1000, SubscriptionFee = 350, Speed = 1000, Stability = 95 };

        public List<Tariff> GetAvailableTarriffs(int money, int minimalspeed)
        {
            List<Tariff> Tarifs = new List<Tariff>();

            if (money >= Economy.SubscriptionFee && minimalspeed <= Economy.Speed)
                Tarifs.Add(Economy);
            if (money >= Stable.SubscriptionFee && minimalspeed <= Stable.Speed)
                Tarifs.Add(Stable);
            if (money >= Default.SubscriptionFee && minimalspeed <= Default.Speed)
                Tarifs.Add(Default);
            if (money >= YourFavourite.SubscriptionFee && minimalspeed <= YourFavourite.Speed)
                Tarifs.Add(YourFavourite);
            if (money >= Fast.SubscriptionFee && minimalspeed <= Fast.Speed)
                Tarifs.Add(Fast);
            if (money >= Ultrafast.SubscriptionFee && minimalspeed <= Ultrafast.Speed)
                Tarifs.Add(Ultrafast);
            if (Tarifs.Count < 1)
                return null;
            return Tarifs;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int price = 0;
            int speed = 0;
            Console.Write("Enter how much money can you spend: ");
            int.TryParse(Console.ReadLine(), out price);
            Console.Write("Enter how much speed tarif should have: ");
            int.TryParse(Console.ReadLine(), out speed);

            Provider Pr = new Provider();
            List<Tariff> Tariffs = Pr.GetAvailableTarriffs(price, speed);
            if (Tariffs == null)
            {
                Console.WriteLine("No suitable tariffs");
            }
            else
            {
                Console.WriteLine("Suitable tariffs: ");
                for (int i = 0; i < Tariffs.Count; ++i)
                {
                    Console.WriteLine("{0}. Name: {1}, ConnectionPrice {2}, SubscriptionFee {3}, Speed {4}, Stability {5}",
                        i + 1, Tariffs[i].name, Tariffs[i].ConnectionPrice, Tariffs[i].SubscriptionFee, Tariffs[i].Speed, Tariffs[i].Stability);
                }
            }
            Console.Read();
        }
    }
}
