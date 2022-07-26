using System.Net.Http.Headers;

namespace Engine;

// public class SumOfSumsAggregator<TValue> : Aggregator<TValue, double>
// {
//     private Func<TValue, double> ValueFunc;
//
//     public SumOfSumsAggregator(Func<TValue, double> valueFunc)
//     {
//         ValueFunc = valueFunc;
//     }
//     public override double Aggregate(List<TValue> items)
//     {
//         double result = 0;
//
//         for (int i = 0; i < items.Count; i++)
//         {
//             double sum = 0;
//             for (int j = 0; j < items.Count; j++)
//             {
//                 sum += ValueFunc(items[i]);
//             }
//             result += sum;
//         }
//         
//         return result;
//     }
// }