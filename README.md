# EvoAssembly
Convert Compiled .NET Assemblies to Collectible Assemblies

```csharp
// 1) Create a Conversion Container
var container = XEvoAssembly.CreateContainer();              

// 2) Create a Conversion Container
var conversionResult = container.ConvertType(type);

// 3) Get the Assembly
var collectibleAssembly = conversionResult.Assemblies[0];
```
