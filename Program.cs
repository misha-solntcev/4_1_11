using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Вариант 11
1. Характеристикой столбца целочисленной матрицы назовем сумму модулей его
отрицательных нечетных элементов. Переставляя столбцы заданной матрицы,
расположить их в соответствии с ростом характеристик. 
2. Найти сумму элементов в тех столбцах, которые содержат 
хотя бы один отрицательный элемент. */

namespace _4_1_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                { 4, 5, 2, 3, 1, 6 },
                { 4, -1, 36, 7, 8, 2 },
                { 7, -7, 9, 0, 2, -9 },
                { 12, 0, 3, -5, 5, 4 },
                { 13, 10, 16, 17, 8, 15 }
            };
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);

            // Вычисление характеристик.
            List<int> hars = new List<int>();
            for (int j = 0; j < m; j++)
            {
                int har = 0;
                for (int i = 0; i < n; i++)
                {
                    if ((arr[i, j] < 0) && (arr[i, j] % 2 != 0))
                        har += Math.Abs(arr[i, j]);
                }
                hars.Add(har);
            }
            Console.WriteLine("Характеристики");
            foreach (int har in hars)
                Console.Write($"{har}, ");
            Console.WriteLine();

            // Вычисление индексов
            List<int> harsS = new List<int>();
            harsS.AddRange(hars);
            harsS.Sort();
            List<int> indexes = new List<int>();
            for (int i = 0; i < harsS.Count; i++)            
                for (int j = 0; j < hars.Count; j++)                
                    if (harsS[i] == hars[j])
                        indexes.Add(j);            
            Console.WriteLine("Индексы");
            foreach (int j in indexes)
                Console.Write($"{j}, ");
            Console.WriteLine();

            // Создание отсортированного массива.
            int[,] arrSort = new int[n,m];
            for (int i = 0; i < n; i++)            
                for (int j = 0; j < m; j++)                
                    arrSort[i, j] = arr[i, indexes[j]];            

            // Вывод в консоль начального массива.
            Console.WriteLine($"Исходный массив: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($" {arr[i, j]}, ");
                }
                Console.WriteLine();
            }

            // Вывод в консоль сортированного массива.
            Console.WriteLine($"Сортированный массив: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($" {arrSort[i, j]}, ");
                }
                Console.WriteLine();
            }

            /* Cумма элементов в тех столбцах, которые содержат 
            хотя бы один отрицательный элемент. */
            List<int> summ = new List<int>();
            for (int j = 0; j < m; j++)
            {
                int sum = 0;
                bool flag = false;
                for (int i = 0; i < n; i++)
                {
                    sum += arr[i, j];
                    if (arr[i, j] < 0)
                        flag = true;
                }
                if (flag)
                    summ.Add(sum);                
            }
            Console.WriteLine("Суммы");
            foreach (int sum in summ)
                Console.Write($"{sum}, ");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}