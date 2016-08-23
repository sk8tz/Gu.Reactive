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
                      Method |         Median |      StdDev | Scaled | Scaled-SD |
---------------------------- |--------------- |------------ |------- |---------- |
    SubscribeToEventStandard |     80.4657 ns |   1.6316 ns |   1.00 |      0.00 |
                 SimpleLamda | 24,751.0741 ns | 586.1700 ns | 306.22 |      9.09 |
                SimpleString | 14,891.6794 ns | 293.9072 ns | 185.29 |      4.95 |
                  SimpleSlim |  4,372.3622 ns | 137.0797 ns |  53.53 |      1.93 |
                          Rx | 14,771.3348 ns | 324.0056 ns | 182.17 |      5.18 |
 PropertyChangedEventManager |  2,967.5906 ns |  37.7324 ns |  36.70 |      0.82 |
