/* В библиотеке классов Cinderella определите абстрактный класс Something.  
 * От класса Something  унаследуйте два класса: Lentil, Ashes. В Классе Lentil 
 * определите поле Weight, принимающее для каждого нового экземпляра класса 
 * случайное вещественное значение в интервале [0, 2]. В классе Ashes определите 
 * поле Volume, принимающее для каждого нового экземпляра класса случайное 
 * вещественное значение в интервале [0, 1]​.
 * 
 * В основной программе создайте массив N (N ввести с клавиатуры) экземпляров 
 * классов Lentil и Ashes (принадлежность очередного элемента массива к первому 
 * или второму классу определите при помощи датчика случайных чисел). 
 * Выведите массив на экран. Из элементов массива сформируйте и выведите на экран 
 * два списка экземпляров Lentil  и Ashes. ​
 * 
 * Double выводить с точностьюдо двух знаков после запятой!
 * 
 * 
 * Формат входных данных : 
 * -------test_1-------
 * -1
 * -------test_2-------
 * 4
 * 0,57 
 * 1,42 
 * 0,91 
 * 1,12
 * --------------------
 * 
 * Формат выходных данных : 
 * -------test_1-------
 * Incorrect input!
 * -------test_2-------
 * 0,57 1,42 0,91 1,12
 * 0,57 0,91
 * 1,42 1,12
 * --------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_01
{
    class Program
    {
        static List<Lentil> lentils = new List<Lentil>();
        static List<Ashes> ashes = new List<Ashes>();
        private static readonly Random rnd = new Random();
        static void Main()
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("Incorrect input!");
                return;
            }
            Something[] array = CreateArray(n);
            PrintArray(array);
            PrintSeparately(array);
            Console.ReadLine();
        }

        static Something[] CreateArray(int n)
        {
            Something[] array = new Something[n];
            for (int i = 0; i < n; i++)
            {
                int chooseClass = rnd.Next(2);
                if (chooseClass == 0)
                {
                    double weight;
                    if (!double.TryParse(Console.ReadLine(), out weight) || weight < 0 || weight - 2 > Double.Epsilon)
                    {
                        Console.WriteLine("Incorrect input!");
                        continue;
                    }
                    array[i] = new Lentil(weight);
                    lentils.Add((Lentil)array[i]);
                }
                else
                {
                    double volume;
                    if (!double.TryParse(Console.ReadLine(), out volume) || volume < 0 || volume - 1 > Double.Epsilon)
                    {
                        Console.WriteLine("Incorrect input!");
                        continue;
                    }
                    array[i] = new Ashes(volume);
                    ashes.Add((Ashes)array[i]);
                }
            }
            return array;
        }

        static void PrintArray(Something[] array)
        {
            foreach (Something element in array)
            {
                Console.Write($"{element} ");
            }
        }

        static void PrintSeparately(Something[] array)
        {
            foreach (Lentil element in lentils)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine(lentils);
            foreach (Ashes element in ashes)
            {
                Console.Write($"{element} ");
            }
        }
    }

    abstract class Something
    {
    }
    class Lentil : Something
    {
        private double weight;
        public Lentil(double weight)
        {
            Weight = weight;
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public override string ToString()
        {
            return $"{Weight:f2}";
        }
    }
    class Ashes : Something
    {
        public double Volume { get; set; }
        public Ashes(double volume)
        {
            Volume = volume;
        }
        public override string ToString()
        {
            return $"{Volume:f2}";
        }
    }
}
