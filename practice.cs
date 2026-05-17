using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    // Задание 1
    /*
    internal class Program1
    {
        static void CompressArray(int[] array)
        {
            Console.WriteLine("Исходный массив: " + string.Join(" ", array));

            int index = 0; 

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    array[index] = array[i];
                    index++;
                }
            }

            for (int i = index; i < array.Length; i++)
            {
                array[i] = -1;
            }

            Console.WriteLine("Сжатый массив: " + string.Join(" ", array));
        }

        static void Main()
        {
            int[] arr1 = { 1, 0, 2, 0, 3, 0, 4, 5 };
            int[] arr2 = { 0, 0, 1, 2, 0, 3, 0, 0 };
            int[] arr3 = { 1, 2, 3, 4, 5 };
            int[] arr4 = { 0, 0, 0, 0 };

            CompressArray(arr1);
            Console.WriteLine();
            CompressArray(arr2);
            Console.WriteLine();
            CompressArray(arr3);
            Console.WriteLine();
            CompressArray(arr4);
        }
    }
    */

    // Задание 2
    /*
    internal class Program2
    {
        static int[] ReorderArray(int[] array)
        {
            int[] result = new int[array.Length];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    result[index] = array[i];
                    index++;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    result[index] = array[i];
                    index++;
                }
            }

            return result;
        }
        static void Main()
        {
            int[] arr1 = { 1, -2, 3, -4, 5, -6, 0, -8 };
            int[] arr2 = { -1, -2, -3, 4, 5, 6 };
            int[] arr3 = { 1, 2, 3, -4, -5, -6 };

            Console.WriteLine("Исходный массив: " + string.Join(" ", arr1));
            Console.WriteLine("Результат (способ 1): " + string.Join(" ", ReorderArray(arr1)));

        }
    }
    */
    // Задание 3
    /*
    internal class Program3
    {

        static int CountOccurrences(int[] array, int number)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    count++;
            }
            return count;
        }


        static void DisplayArrayWithHighlight(int[] array, int number)
        {
            Console.Write("Массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(array[i] + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine();
        }

        static void Main()
        {
            int[] numbers = { 1, 2, 3, 2, 4, 2, 5, 6, 2, 7, 8, 2, 9 };

            while (true)
            {
                Console.WriteLine("\nИсходный массив: " + string.Join(" ", numbers));
                Console.Write("Введите число для поиска (или 'q' для выхода): ");

                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                    break;

                if (int.TryParse(input, out int searchNumber))
                {
                    int count = CountOccurrences(numbers, searchNumber);

                    Console.WriteLine("\nРезультат поиска:");
                    DisplayArrayWithHighlight(numbers, searchNumber);
                    Console.WriteLine($"Число {searchNumber} встречается {count} раз(а)");

                    if (count == 0)
                        Console.WriteLine("Такого числа нет в массиве!");
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите целое число.");
                }
            }

            Console.WriteLine("\nПрограмма завершена.");
        }
    }
    */

    // Задание 4
    internal class Program4
    {
        // Метод для вывода двумерного массива
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }

        // Метод для обмена столбцов
        static void SwapColumns(int[,] matrix, int col1, int col2)
        {
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                int temp = matrix[i, col1];
                matrix[i, col1] = matrix[i, col2];
                matrix[i, col2] = temp;
            }
        }

        // Метод для создания тестовой матрицы
        static int[,] CreateTestMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(10, 100);
                }
            }

            return matrix;
        }

        static void Main()
        {

            int M = 4; 
            int N = 5; 
            int[,] matrix = CreateTestMatrix(M, N);

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            Console.Write($"\nВведите первый столбец для обмена (0-{N - 1}): ");
            int col1 = int.Parse(Console.ReadLine());

            Console.Write($"Введите второй столбец для обмена (0-{N - 1}): ");
            int col2 = int.Parse(Console.ReadLine());

            // Проверка корректности ввода
            if (col1 < 0 || col1 >= N || col2 < 0 || col2 >= N)
            {
                Console.WriteLine("Ошибка! Некорректные номера столбцов.");
                return;
            }

            if (col1 == col2)
            {
                Console.WriteLine("Столбцы одинаковые, обмен не требуется.");
                return;
            }

            // Выполняем обмен
            SwapColumns(matrix, col1, col2);

            Console.WriteLine($"\nМатрица после обмена столбцов {col1} и {col2}:");
            PrintMatrix(matrix);

        }
    }
}
