```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515830 ticks, Resolution=284.4279 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1076.0

Type=Get  Mode=Throughput  

```
             Method |        Median |      StdDev |   Scaled | Scaled-SD |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------------- |-------------- |------------ |--------- |---------- |------- |------ |------ |------------------- |
               Func |     2.1479 ns |   0.0861 ns |     1.00 |      0.00 |      - |     - |     - |               0,00 |
     ValueOrDefault | 7,597.6559 ns | 205.1573 ns | 3,502.63 |    161.29 | 123.00 |     - |     - |             470,92 |
 GetValueCachedPath |   213.2784 ns |   3.1826 ns |    98.25 |      3.98 |   5.00 |     - |     - |              19,25 |
