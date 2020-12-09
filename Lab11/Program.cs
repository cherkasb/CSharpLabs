using System;
using System.Reflection;
using System.Collections.Generic;

namespace Lab11
{

    public static class Extension
    {
        public static List<Student> FindStudent(this List<Student> InStudents, StudentPredicateDelegate Pred)
        {
            if (InStudents.Count > 0)
            {
                List<Student> OutStudents = new List<Student>();

                for (int i = 0; i < InStudents.Count; ++i)
                {
                    if (Pred != null && Pred.Invoke(InStudents[i]))
                    {
                        OutStudents.Add(InStudents[i]);
                    }
                }
                return OutStudents;
            }
            return null;
        }
    }

    public class Student
    {
        public string FirstName;
        public string LastName;
        public int Age;

        public static bool CheckAge(Student InStudent)
        {
            return InStudent.Age >= 18;
        }

        public static bool CheckFirstName(Student InStudent)
        {
            return (InStudent.FirstName.Length > 0 && InStudent.FirstName[0] == 'A');
        }

        public static bool CheckLastName(Student InStudent)
        {
            return InStudent.LastName.Length > 3;
        }
    }

    public delegate bool StudentPredicateDelegate(Student InStudent);


    /*
    ** Part 1
    */
    public class Product
    {
        public bool bCheckedSize;
        public bool bCut;
        public bool bSharpened;
        public bool bHadCutThread;
        public bool bDrilled;
        public bool bColored;
        public bool bTested;
        public bool bPacked;

        public void ShowProgress()
        {
            Console.WriteLine("Product: ");
            Console.WriteLine("bCheckedSize: {0}", bCheckedSize ? "True" : "False");
            Console.WriteLine("bCut: {0}", bCut ? "True" : "False");
            Console.WriteLine("bSharpened: {0}", bSharpened ? "True" : "False");
            Console.WriteLine("bHadCutThread: {0}", bHadCutThread ? "True" : "False");
            Console.WriteLine("bDrilled: {0}", bDrilled ? "True" : "False");
            Console.WriteLine("bColored: {0}", bColored ? "True" : "False");
            Console.WriteLine("bTested: {0}", bTested ? "True" : "False");
            Console.WriteLine("bPacked: {0}", bPacked ? "True" : "False");
        }
    }

    public delegate void ProductLineDelegate(ref Product InProduct);

    public class ProductLine
    {
        public void CheckSize(ref Product InProduct) { InProduct.bCheckedSize = true; }
        public void Cut(ref Product InProduct) { InProduct.bCut = true; }
        public void Sharpen(ref Product InProduct) { InProduct.bSharpened = true; }
        public void CutThread(ref Product InProduct) { InProduct.bHadCutThread = true; }
        public void Drill(ref Product InProduct) { InProduct.bDrilled = true; }
        public void Color(ref Product InProduct) { InProduct.bColored = true; }
        public void Test(ref Product InProduct) { InProduct.bTested = true; }
        public void Pack(ref Product InProduct) { InProduct.bPacked = true; }
    }

    class Program
    {
        // Варіант 26 (Варіант 1 в завданні)
        /*1.Створити клас Конвеєр. Створити клас Виріб,додати в нього властивості типу bool: розміри зняті, відрізано, заточено, нарізано різьбу, просверлено,
        ** пофарбувано, протестувано, запакувано. Створити наступні методи в класі Конвеєр: зняти розміри, відрізати, заточить, нарізати різьбу, просверлити,
        ** пофарбувати, протестувати, запакувати. Всі методи приймають екземпляр класу Виріб і проставляють значенням true відповідні властивості екземпляру класу.
        ** Створити комбіновані делегати, які будуть виконувати весь, або частину функціоналу. Реалізувати можливість виводу значень всіх властивостей на екрану вигляді:
        ** Назва Властивості -- Значення
        */

