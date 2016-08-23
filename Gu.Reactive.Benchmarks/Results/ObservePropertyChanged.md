```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515830 ticks, Resolution=284.4279 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1076.0

Type=ObservePropertyChanged  Mode=Throughput  

```
                   Method |        Median |     StdDev | Scaled | Scaled-SD |
------------------------- |-------------- |----------- |------- |---------- |
 SubscribeToEventStandard |    81.1682 ns |  0.9271 ns |   1.00 |      0.00 |
             SimpleLambda | 4,040.3026 ns | 52.9850 ns |  49.70 |      0.84 |
             SimpleString |   358.4087 ns |  0.9459 ns |   4.41 |      0.05 |
               SimpleSlim |   136.0643 ns |  0.7336 ns |   1.68 |      0.02 |
             NestedLambda | 6,896.5336 ns | 48.0776 ns |  84.70 |      1.10 |
         NestedCachedPath |   408.7631 ns |  4.2130 ns |   5.07 |      0.08 |
