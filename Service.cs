public class Service
{
    // Приватные поля класса
    private int _id;
    private string _name;
    private decimal _price;
    private string _category;
    private double _rating;
    private bool _isAvailable;

    // Конструктор для инициализации полей
    public Service(int id, string name, decimal price, string category, double rating, bool isAvailable)
    {
        _id = id;
        _name = name;
        _price = price;
        _category = category;
        _rating = rating;
        _isAvailable = isAvailable;
    }

    // Свойства для доступа к полям  (Только для чтения)
    public int Id => _id;  
    public string Name => _name; 
    public decimal Price => _price; 
    public string Category => _category; 
    public double Rating => _rating; 
    public bool IsAvailable => _isAvailable; 

    public override string ToString()
    {
        return $"ID: {Id}, Название: {Name}, Цена: {Price:C}, Категория: {Category}, Рейтинг: {Rating:F1}, Доступна: {IsAvailable}";
    }
}
