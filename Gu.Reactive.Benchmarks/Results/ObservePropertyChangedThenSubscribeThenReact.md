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
    SubscribeToEventStandard |     84.9811 ns |     1.9196 ns |     1.00 |      0.00 |   0.81 |     - |     - |              22,98 |
                SimpleLambda | 22,585.6275 ns |   467.6817 ns |   266.96 |      8.09 |  24.88 |  3.99 |     - |             869,52 |
                        Slim |  2,220.1364 ns |    87.1080 ns |    26.39 |      1.17 |  10.06 |     - |     - |             284,28 |
                      Nested | 92,700.7056 ns | 2,436.0669 ns | 1,093.67 |     37.40 | 126.00 | 17.00 |     - |           4 363,34 |
                          Rx | 13,637.4340 ns |   384.1747 ns |   160.86 |      5.73 |  19.89 |  4.79 |     - |             782,90 |
 PropertyChangedEventManager |  3,514.8374 ns |    54.5860 ns |    41.65 |      1.13 |   1.41 |  8.18 |     - |             295,39 |
