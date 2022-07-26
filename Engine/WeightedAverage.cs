namespace Engine;

public class WeightedAverage<TValue> : Aggregator<TValue, dynamic>
{
    private Func<TValue, dynamic> _value;
    private Func<TValue, dynamic> _weight;

    public WeightedAverage(Func<TValue, dynamic> valueFunc, Func<TValue, dynamic> weightFunc)
    {
        _value = valueFunc;
        _weight = weightFunc;
    }

    public override dynamic Aggregate(List<TValue> items)
    {
        if (items.Count == 0)
            throw new EmptyListException("WeightedAverage.Aggregate argument is empty list.");
        dynamic sum = _value(items[0]) * _weight(items[0]);
        dynamic totalWeight = _weight(items[0]);
        for (int i = 1; i < items.Count; i++)
        {
            sum = _value(items[i]) * _weight(items[i]);
            totalWeight = _weight(items[i]);
        }

        return sum / totalWeight;
    }
}

// public class WeightedAverageDate<TValue> : Aggregator<TValue, DateTime>
// {
//     private Func<TValue, DateTime> _value;
//     private Func<TValue, double> _weight;
//
//     public WeightedAverageDate(Func<TValue, DateTime> valueFunc, Func<TValue, double> weightFunc)
//     {
//         _value = valueFunc;
//         _weight = weightFunc;
//     }
//
//     public override DateTime Aggregate(List<TValue> items)
//     {
//         double sum = 0;
//         double totalWeight = 0;
//         foreach (var item in items)
//         {
//             sum += _value(item).Ticks * _weight(item);
//             totalWeight += _weight(item);
//         }
//
//         return new DateTime ((long) (totalWeight == 0 ? 0 : sum / totalWeight));
//     }
// }