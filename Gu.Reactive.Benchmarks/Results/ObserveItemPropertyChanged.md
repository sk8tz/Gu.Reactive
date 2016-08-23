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
               Method |      Median |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------------- |------------ |---------- |------- |------ |------ |------------------- |
            AddSimple |  98.5992 us | 2.2606 us | 100.90 |     - |     - |           6 021,65 |
            AddNested |  93.5113 us | 1.7252 us |  84.00 | 10.08 |     - |           5 521,96 |
 AddNestedThatUpdates | 149.4769 us | 1.8636 us | 130.00 | 21.00 |     - |           9 071,45 |
