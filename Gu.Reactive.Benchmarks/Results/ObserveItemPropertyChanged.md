```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515830 ticks, Resolution=284.4279 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1076.0

Type=ObserveItemPropertyChanged  Mode=Throughput  

```
               Method |      Median |    StdDev |
--------------------- |------------ |---------- |
            AddSimple |  98.6177 us | 1.7327 us |
            AddNested |  94.2493 us | 0.6374 us |
 AddNestedThatUpdates | 150.7341 us | 2.3311 us |
