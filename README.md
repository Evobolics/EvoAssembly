# EvoAssembly [Beta]
Convert Compiled .NET Assemblies to Collectible Assemblies

```csharp
// 1) Create a Conversion Container
var container = XEvoAssembly.CreateContainer();              

// 2) Create a Conversion Container
var conversionResult = container.ConvertType(type);

// 3) Get the Assembly
var collectibleAssembly = conversionResult.Assemblies[0];
```

## Known Issues

* calli instruction not implemented yet
* anything resolving around unsafe code not implemented / tested yet
* no p-invoke support yet
* full attribute support still in progress
