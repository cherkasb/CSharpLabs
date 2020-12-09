using System;

namespace Lab9
{

    abstract class Shape
    {
        public string Color { get; set; }
        public int NumVertices { get; }
        public string Name { get; }

        public abstract double Square();
        public abstract int Perimeter();
    }



    class Program
    {
        //Завдання 1.1
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
