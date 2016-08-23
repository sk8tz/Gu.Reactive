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
 SubscribeToEventStandard |    83.1548 ns | 10.0644 ns |   1.00 |      0.00 |
             SimpleLambda | 3,971.7910 ns | 31.6953 ns |  44.94 |      4.63 |
             SimpleString |   357.5139 ns |  1.6268 ns |   4.04 |      0.42 |
               SimpleSlim |   136.0666 ns |  2.0974 ns |   1.52 |      0.16 |
