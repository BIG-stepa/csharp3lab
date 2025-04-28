using System;

namespace CatalogOfServices
{
    public static class InputValidator
    {
        // Получает целое число от пользователя
        public static int GetInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt); 
                string input = Console.ReadLine(); 
  
                if (int.TryParse(input, out result))
                {
                    return result; 
                }

                Console.WriteLine("Ошибка: Введите целое число."); 
            }
        }

        // Получает число с плавающей точкой от пользователя
        public static decimal GetDecimal(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                // Проверяет, является ли ввод корректным числом с плавающей точкой
                if (decimal.TryParse(input, out result))
                {
                    return result;
                }

                Console.WriteLine("Ошибка: Введите число с плавающей точкой.");
            }
        }

        // Получает число типа double в указанном диапазоне
        public static double GetDoubleInRange(string prompt, double min, double max)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (double.TryParse(input, out result) && result >= min && result <= max)
                {
                    return result;
                }

                Console.WriteLine($"Ошибка: Введите число в диапазоне от {min} до {max}.");
            }
        }

        // Получает непустую строку от пользователя
        public static string GetString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                // Проверяет, что строка не пустая или не состоит только из пробелов
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Ошибка: Поле не может быть пустым.");
            }
        }

        // Получает логическое значение (true/false) от пользователя
        public static bool GetBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "true" || input == "false")
                {
                    return input == "true"; 
                }

                Console.WriteLine("Ошибка: Введите 'true' или 'false'.");
            }
        }
    }
}
