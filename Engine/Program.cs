// using System.Data.SqlClient;

using System.Numerics;
using Engine;

Console.WriteLine("Hello, World!");

List<double> l = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

WeightedAverage<double> w = new WeightedAverage<double>((double d) => d, (double i) => 1);

Console.WriteLine(l.Count);
Console.WriteLine(l.Sum());
Console.WriteLine(w.Aggregate(l));

// double ValueGetter1(int index)
// {
//     string query = "Select mileage from cars when id = " + index;
//     using (SqlConnection connection = new SqlConnection("Database=hazoume;Server=.;user=zacha;password=312213"))
//     {
//         SqlCommand command = new SqlCommand(query, connection);
//         command.connection.Open();
//     }
// }

List<TestObject> testObjects = new List<TestObject>();
for (int i = 0; i < 10000; i++)
{
    testObjects.Add(new TestObject());
}

// var stringOrderAggregator =
//     new OrderAggregator<TestObject>((testObject1, testObject2) => string.Compare(testObject1.Str, testObject2.Str));
// List<TestObject> aggregated = stringOrderAggregator.Aggregate(testObjects);
// testObjects.Sort((testObject1, testObject2) => string.Compare(testObject1.Str, testObject2.Str));
// Console.WriteLine("string orderTest = " + aggregated.SequenceEqual(strOrdered));

bool multipleContains(string str, string chars)
{
    foreach (char ch in chars)
    {
        if (str.Contains(ch))
            return true;
    }

    return false;
}

var filterAggregator =
    new FilterAggregator<TestObject>(testObject => multipleContains(testObject.Str, "abcdefghijklmnopqrstuvwxyz"));
// var filtered = filterAggregator.Aggregate(testObjects);
// var Cfiltered = 0;
// var CV = 0;
// foreach (var testObject in filtered)
// {
//     if (testObject.Str.Contains('V'))
//         Cfiltered++;
// }
// foreach (var testObject in testObjects)
// {
//     if (testObject.Str.Contains('V'))
//         CV++;
// }
//
// Console.WriteLine(filtered.Count + CV == testObjects.Count);


SumOfSumsAggregator<TestObject> sumOfSumsAggregator = new SumOfSumsAggregator<TestObject>(o => o.Number);

WeightedAverageDate<TestObject> moy = new WeightedAverageDate<TestObject>(d => d.Date, d=> d.Number);

Console.WriteLine(moy.Aggregate(testObjects).ToString());

void vectorSumTest()
{
    // generate list of vectors
    var random = new Random(1);
    Int32 dim = random.Next(20);
    var vectors = new List<Vector<double>>();
    for (int i = 0; i < 1000; i++)
    {
        var v = new double[dim];
        for (int j = 0; j < dim; j++)
        {
            v[j] = random.NextDouble();
        }
        vectors.Add(new Vector<double>(v));
    }

    var agg = new WeightedAverageVector(v => v, v => random.NextDouble());
    Console.WriteLine(agg.Aggregate(vectors).ToString());
}

vectorSumTest();

WeightedAverageComplex<TestObject> complexSumTest = new WeightedAverageComplex<TestObject>(o => o.Complex, o => o.Number);

Console.WriteLine(complexSumTest.Aggregate(testObjects).ToString());

GeometricAvgAggregator<TestObject> geometricAvgAggregator = new GeometricAvgAggregator<TestObject>(o => o.Id);