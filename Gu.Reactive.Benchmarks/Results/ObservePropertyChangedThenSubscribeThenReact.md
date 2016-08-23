```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515830 ticks, Resolution=284.4279 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1076.0

Type=ObservePropertyChangedThenSubscribeThenReact  Mode=Throughput  

```
                      Method |         Median |        StdDev |   Scaled | Scaled-SD |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
---------------------------- |--------------- |-------------- |--------- |---------- |------- |------ |------ |------------------- |
    SubscribeToEventStandard |     83.1709 ns |     2.7316 ns |     1.00 |      0.00 |   0.95 |     - |     - |              25,33 |
                SimpleLambda | 22,317.8653 ns |   478.7970 ns |   267.38 |     10.10 |  29.50 |  4.75 |     - |             966,00 |
                        Slim |  2,155.5894 ns |    34.1012 ns |    25.84 |      0.90 |  10.96 |     - |     - |             290,58 |
                      Nested | 93,775.6429 ns | 2,129.8626 ns | 1,117.11 |     43.08 | 133.00 | 18.00 |     - |           4 323,77 |
                          Rx | 13,980.6084 ns |   345.8248 ns |   169.28 |      6.69 |  21.04 |  5.06 |     - |             778,20 |
 PropertyChangedEventManager |  3,422.6368 ns |    80.5718 ns |    40.88 |      1.59 |   1.37 |  7.62 |     - |             263,42 |
