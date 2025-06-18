var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var activities = new List<Activity>()
{
    new Activity("Barbeque", "Eindhoven", 14.99, 5, "12-7-2025"),
    new Activity("Spelletjesavond", "Eindhoven", 9.99, 3, "15-7-2025"),
    new Activity("Filmavond", "Eindhoven", 19.99, 4, "20-7-2025"),
    new Activity("Concert", "Utrecht", 13.99, 50, "5-8-2025")
};
var duties = new List<Duty>()
{
    //new Duty("naam", "beschrijving", aantal mensen, prioriteit, taakgrootte, "datum"),
    new Duty("lamp vervangen", "keuken", 2, "ja","geen expert", "11-6-2025"),
    new Duty("badkamer schoonmaken", "hoofdlamp", 2, "nee","geen expert", "12-6-2025"),
    new Duty("kapotte koelkast maken", "keuken", 3, "ja","expert", "30-6-2025")
};
app.MapPost("/activities", async (Activity newActivity) =>
{
    System.Console.WriteLine($"Nieuwe activiteit ontvangen: {newActivity.Name}");
    activities.Add(newActivity);
    await Task.Delay(5);
    return Results.Created($"/activities/{newActivity.Name}", newActivity);
});

app.MapPost("/duties", async (Duty newDuty) =>
{
    System.Console.WriteLine($"Nieuwe taken ontvangen: {newDuty.Name}");
    duties.Add(newDuty);
    await Task.Delay(5);
    return Results.Created($"/duties/{newDuty.Name}", newDuty); 
});

app.MapGet("/", () => "Welkom op de API");
app.MapGet("/activities", () => activities);
app.MapGet("/duties", () => duties);

app.Run("http://0.0.0.0:5000");

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

public class Duty
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int AmountOfPeople { get; set; }
    public string Priority { get; set; }
    public string TaskSize { get; set; }
    public string Date { get; set; }

    public Duty(string name, string description, int amountOfPeople, string priority, string taskSize, string date)
    {
        Name = name;
        Description = description;
        AmountOfPeople = amountOfPeople;
        Priority = priority;
        TaskSize = taskSize;
        Date = date;
    }
}