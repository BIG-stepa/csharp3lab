using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogOfServices
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = DatabaseHelper.ReadData(); // Загрузка данных из файла

            while (true)
            {
                Console.WriteLine("\n--- Каталог Услуг ---");
                Console.WriteLine("1. Просмотреть все услуги");
                Console.WriteLine("2. Добавить новую услугу");
                Console.WriteLine("3. Удалить услугу по ID");
                Console.WriteLine("4. Выполнить запросы");
                Console.WriteLine("5. Выйти");

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllServices(services);
                        break;
                    case "2":
                        AddService(services);
                        break;
                    case "3":
                        RemoveService(services);
                        break;
                    case "4":
                        RunQueries(services);
                        break;
                    case "5":
                        DatabaseHelper.SaveData(services); // Сохранение данных перед выходом
                        Console.WriteLine("Выход...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void ViewAllServices(List<Service> services)
        {
            if (services.Count == 0)
            {
                Console.WriteLine("Нет доступных услуг.");
                return;
            }

            // Форматируем заголовки таблицы
            Console.WriteLine(
                string.Format(
                    "{0,-5} | {1,-20} | {2,-10} | {3,-15} | {4,-8} | {5,-15}",
                    "ID", "Название", "Цена", "Категория", "Рейтинг", "Доступность"
                )
            );
            Console.WriteLine(new string('-', 84)); // Разделительная линия 

            // Выводим каждую услугу в формате таблицы
            foreach (var service in services)
            {
                Console.WriteLine(
                    string.Format(
                        "{0,-5} | {1,-20} | {2,-10:C} | {3,-15} | {4,-8:F1} | {5,-15}",
                        service.Id,
                        Truncate(service.Name, 20), // Обрезаем длинные названия для читаемости
                        service.Price,
                        Truncate(service.Category, 15), // Обрезаем длинные категории
                        service.Rating,
                        service.IsAvailable ? "Да" : "Нет"
                    )
                );
            }
        }

        // Метод для обрезания строк до указанной длины
        static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value; // Защита от null или пустой строки
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "..."; // Добавляем многоточие
        }

        static void AddService(List<Service> services)
        {
            try
            {
                int id = InputValidator.GetInt("Введите ID: ");
                string name = InputValidator.GetString("Введите название услуги: ");
                decimal price = InputValidator.GetDecimal("Введите цену: ");
                string category = InputValidator.GetString("Введите категорию: ");
                double rating = InputValidator.GetDoubleInRange("Введите рейтинг (от 0 до 5): ", 0, 5);
                bool isAvailable = InputValidator.GetBool("Доступна ли услуга? (true/false): ");

                services.Add(new Service(id, name, price, category, rating, isAvailable));
                Console.WriteLine("Услуга успешно добавлена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении услуги: {ex.Message}");
            }
        }

        static void RemoveService(List<Service> services)
        {
            try
            {
                int id = InputValidator.GetInt("Введите ID услуги для удаления: ");

                var serviceToRemove = services.FirstOrDefault(s => s.Id == id); // Поиск услуги по ID
                if (serviceToRemove != null)
                {
                    services.Remove(serviceToRemove);
                    Console.WriteLine("Услуга успешно удалена.");
                }
                else
                {
                    Console.WriteLine("Услуга не найдена.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении услуги: {ex.Message}");
            }
        }

        static void RunQueries(List<Service> services)
        {
            Console.WriteLine("\n--- Запросы ---");
            Console.WriteLine("1. Получить услуги по категории");
            Console.WriteLine("2. Получить услуги с рейтингом выше заданного значения");
            Console.WriteLine("3. Получить общее количество доступных услуг");
            Console.WriteLine("4. Получить среднюю цену всех услуг");

            Console.Write("Выберите запрос: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string category = InputValidator.GetString("Введите категорию: ");
                    var categoryServices = services.Where(s => s.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
                    Console.WriteLine($"\n--- Услуги в категории '{category}' ---");
                    ViewAllServices(categoryServices); 
                    break;

                case "2":
                    double minRating = InputValidator.GetDoubleInRange("Введите минимальный рейтинг (от 0 до 5): ", 0, 5);
                    var highRatedServices = services.Where(s => s.Rating > minRating).ToList();
                    Console.WriteLine($"\n--- Услуги с рейтингом выше {minRating} ---");
                    ViewAllServices(highRatedServices); 
                    break;

                case "3":
                    int availableCount = services.Count(s => s.IsAvailable); // Подсчет доступных услуг через LINQ
                    Console.WriteLine($"\nОбщее количество доступных услуг: {availableCount}");
                    break;

                case "4":
                    decimal averagePrice = services.Average(s => s.Price); // Вычисление средней цены через LINQ
                    Console.WriteLine($"\nСредняя цена всех услуг: {averagePrice:C}");
                    break;

                default:
                    Console.WriteLine("Неверный выбор запроса.");
                    break;
            }
        }
    }
}
