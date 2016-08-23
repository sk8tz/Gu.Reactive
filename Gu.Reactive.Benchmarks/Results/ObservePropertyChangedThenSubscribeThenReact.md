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
                      Method |         Median |        StdDev |   Scaled | Scaled-SD |
---------------------------- |--------------- |-------------- |--------- |---------- |
    SubscribeToEventStandard |     82.3409 ns |     1.6097 ns |     1.00 |      0.00 |
                SimpleLambda | 22,221.2563 ns |   633.1684 ns |   267.98 |      9.08 |
                        Slim |  2,188.2329 ns |    45.8947 ns |    26.64 |      0.74 |
                      Nested | 90,368.1680 ns | 2,098.6517 ns | 1,101.61 |     32.57 |
                          Rx | 13,270.8494 ns |   223.2375 ns |   162.04 |      4.07 |
 PropertyChangedEventManager |  3,338.3535 ns |    65.4092 ns |    40.42 |      1.09 |