        static void PrintList(List<Student> Students)
        {
            for (int i = 0; i < Students.Count; ++i)
            {
                Console.WriteLine("First Name: {0} Last Name: {1} Age: {2}", Students[i].FirstName, Students[i].LastName, Students[i].Age);
            }
        }

        static void Main(string[] args)
        {
/*
** Part 1
*/
            Product CreatedOne = new Product();
            ProductLine Line = new ProductLine();

            CreatedOne.ShowProgress();

            ProductLineDelegate WorkToProceed = null;
            MethodInfo[] methodInfos = Type.GetType("Lab11.ProductLine").GetMethods(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < methodInfos.Length; ++i)
            {
                if (methodInfos[i].GetParameters().Length == 1 && (methodInfos[i].GetParameters()[0].ParameterType.FullName == "Lab11.Product&"))
                {
                    ProductLineDelegate TempDelegate = (ProductLineDelegate)Delegate.CreateDelegate(typeof(ProductLineDelegate), Line, methodInfos[i]);
                    if (WorkToProceed != null)
                    {
                        WorkToProceed += (ProductLineDelegate)TempDelegate;
                    }
                    else
                    {
                        WorkToProceed = new ProductLineDelegate(TempDelegate);
                    }
                }
            }

            WorkToProceed?.Invoke(ref CreatedOne);
            CreatedOne.ShowProgress();
            /*
            ** Part 2
            */

            List<Student> Students = new List<Student>();

            Students.Add(new Student { FirstName = "asadsad", LastName = "Asdadb", Age = 18 });
            Students.Add(new Student { FirstName = "sdsadsab", LastName = "Adsac", Age = 28 });
            Students.Add(new Student { FirstName = "cdsada", LastName = "ssd", Age = 83 });
            Students.Add(new Student { FirstName = "dds", LastName = "e", Age = 48 });
            Students.Add(new Student { FirstName = "sssse", LastName = "sf", Age = 5 });
            Students.Add(new Student { FirstName = "Addf", LastName = "g", Age = 6 });
            Students.Add(new Student { FirstName = "Adsag", LastName = "h", Age = 78 });
            Students.Add(new Student { FirstName = "ssh", LastName = "iddd", Age = 88 });
            Students.Add(new Student { FirstName = "sdi", LastName = "j", Age = 9 });
            Students.Add(new Student { FirstName = "ssj", LastName = "k", Age = 10});

            StudentPredicateDelegate CheckName = (StudentPredicateDelegate)Delegate.CreateDelegate(typeof(StudentPredicateDelegate), typeof(Student), "CheckFirstName");
            StudentPredicateDelegate CheckLastName = (StudentPredicateDelegate)Delegate.CreateDelegate(typeof(StudentPredicateDelegate), typeof(Student), "CheckLastName");
            StudentPredicateDelegate CheckAge = (StudentPredicateDelegate)Delegate.CreateDelegate(typeof(StudentPredicateDelegate), typeof(Student), "CheckAge");
            PrintList(Students.FindStudent(CheckName));
            Console.WriteLine();
            PrintList(Students.FindStudent(CheckLastName));
            Console.WriteLine();
            PrintList(Students.FindStudent(CheckAge));
            Console.WriteLine();
            Console.WriteLine();

            PrintList(Students.FindStudent(Stud => (Stud.FirstName.Length > 0 && Stud.FirstName[0] == 'A')));
            Console.WriteLine();
            PrintList(Students.FindStudent(Stud => Stud.LastName.Length > 3));
            Console.WriteLine();
            PrintList(Students.FindStudent(Stud => Stud.Age >= 18));
            Console.WriteLine();
            Console.WriteLine();

            PrintList(Students.FindStudent(Stud => Stud.Age >= 20 && Stud.Age <= 25));
            Console.WriteLine();
            PrintList(Students.FindStudent(Stud => Stud.FirstName == "Andrew"));
            Console.WriteLine();
            PrintList(Students.FindStudent(Stud => Stud.LastName == "Troelsen"));
            Console.WriteLine();

            Console.Read();

        }
    }
}
