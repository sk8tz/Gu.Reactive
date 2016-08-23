namespace Gu.Reactive.Benchmarks
{
    using System.IO;
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main()
        {
            var switcher = new BenchmarkSwitcher(typeof(Program).Assembly);
            var summaries = switcher.Run(new[] { "Diff" });
            foreach (var summary in summaries)
            {
                CopyResult(summary.Title);
            }

            // BenchmarkRunner.Run<ObservePropertyChanged>();
        }

        private static void Run<T>()
        {
            BenchmarkRunner.Run<T>();
            CopyResult(typeof(T).Name);
        }

        private static void CopyResult(string name)
        {
#if DEBUG
#else
            var sourceFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "BenchmarkDotNet.Artifacts", "results", name + "-report-github.md");
            var destinationDirectory = System.IO.Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Results");
            System.IO.Directory.CreateDirectory(destinationDirectory);
            var destinationFileName = System.IO.Path.Combine(destinationDirectory, name + ".md");
            File.Copy(sourceFileName, destinationFileName, true);
#endif
        }
    }
}
