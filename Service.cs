using System;

namespace CatalogOfServices
{
    public class Service
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public string Category { get; set; } 
        public double Rating { get; set; } 
        public bool IsAvailable { get; set; } 

        public Service(int id, string name, decimal price, string category, double rating, bool isAvailable)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            Rating = rating;
            IsAvailable = isAvailable;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Название: {Name}, Цена: {Price:C}, Категория: {Category}, Рейтинг: {Rating:F1}, Доступность: {IsAvailable}";
        }
    }
}