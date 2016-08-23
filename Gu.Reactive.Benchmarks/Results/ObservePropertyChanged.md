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
 SubscribeToEventStandard |    82.4727 ns |   8.1506 ns |   1.00 |      0.00 |  12.54 |     - |     - |              22,87 |
             SimpleLambda | 3,998.5971 ns | 123.8606 ns |  46.53 |      4.26 | 143.00 |     - |     - |             269,94 |
             SimpleString |   349.8084 ns |   7.0000 ns |   4.10 |      0.36 |  45.89 |     - |     - |              82,07 |
               SimpleSlim |   138.5132 ns |   1.9926 ns |   1.61 |      0.14 |  25.25 |     - |     - |              45,13 |
