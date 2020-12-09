using System;

namespace Lab5
{
    class Program
    {

        static void DeleteCol(ref Int32[,] Array, Int32 ColNumber)
        {
            Int32 Cols = Array.GetLength(1);
            Int32 Rows = Array.GetLength(0);
            for (int i = 0; i < Rows; ++i)
            {
                if (ColNumber == Cols - 1)
                    Array[i, ColNumber] = 0;
                else
                {
                    for (int j = ColNumber; j < Cols - 1; ++j)
                    {
                        Array[i, j] = Array[i, j + 1];
                    }
                    Array[i, Cols - 1] = 0;
                }
            }
        }

        // Варіант 26 (26 в завданні)
        // 26.	Дана матриця розміру m *  n. Видалити 1) перший; 2) останній; 3) всі стовпчики,  що містять тільки додатні елементи.  
        static void Main(string[] args)
        {
            Int32 Rows = 0;
            Int32 Cols = 0;
            Console.WriteLine("Enter array size cols and rows:");
            Console.Write("Enter array cols: ");
            if (!Int32.TryParse(Console.ReadLine(), out Cols) || Cols < 1)
            {
                Console.WriteLine("Too small array size!");
                Console.WriteLine("Press enter to exit");
                Console.Read();
                return;
            }
            Console.Write("Enter array rows: ");
            if (!Int32.TryParse(Console.ReadLine(), out Rows) || Rows < 1)
            {
                Console.WriteLine("Too small array size!");
                Console.WriteLine("Press enter to exit");
                Console.Read();
                return;
            }
            Int32[,] Array = new Int32[Rows, Cols];
            for (int i = 0; i < Rows; ++i)
            {
                string Line = Console.ReadLine();
                string[] Numbers = Line.Split(' ');
                for (int j = 0; j < Numbers.GetLength(0) && j < Cols; ++j)
                {
                    Int32 TempNum;
                    if (!Int32.TryParse(Numbers[j], out TempNum))
                    {
                        TempNum = 0;
                    }
                    Array[i, j] = TempNum;
                }
            }

            Console.WriteLine("Your array:");
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Cols; ++j)
                {
                    Console.Write("{0} ", Array[i, j]);
                }
                Console.WriteLine();
            }
            Int32 NewCols = Cols - 2;
            DeleteCol(ref Array, Cols - 1);
            DeleteCol(ref Array, 0);
            for (int j = 0; j < Cols; ++j)
            {
                bool IsEven = true;
                for (int i = 0; i < Rows; ++i)
                {
                    if (Array[i, j] == 0 || Array[i, j] % 2 != 0)
                    {
                        IsEven = false;
                        break;
                    }
                }
                if (IsEven)
                {
                    DeleteCol(ref Array, j);
                    NewCols--;
                    --j;
                }
            }

            Console.WriteLine("Your array after changes:");
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Cols; ++j)
                {
                    if (j < NewCols)
                        Console.Write("{0} ", Array[i, j]);
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }
        }
    }
}

