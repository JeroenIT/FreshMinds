var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();



app.MapGet("/", () => "Welkom op de API");
app.MapGet("/users", () => new List<string> { "Alice", "Bob", "Charlie" });
app.MapGet("/activities", () => new List<Activity>()
{
    new Activity("Barbeque", "Eindhoven", 14.99, 5, "12-7-2025"),
    new Activity("Spelletjesavond", "Eindhoven", 9.99, 3, "15-7-2025"),
    new Activity("Filmavond", "Eindhoven", 19.99, 4, "20-7-2025"),
    new Activity("Concert", "Utrecht", 13.99, 50, "5-8-2025"),
});

app.MapGet("/objects", () => new List<User>()
{
    new User("Alice", 30),
    new User("Bob", 25),
    new User("Charlie", 35)
});
app.Run("http://0.0.0.0:5000");

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class Activity
{
    public string Name { get; set; }
    public string Place { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public string Date { get; set; }

    public Activity(string name, string place, double price, int amount, string date)
    {
        Name = name;
        Place = place;
        Amount = amount;
        Price = price;
        Date = date;
    }
}