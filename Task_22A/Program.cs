using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_22A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Action<Task<int[]>> action = new Action<Task<int[]>>(PrintArray);
            Task task2 = task1.ContinueWith(action);

            Action<Task<int[]>> func2 = new Action<Task<int[]>>(Summ);
            Task task3 = task1.ContinueWith(action);

            Action<Task<int[]>> func3 = new Action<Task<int[]>>(Max);
            Task task4 = task1.ContinueWith(action);

            task1.Start();
            task2.Wait();
            task3.Wait();
            task4.Wait();

            Console.ReadKey();
        }
        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 200);
            }
            return array;
        }
        static void PrintArray(Task<int[]> task)
        {
            int[] array = task.Result;
            for (int i = 0; i < array.Count(); i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
        static void Summ(Task<int[]> task)
        {
            int t = 0;
            int[] array = task.Result;
            for (int j = 0; j < array.Count(); j++) t = t+ array[j];
            Console.WriteLine("Сумма массива = " + t);
        }
        static void Max(Task<int[]> task)
        {
            int t;
            int[] array = task.Result;
            t = array.Max();
            Console.WriteLine("Максимальное значение массива = " + t);
        }
    }
}
