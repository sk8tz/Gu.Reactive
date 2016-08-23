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
    SubscribeToEventStandard |     80.9196 ns |   1.2968 ns |   1.00 |      0.00 |  3.15 |     - |     - |              22,47 |
                 SimpleLamda | 24,387.5797 ns | 349.1653 ns | 301.05 |      6.25 |     - | 95.91 |     - |             809,81 |
                SimpleString | 15,049.8603 ns | 370.2551 ns | 186.51 |      5.29 |     - | 57.30 |     - |             603,57 |
                  SimpleSlim |  4,302.2806 ns | 124.0732 ns |  53.44 |      1.70 |     - | 35.98 |     - |             321,43 |
                          Rx | 15,442.9407 ns | 725.0235 ns | 190.62 |      9.24 |     - | 59.00 |     - |             592,49 |
 PropertyChangedEventManager |  2,990.7566 ns |  64.0817 ns |  36.78 |      0.95 |  2.57 | 27.28 |     - |             212,68 |
