namespace Gu.Reactive.Benchmarks
{
    using BenchmarkDotNet.Configs;

    public class MemoryDiagnoseConfig : ManualConfig
    {
        public MemoryDiagnoseConfig()
        {
            this.Add(new BenchmarkDotNet.Diagnostics.Windows.MemoryDiagnoser());
        }
    }
}