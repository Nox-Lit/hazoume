namespace Engine;

public class TestObject
{
    public string Str { get; set; }
    public int Id { get; set; }
    public double Number { get; set; }
    public DateTime Date { get; set; }
    public static int Count { get; private set; }

    static TestObject()
    {
        Count = 0;
    }

    public TestObject()
    {
        Str = RandomString(Random.Next(20));
        Id = Count++;
        Number = Random.NextDouble(); //+ Random.Next(Int32.MinValue, Int32.MaxValue);
        Date = new DateTime(Random.NextInt64(DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks));
        
    }

    ~TestObject()
    {
        Count--;
    }

    private static Random Random = new Random();

    private static string RandomString(int length)
    {
        // return new string(Enumerable.Repeat(chars, length)
        //     .Select(s => s[Random.Next(s.Length)]).ToArray());
        
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[length];

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[Random.Next(chars.Length)];
        }

        return new String(stringChars);
    }
}