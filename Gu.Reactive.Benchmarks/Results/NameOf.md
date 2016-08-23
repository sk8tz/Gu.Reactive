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
             Method |        Median |     StdDev | Scaled | Scaled-SD |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------------- |-------------- |----------- |------- |---------- |------- |------ |------ |------------------- |
 UsingCsharp6Nameof |     0.0008 ns |  0.0391 ns |      ? |         ? |      - |     - |     - |               0,00 |
           Property | 3,543.8276 ns | 28.8444 ns |      ? |         ? | 107.43 |     - |     - |             210,37 |
     PropertyNested | 5,843.5959 ns | 74.5650 ns |      ? |         ? | 217.00 |     - |     - |             377,80 |
