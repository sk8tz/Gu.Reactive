namespace Gu.Reactive.Benchmarks
{
    using System.IO;

    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main()
        {
            Run<ObservePropertyChanged>();
            //BenchmarkRunner.Run<MinTracker>();


            //BenchmarkRunner.Run<ObservePropertyChangedThenSubscribe>();
            //BenchmarkRunner.Run<ObservePropertyChangedThenSubscribeThenReact>();
            //BenchmarkRunner.Run<ObserveItemPropertyChanged>();
        }

        private static void Run<T>()
        {
            BenchmarkRunner.Run<ObservePropertyChanged>();
            CopyResult<T>();
        }

        private static void CopyResult<T>()
        {
#if DEBUG
#else

            var sourceFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "BenchmarkDotNet.Artifacts", "results", typeof(T).Name + "-report-github.md");
            var destinationDirectory = System.IO.Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Results");
            System.IO.Directory.CreateDirectory(destinationDirectory);
            var destinationFileName = System.IO.Path.Combine(destinationDirectory, typeof(T).Name + ".md");
            File.Copy(sourceFileName, destinationFileName);
#endif
        }
    }
}
