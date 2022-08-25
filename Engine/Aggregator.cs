namespace Engine;

public abstract class Aggregator<TValue, TReturn>
{
    public abstract TReturn Aggregate(List<TValue> items);
}

public abstract class DAggregator
{
    public abstract dynamic Aggregate(List<dynamic> items);
} 