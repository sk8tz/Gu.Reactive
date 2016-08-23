```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515830 ticks, Resolution=284.4279 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1076.0

Type=ObservePropertyChangedThenSubscribe  Mode=Throughput  

```
                      Method |         Median |      StdDev | Scaled | Scaled-SD | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
---------------------------- |--------------- |------------ |------- |---------- |------ |------ |------ |------------------- |
    SubscribeToEventStandard |     82.3399 ns |   1.9619 ns |   1.00 |      0.00 |  3.28 |     - |     - |              23,40 |
                 SimpleLamda | 25,434.0464 ns | 923.5807 ns | 309.97 |     13.20 |     - | 98.00 |     - |             827,39 |
                SimpleString | 15,436.9558 ns | 938.9138 ns | 189.19 |     11.97 |     - | 56.54 |     - |             598,28 |
                  SimpleSlim |  4,533.3815 ns | 196.0730 ns |  55.19 |      2.66 |     - | 34.96 |     - |             314,29 |
                          Rx | 14,673.2676 ns | 428.5858 ns | 178.49 |      6.58 |     - | 54.28 |     - |             545,17 |
 PropertyChangedEventManager |  2,973.1339 ns |  46.2633 ns |  36.09 |      1.01 |  4.81 | 22.37 |     - |             210,58 |
