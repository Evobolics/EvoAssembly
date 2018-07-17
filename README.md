# EvoAssembly [Beta]
Convert Compiled .NET Assemblies to Collectible Assemblies

## Examples
The following examples demonstrate how to convert type and assemblies into their convertible counterparts.

```csharp
using Root.Code.PI.E01D; // Programmer Interface
```

```csharp
// Example1: Convert a type
var convertedType = EvoAssembly.QuickConvert(inputType);

// Example2: Convert an assembly
var convertedAssembly = EvoAssembly.QuickConvert(inputAssembly);

// Example3: Convert an array of types
var convertedTypes = EvoAssembly.QuickConvert(new []{inputType1, inputType2});

// Example4: Convert an array of assemblies
var convertedAssemblies = EvoAssembly.QuickConvert(new []{inputAssembly1, inputAssembly2});
      
```

## Known Issues / To-Do List

* calli instruction not implemented yet
* anything resolving around unsafe code not implemented / tested yet
* no p-invoke support yet
* full attribute support still in progress
* no support for modifiers yet
* whole assembly level conversion is having issues with generics from a non converted assembly with type arguments from a converted assembly.
*Last Updated:* July 15th, 2018
