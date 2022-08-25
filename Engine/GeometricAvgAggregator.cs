namespace Engine;

public class GeometricAvgAggregator<TValue> : Aggregator<TValue, double>
{
    private Func<TValue, double> _value;

    public GeometricAvgAggregator(Func<TValue, double> valueFunc)
    {
        _value = valueFunc;
    }

    public override double Aggregate(List<TValue> items)
    {
        double result = 1;
        for (int i = 0; i < items.Count; i++)
        {
            result = result * _value(items[i]);
        }
        return Math.Pow(result, 1.0/items.Count);
    }
}