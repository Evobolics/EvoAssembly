# EvoAssembly [Beta]
Convert Compiled .NET Assemblies to Collectible Assemblies

```csharp
// Example1: Convert a type
var convertedType = EvoAssembly.QuickConvert(inputType);

// Example2: Convert an assembly
var convertedAssembly = EvoAssembly.QuickConvert(inputAssembly);
```

## Known Issues / To-Do List

* calli instruction not implemented yet
* anything resolving around unsafe code not implemented / tested yet
* no p-invoke support yet
* full attribute support still in progress
* no support for modifiers yet

*Last Updated:* July 15th, 2018
