namespace Engine;

public class EmptyListException : Exception
{
    public EmptyListException(string message){}
}

public abstract class Aggregator<TValue, TReturn>
{
    public abstract dynamic Aggregate(List<TValue> items);
}