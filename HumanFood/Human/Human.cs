using HumanFood.Food;

namespace HumanFood.Human;

internal record Human(List<IFood> Foods) : IHuman, IFeed, IDisposable
{
    private bool _disposed;
    private static byte Id { get; set; }
    private string Name { get; } = ++Id + ".";
    public void Answer() => Console.WriteLine("#{0} {1}", Name, string.Join(", ", Foods));
    public void Eat(IFood food) => Foods.Add(food);
    public void Dispose()
    {
        if (_disposed) 
        { 
            return;
        }

        Console.WriteLine("Disposed:#{0} Count: {1}", Name, Foods.Count);
        Foods.Clear();
        _disposed = true;
    }
}