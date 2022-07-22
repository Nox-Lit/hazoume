namespace Engine;

public class OrderAggregator<TValue> : Aggregator<TValue, List<TValue>> where TValue : IComparable<TValue>
{
    private Func<TValue, TValue, int> ComparatorFunction;

    // private class Comparator : IComparer<TValue>
    // {
    //     private static Func<TValue, TValue, int> ComparatorFunc { get; set; } = null;
    //     public int Compare(TValue left, TValue right)
    //     {
    //         ComparatorFunc = ComparatorFunction;
    //         return ComparatorFunc(left, right);
    //     }
    // }
    public OrderAggregator(Func<TValue, TValue, int> comparatorFunction)
    {
        this.ComparatorFunction = comparatorFunction;
    }

    public override List<TValue> Aggregate(List<TValue> items)
    {
        return items.OrderBy(t => t).ToList();

        // return items.Sort((value1, value2) => ComparatorFunction(value1, value2));
        // List<TValue> result = new List<TValue>(items);
        // result.Sort((value1, value2) => ComparatorFunction(value1, value2));
        // return result;
    }
}