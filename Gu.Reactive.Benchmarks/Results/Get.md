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
             Method |    Median |    StdDev | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------------- |---------- |---------- |------ |------ |------ |------------------- |
               Func |        NA |        NA |     - |     - |     - |                NaN |
     ValueOrDefault | 7.9002 us | 0.2194 us |  0.00 |     - |     - |             470,92 |
 GetValueCachedPath |        NA |        NA |     - |     - |     - |                NaN |

Benchmarks with issues:
  Get_Func
  Get_GetValueCachedPath
