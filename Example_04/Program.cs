using System;

namespace Example_04
{
    public class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Список аргументов.</param>
        public static void Main(string[] args)
        {

            #region Проверка

            // Для проверки
            //Console.WriteLine(IsArithmeticProgression(new[] { 1, 2, 3, 4, 5 }));    //True
            //Console.WriteLine(IsArithmeticProgression(new[] { 1, 3, 5, 7, 9 }));    //True
            //Console.WriteLine(IsArithmeticProgression(new[] { -3, -5, -7, -9 }));    //True
            //Console.WriteLine(IsArithmeticProgression(new[] { -3, -6, 3, -9 }));    //False

            //Console.WriteLine(IsGeometricProgression(new[] { 1, 2, 4, 8, 16 }));    //True
            //Console.WriteLine(IsGeometricProgression(new[] { 3, 9, 27, 81, 243 }));    //True
            //Console.WriteLine(IsGeometricProgression(new[] { -1, -3, -9, -27, -81 }));    //True
            //Console.WriteLine(IsGeometricProgression(new[] { -1, -3, -9, -27, -242 }));    //False

            #endregion

            int[] array = GetArray();
            FillArray(array);

            Console.WriteLine(IsArithmeticProgression(array)
                ? "Является арифметической прогрессией."
                : "Не является арифметической прогрессией.");

            Console.WriteLine(IsGeometricProgression(array)
                ? "Является геометрической прогрессией."
                : "Не является геометрической прогрессией.");
        }

        /// <summary>
        /// Проверка на "Арифметическую прогрессию"
        /// </summary>
        /// <param name="array">Исходный массив.</param>
        /// <returns>true или false.</returns>
        public static bool IsArithmeticProgression(int[] array)
        {
            if (array.Length < 3)
            {
                Console.WriteLine("Длина массива должно быть 2.");
                return false;
            }

            int delta = array[1] - array[0];    // Инициализировать шаг.

            for (int i = 2; i < array.Length; i++)
            {
                // Если текущий шаг не равен предыдущему.
                if (array[i] - array[i - 1] != delta)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка на "Геометрическую прогрессию"
        /// </summary>
        /// <param name="array">Исходный массив.</param>
        /// <returns>true или false.</returns>
        public static bool IsGeometricProgression(int[] array)
        {
            if (array.Length < 3)
            {
                Console.WriteLine("Длина массива должно быть 2.");
                return false;
            }
            
            if (array[0] == 0)
                return false;

            int delta = array[1] / array[0];    // Инициализировать шаг.

            for (int i = 2; i < array.Length; i++)
            {
                // Если предыдущее значение равняется 0.
                if (array[i - 1] == 0)
                    return false;

                // Если текущий шаг не равен предыдущему.
                if (array[i] / array[i - 1] != delta)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Заполнить массив значениями.
        /// </summary>
        /// <param name="array">Исходный массив.</param>
        private static void FillArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Введите значение {i + 1}-го элемента: ");
                array[i] = GetUserInput();
            }
        }

        /// <summary>
        /// Инициализировать массив.
        /// </summary>
        /// <returns></returns>
        private static int[] GetArray()
        {
            Console.Write("Введите длину массива, (должна быть больше 2): ");
            int len = GetUserInput(false);

            return new int[len];
        }

        /// <summary>
        /// Получить число пользователя.
        /// </summary>
        /// <param name="isFillArray">Для заполнения массива?</param>
        /// <returns>Число.</returns>
        private static int GetUserInput(bool isFillArray = true)
        {
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (userInput < 3 && !isFillArray)
                {
                    Console.Write("Значение должно быть больше 2: ");
                    return GetUserInput(false);
                }

                return userInput;
            }

            Console.Write("Значение должно быть числовое: ");
            return GetUserInput(isFillArray);
        }
    }
}
