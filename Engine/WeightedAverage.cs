using System.Numerics;

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
        return items.Select(i => _value(i) * _weight(i)).Sum() / items.Select(i => _weight(i)).Sum();

        // double sum = 0;
        // double totalWeight = 0;
        // foreach (var item in items)
        // {
        //     sum += _value(item) * _weight(item);
        //     totalWeight += _weight(item);
        // }
        //
        // return totalWeight == 0 ? 0 : sum / totalWeight;
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

public class WeightedAverageComplex<TValue> : Aggregator<TValue, Complex>
{
    private Func<TValue, Complex> _value;
    private Func<TValue, double> _weight;

    public WeightedAverageComplex(Func<TValue, Complex> valueFunc, Func<TValue, double> weightFunc)
    {
        _value = valueFunc;
        _weight = weightFunc;
    }

    public override Complex Aggregate(List<TValue> items)
    {
        Complex sum = 0;
        double totalWeight = 0;
        foreach (var item in items)
        {
            sum += _value(item) * _weight(item);
            totalWeight += _weight(item);
        }

        return sum / totalWeight;
    }
}

public class WeightedAverageVector : Aggregator<Vector<double>, Vector<double>>
{
    private Func<Vector<double>, Vector<double>> _value;
    private Func<Vector<double>, double> _weight;

    public WeightedAverageVector(Func<Vector<double>, Vector<double>> valueFunc, Func<Vector<double>, double> weightFunc)
    {
        _value = valueFunc;
        _weight = weightFunc;
    }

    public override Vector<double> Aggregate(List<Vector<double>> items)
    {
        Vector<double> addVect(Vector<double> v1, Vector<double> v2)
        {
            return v1 + v2;
        }
        return items.Select(i => _value(i) * _weight(i)).Aggregate(addVect) * (1 / items.Select(i => _weight(i)).Sum());
    }
}