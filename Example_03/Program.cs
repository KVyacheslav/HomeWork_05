using System;
using System.Linq;

namespace Example_03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(RemoveDuplicateLetters("ПППОООГГГООООДДДААА"));
            Console.WriteLine(RemoveDuplicateLetters("Ххххоооорррооошшшиий деееннннь"));
        }

        /// <summary>
        /// Удалить повторяющиеся буквы. 
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <returns>Строка.</returns>
        private static string RemoveDuplicateLetters(string text)
        {
            string result = string.Empty;

            // Если исходный текст пустой или null.
            if (string.IsNullOrEmpty(text))
                return result;                  
            
            result += text[0];                  // Присваиваем первый символ.

            // Если длина исходного текста равна 1.
            if (text.Length == 1)       
                return result;                  

            for (int i = 1; i < text.Length; i++)
            {
                // Если i-ый символ не похож на предыдущий.
                if (Char.ToLower(text[i]) != Char.ToLower(text[i - 1]))
                    result += text[i];          // Добавляем его.
            }

            return result;
        }
    }
}
