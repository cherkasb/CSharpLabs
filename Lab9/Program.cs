using System;
using System.Reflection;
using System.Collections.Generic;

namespace Lab9
{
    /*
    ** Part 1 
    */
    abstract class Shape
    {
        public enum ColorType : byte
        {
            Red = 0,
            Green = 1,
            Blue = 2,
            Random = 3
        }

        public ColorType Color;
        public int Vertices;
        public string Name;

        public abstract double Perimetr();

        public abstract double Squared();
        public void Draw()
        {
            switch (Color)
            {
                case ColorType.Red: Console.ForegroundColor = ConsoleColor.Red; break;
                case ColorType.Green: Console.ForegroundColor = ConsoleColor.Green; break;
                case ColorType.Blue: Console.ForegroundColor = ConsoleColor.Blue; break;
                default: Console.ForegroundColor = ConsoleColor.Red; break;
            }
            Console.WriteLine("Object {0} with perimeter {1} and square {2}", Name, Perimetr(), Squared());
        }
    }

    class Square : Shape
    {
        int SideLength { get; }

        public Square(string InName, int InLenght = -1, ColorType InColor = ColorType.Random)
        {
            Vertices = 4;
            Random random = new Random();
            Name = InName;
            SideLength = InLenght == -1 ? random.Next(2, 10) : InLenght;
            Color = InColor == ColorType.Random ? (ColorType)random.Next(0, 2) : InColor;
        }

        public override double Perimetr() => SideLength * 4;
        public override double Squared() => SideLength * SideLength;

    }

    class Triangle : Shape
    {
        int SideLength { get; }
        int BaseLength { get; }
        public Triangle(string InName, int InSideLength= -1, int InBaseLenght = -1, ColorType InColor = ColorType.Random)
        {
            Vertices = 3;
            Random random = new Random();
            Name = InName;
            SideLength = InSideLength == -1 ? random.Next(2, 10) : InSideLength;
            BaseLength = InBaseLenght == -1 ? random.Next(2, 10) : InBaseLenght;
            Color = InColor == ColorType.Random ? (ColorType)random.Next(0, 2) : InColor;
        }

        public override double Perimetr() =>(SideLength * 2) + BaseLength;

        public override double Squared() => Math.Pow(SideLength * SideLength * BaseLength / 4, 1 / BaseLength) / 2.0;

    }

    class Circle : Shape
    {
        int Radius { get; }

        public Circle(string InName, int InRadius = -1, ColorType InColor = ColorType.Random)
        {
            Vertices = 0;
            Random random = new Random();
            Name = InName;
            InRadius = InRadius == -1 ? random.Next(2, 10) : InRadius;
            Color = InColor == ColorType.Random ? (ColorType)random.Next(0, 2) : InColor;
        }

        public override double Perimetr() => 2 * Math.PI * Radius;

        public override double Squared() => 3.14 * (Radius * Radius);
    }

    /*
    ** Part 2
    **/

    class Picture : IDraw
    {
        public Picture() => Objects = new List<Shape>();
        public Picture(int Capacity) => Objects = new List<Shape>(Capacity);

        public void AddObject(Shape InObject) => Objects.Add(InObject);

        public void RemoveObject(Type InObjectType) => Objects.RemoveAll(Object => Object.GetType() == InObjectType);
        public void RemoveObject(int Idx)
        {
            if (Objects.Count > Idx)
                Objects.RemoveAt(Idx);
        }

        public void RemoveObject(string Name) => Objects.RemoveAll(Object => Object.Name == Name);

        public void Draw() => Objects.ForEach(action => action.Draw());

        public Shape this[int key]
        {
            get
            {
                if (Objects.Count > key)
                    return Objects[key];
                return null;
            }
            set
            {
                if (Objects.Count > key)
                    Objects[key] = value;
            }
        }

        List<Shape> Objects;
        public int Count
        {
            get
            {
                return Objects.Count;
            }
        }
    }

    /*
    ** Part 3
    **/

    interface IDraw
    {
        public void Draw();
    }

    class Painter : IDraw
    {
        public Painter() => Objects = new List<Picture>();

        public void AddPicture(Picture InObject) => Objects.Add(InObject);

        List<Picture> Objects;
        public int Count
        {
            get
            {
                return Objects.Count;
            }
        }

        public void Draw() => Objects.ForEach(action => action.Draw());
    }

    /*
    ** Main
    */
    class Program
    {
        static void Main(string[] args)
        {
            Square square1 = new Square("Square", 10);
            Console.WriteLine(square1.Perimetr());
            Console.WriteLine(square1.Squared());
            Circle circle1 = new Circle("Circle", 10);
            Console.WriteLine(circle1.Perimetr());
            Console.WriteLine(circle1.Squared());
            Triangle triangle1 = new Triangle("Triangle", 8);
            Console.WriteLine(triangle1.Perimetr());
            Console.WriteLine(triangle1.Squared());

            Picture pic = new Picture(3);
            pic.AddObject(square1);
            pic.AddObject(circle1);
            pic.AddObject(triangle1);
            pic.Draw();
            pic.RemoveObject("Triangle");
            Console.WriteLine();
            pic.Draw();

            Console.ReadLine();

        }
    }
}