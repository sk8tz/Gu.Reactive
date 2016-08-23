```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515830 ticks, Resolution=284.4279 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1076.0

Type=NameOf  Mode=Throughput  

```
             Method |        Median |      StdDev | Scaled | Scaled-SD |
------------------- |-------------- |------------ |------- |---------- |
 UsingCsharp6Nameof |     0.0000 ns |   0.0226 ns |      ? |         ? |
           Property | 3,634.7273 ns |  71.8230 ns |      ? |         ? |
     PropertyNested | 5,568.7215 ns | 107.6515 ns |      ? |         ? |
