namespace Engine;

public class WeightedAverage<TValue> : Aggregator<TValue, double>
{
    private Func<TValue, double> _value;
    private Func<TValue, double> _weight;

    public WeightedAverage(Func<TValue, double> valueFunc, Func<TValue, double> weightFunc)
    {
        _value = valueFunc;
        _weight = weightFunc;
    }

    public override double Aggregate(List<TValue> items)
    {
        double sum = 0;
        double totalWeight = 0;
        foreach (var item in items)
        {
            sum += _value(item) * _weight(item);
            totalWeight += _weight(item);
        }

        return totalWeight == 0 ? 0 : sum / totalWeight;
    }
}