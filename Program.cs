using System;
using System.IO;

namespace oop_task5_option6
{
    class Program
    {

        static void OddNumbersMultiplication(params double[] array)  // якщо елемент масиву не ділиться націло на 2 (не є парним), то він множиться на 5 і перезаписується назад у масив
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    array[i] = array[i] * 5;
                }
            }
        }

        static void Display(params double[] array) // метод виводить масив у консоль
        {
            foreach (double i in array)
            {
                Console.WriteLine(i);
            }
        }

        static double[] ArraySumOfSquares(double[] array1, double[] array2) // метод повертає масив Z, який є сумою квадратів X та Y
        {
            double[] array3 = new double[array1.Length];
            for (int i = 0; i < array3.Length; i++)
            {
                array3[i] = Math.Pow(array1[i], 2) + Math.Pow(array2[i], 2);
            }
            return array3;
        }

        static double[] Read(StreamReader stream, params double[] array)   // метод для зчитування масиву з файлу
        {
            for (int i = 0; i < array.Length; i++)
            { 
                array[i] = Convert.ToDouble(stream.ReadLine());
            }
            return array;
        }

        static void Write(StreamWriter stream, params double[] array)   // метод для записування масиву у файл
        {
            foreach (double i in array)
            {
                stream.WriteLine(i);
            }
        }

        static int CountLength(string path)  // метод повертає довжину масиву
        {
            int count = 0;
            foreach (string i in File.ReadAllLines(path)) 
            { count++; }
            return count;
        }

        static void Main(string[] args)
        {

            string pathArrayX = @"E:\university\ооп\oop_task5_option6\bin\Debug\netcoreapp3.1\x.txt";
            string pathArrayY = @"E:\university\ооп\oop_task5_option6\bin\Debug\netcoreapp3.1\y.txt";
            string pathArrayZ = @"E:\university\ооп\oop_task5_option6\bin\Debug\netcoreapp3.1\z.txt";

            StreamReader readX = new StreamReader(pathArrayX);  // відкриваємо файл з масивом X
            StreamReader readY = new StreamReader(pathArrayY); // відкриваємо файл з масивом Y
            StreamWriter writeZ = new StreamWriter(pathArrayZ); // створюємо і відкриваємо файл з масивом Z 

            int lengthX = CountLength(pathArrayX);
            int lengthY = CountLength(pathArrayY);

            while (true)
            {
                if (lengthX != lengthY) 
                {
                    Console.WriteLine("Error. Can't execute program. \nNumber of integers in files doesn't match. \nMake changes and start the program again.");
                    break;
                }
                else { 


                    double[] arrayx = new double[lengthX];
                    double[] arrayy = new double[lengthX];
                    double[] arrayz = new double[lengthX];

                    try
                    {
                        Read(readX, arrayx);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Error. Can't execute program. \nFound type that doesn't matches integer in file {pathArrayX}. \nMake changes and start the program again.");
                        break;
                    }

                    try
                    {
                        Read(readY, arrayy);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Error. Can't execute program. \nFound type that doesn't matches integer in file {pathArrayY}. \nMake changes and start the program again.");
                        break;
                    }

                    

                    OddNumbersMultiplication(arrayx);
                    arrayz = ArraySumOfSquares(arrayx, arrayy);
                    Write(writeZ, arrayz);

                    
                    Console.WriteLine("x\ty\tz");
                    for (int i = 0; i < arrayx.Length; i++)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", arrayx[i], arrayy[i], arrayz[i]);
                    }
                    
                    readX.Close();
                    readX.Close();
                    writeZ.Close();
                    break;
                }
            }
        }
    }
}
