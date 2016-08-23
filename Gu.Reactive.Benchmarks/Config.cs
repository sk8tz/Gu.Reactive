namespace Gu.Reactive.Benchmarks
{
    using BenchmarkDotNet.Configs;

    public class Config : ManualConfig
    {
        public Config()
        {
            this.Add(new BenchmarkDotNet.Diagnostics.Windows.MemoryDiagnoser());
        }
    }
}