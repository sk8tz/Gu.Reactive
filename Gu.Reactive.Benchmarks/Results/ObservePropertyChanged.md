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
                   Method |        Median |      StdDev | Scaled | Scaled-SD |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------------------- |-------------- |------------ |------- |---------- |------- |------ |------ |------------------- |
 SubscribeToEventStandard |    91.3786 ns |  10.4195 ns |   1.00 |      0.00 |  14.01 |     - |     - |              22,98 |
             SimpleLambda | 4,077.2601 ns | 106.7068 ns |  44.94 |      5.15 | 159.00 |     - |     - |             269,95 |
             SimpleString |   370.1997 ns |  17.2364 ns |   4.11 |      0.50 |  50.99 |     - |     - |              82,07 |
               SimpleSlim |   138.5438 ns |   5.2796 ns |   1.54 |      0.18 |  29.93 |     - |     - |              48,14 |
