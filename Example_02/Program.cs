using System;
using System.Linq;
using System.Net.Http.Headers;

namespace Example_02
{
    public class Program
    {
        private static char[] symbols;

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Список аргументов.</param>
        public static void Main(string[] args)
        {
            // Список сепараторов.
            symbols = new[] { ' ', ',', '.', '!', '@', '?', '/', '\\', '(', ')' };


            // Исходный текст из примера.
            string message = "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ";
            // Получить слово с наименьшей длиной.
            string minWord = GetWordWithMinLength(message);
            // Вывести слово с минимальной длиной на консоль.
            Console.WriteLine($"Слово с минимальной длиной: {minWord}.");
            // Получить массив слов с максимальной длиной.
            string[] maxWords = GetWordsWithMaxLength(message);
            // Выводим все слова с максимальной длиной.
            Console.WriteLine($"Слово(а) с максимальной длиной: {string.Join(", ", maxWords)}");

            // Вводим свой текст.
            Console.Write("Введите любой текст, для нахождения слова с минимальным количеством символов: ");
            message = Console.ReadLine();
            // Получить слово с наименьшей длиной.
            minWord = GetWordWithMinLength(message);
            // Вывести значение на консоль.
            Console.WriteLine($"Слово с наименьшим количеством символов: {minWord}");

            Console.ReadLine();

        }

        /// <summary>
        /// Получить слово с наименьшим количеством букв.
        /// </summary>
        /// <param name="message">Исходный текст.</param>
        /// <returns>Слово с минимальным количеством букв.</returns>
        private static string GetWordWithMinLength(string message)
        {
            var words = message.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
            string minWord = words[0];

            foreach (var word in words)
            {
                if (word.Length < minWord.Length)
                    minWord = word;
            }

            return minWord;
        }

        /// <summary>
        /// Возвращает массив слов с наибольшим количеством букв.
        /// </summary>
        /// <param name="message">Исходный текст.</param>
        /// <returns>Массив слов.</returns>
        private static string[] GetWordsWithMaxLength(string message)
        {
            var words = message.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
            var maxLength = words.Max(word => word.Length);
            return words.Where(word => word.Length == maxLength).ToArray();
        }
    }
}
