using System.Net.Http.Headers;

namespace Engine;

// public class TrivaleursAggregator<TValue> : Aggregator<TValue, double>
// {
//     private Func<TValue, double> func1;
//     private Func<TValue, double> func2;
//
//     public TrivaleursAggregator(Func<TValue, double> func1, Func<TValue, double> func2)
//     {
//         this.func1 = func1;
//         this.func2 = func2;
//     }
//
//     public override double Aggregate(List<TValue> items)
//     {
//         double sum = 0;
//         for (int i = 0; i < items.Count; i++)
//         {
//             sum += func1(items[i]) * func2(items[i]) * i;
//         }
//
//         return sum;
//     }
// }