using System;
using System.Collections.Generic;

namespace Lab8
{

    class DiskPhone
    {
        public string TelephoneNumber;
        public static readonly string AllowdSymbols = "0123456789";

        public void AnswerCall(string PhoneNumber) {}

        public void MakeCall(string PhoneNumber) {}

    }

    class ButtonPhone : DiskPhone
    {
        new public static readonly string AllowdSymbols = "0123456789*#";

        public void DisplayPhoneNumber(string PhoneNumber) {}
        new public void AnswerCall(string PhoneNumber)
        {
            DisplayPhoneNumber(PhoneNumber);
        }
    }

    class MobilePhone : ButtonPhone
    {
        new public static readonly string AllowdSymbols = "0123456789*#abcdefghijklmnopqrstuvwxyz+=-_()?:%;\"![]}{";
        public string Resolution;
        public string Size;
        public string Color;

        public void SendSMS(string PhoneNumber) {}

        public void ReceiveSMS(string PhoneNumber) {}

    }

    class ColoredMobile : MobilePhone
    {
        public int DisplayColors;
        public bool HasSecondSIM;
        public string SecondNumber;
        public void MakeCall(string PhoneNumber, bool UseSecondSIM) { }

        public void SendSMS(string PhoneNumber, bool UseSecondSIM) { }

        public void SendMMS(string PhoneNumber, bool UseSecondSIM) { }

        public void ReceiveMMS(string PhoneNumber) { }
    }

    class SmartPhone : ColoredMobile
    {
        public bool HasSensor;
        public int MaxTouches;
        public int NumberOfCamers;

        void MakePhoto(int CameraToUse) { }

        void MakeVideo(int CameraToUse) { }
    }

    class Car
    {
        public bool CompareTo(string InName = "", string InColor = "", Int32 InSpeed = 0, Int32 InReleaseYear = 0)
        {
            if (InName.Length > 0 && Name != InName)
                return false;
            if (InColor.Length > 0 && Color != InColor)
                return false;
            if (InSpeed > 0 && Speed != InSpeed)
                return false;
            if (InReleaseYear > 0 && ReleaseYear != InReleaseYear)
                return false;
            return true;
        }

        public string Name;
        public string Color;
        public Int32 Speed;
        public Int32 ReleaseYear;
    }
    class Garage
    {
        List<Car> Cars = new List<Car>();

        public void BuyNewCar(string InName, string InColor, Int32 InSpeed, Int32 InReleaseYear)
        {
            Car TempCar = new Car { Name = InName, Color = InColor, Speed = InSpeed, ReleaseYear = InReleaseYear };
            Cars.Add(TempCar);
        }

        public void RemoveCar(Int32 Index)
        {
            if (Cars.Count > Index)
                Cars.RemoveAt(Index);
        }

        public void FindCars(string InName = "", string InColor = "", Int32 InSpeed = 0, Int32 InReleaseYear = 0)
        {
            for (int i = 0; i < Cars.Count; ++i)
            {
                if (Cars[i].CompareTo(InName, InColor, InSpeed, InReleaseYear))
                {
                    Console.WriteLine("{0}. {1}", i, Cars[i].Name);
                }
            };
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Garage MyGarage = new Garage();

            MyGarage.BuyNewCar("Tesla", "Pink", 1, 1);
            MyGarage.BuyNewCar("Jaguar", "Red", 12, 11);
            MyGarage.BuyNewCar("AUDI", "Gray", 21, 1);
            MyGarage.BuyNewCar("Porsche", "Black", 221, 1);
            MyGarage.BuyNewCar("Zapor", "HELLRED", 999999, 1);

            string Name, Color;
            Int32 Speed = 0, Year = 0;
            Console.WriteLine("Enter info for car to find it. Leave line blank to skip current property");
            Console.Write("Name: ");
            Name = Console.ReadLine();
            Console.Write("Color: ");
            Color = Console.ReadLine();
            Console.Write("Speed: ");
            Int32.TryParse(Console.ReadLine(), out Speed);
            Console.Write("Year: ");
            Int32.TryParse(Console.ReadLine(), out Year);

            MyGarage.FindCars(Name, Color, Speed, Year);
            Console.Read();
        }
    }
}