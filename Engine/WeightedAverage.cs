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

public class WeightedAverageDate<TValue> : Aggregator<TValue, DateTime>
{
    private Func<TValue, DateTime> _value;
    private Func<TValue, double> _weight;

    public WeightedAverageDate(Func<TValue, DateTime> valueFunc, Func<TValue, double> weightFunc)
    {
        _value = valueFunc;
        _weight = weightFunc;
    }

    public override DateTime Aggregate(List<TValue> items)
    {
        double sum = 0;
        double totalWeight = 0;
        foreach (var item in items)
        {
            sum += _value(item).Ticks * _weight(item);
            totalWeight += _weight(item);
        }

        return new DateTime ((long) (totalWeight == 0 ? 0 : sum / totalWeight));
    }
}