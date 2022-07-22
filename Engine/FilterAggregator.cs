namespace Engine;

public class FilterAggregator<TValue> : Aggregator<TValue, List<TValue>>
{
    private Func<TValue, bool> filter;

    public FilterAggregator(Func<TValue, bool> filter)
    {
        this.filter = filter;
    }

    public override List<TValue> Aggregate(List<TValue> items)
    {
        List<TValue> filtered = new List<TValue>(items);
        foreach (var item in items)
        {
            if (filter(item))
                filtered.Remove(item);
        }
        return filtered;
    }
}