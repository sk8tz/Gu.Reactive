namespace Gu.Reactive.Benchmarks
{
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main(string[] name)
        {
            BenchmarkRunner.Run<ObservePropertyChanged>();
        }
    }
}
