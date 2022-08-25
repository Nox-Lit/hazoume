using System.Net.Http.Headers;

namespace Engine;

public class ExtractAggregator<TValue> : Aggregator<TValue, (List<TValue>, List<TValue>)>
{
    private Func<TValue, TValue> comparatorFunction;
    private int Count;

    public ExtractAggregator(Func<TValue, TValue> comparatorFunction, int count)
    {
        this.comparatorFunction = comparatorFunction;
        this.Count = count;
    }

    public override (List<TValue>, List<TValue>) Aggregate(List<TValue> items)
    {
        var ordered = items.OrderBy(comparatorFunction);

        return (ordered.Take(Count).ToList(), ordered.TakeLast(items.Count - Count).ToList());
    }
}