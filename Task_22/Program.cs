using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_22
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Введите размер массива: ");
            n = Int32.Parse(Console.ReadLine());
            int[] mass = new int[n];


            Task task1 = new Task(() => insert_mass());
            Task task2 = task1.ContinueWith(insert_mas => Max());
            Task task3 = task1.ContinueWith(insert_mas => Summ());

            task1.Start();
            task2.Wait();
            task3.Wait();
            Console.ReadKey();

            void Summ()
            {
                int temp = 0;
                for (int j = 0; j < n; j++) temp = temp + mass[j];
                Console.WriteLine("Сумма массива = " + temp);
            }
            void Max()
            {
                int temp;
                temp = mass.Max();
                Console.WriteLine("Максимальное значение массива = " + temp);
            }
            void insert_mass()
            {
                Random r = new Random();
                for (int i = 0; i < n; i++) mass[i] = r.Next(0, 500);
                Console.WriteLine("Массив заполнен");
                foreach (int k in mass) Console.Write(" " + k);
                Console.WriteLine();
            }
        }
    }
}
