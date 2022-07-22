namespace Engine;

public abstract class Aggregator<TValue, TReturn>
{
    public abstract TReturn Aggregate(List<TValue> items);
}