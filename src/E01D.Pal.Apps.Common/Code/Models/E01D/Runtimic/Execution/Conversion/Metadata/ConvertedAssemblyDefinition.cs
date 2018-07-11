using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedAssemblyDefinition:ConversionNode
    {
        public AssemblyDefinition AssemblyDefinition { get; set; }
        public AssemblyBuilder AssemblyBuilder { get; set; }

        public AssemblyEntryAssemblies Assemblies { get; set; } = new AssemblyEntryAssemblies();

        public Dictionary<string, ConvertedModule> Modules { get; set; } = new Dictionary<string, ConvertedModule>();

        public AssemblyEntryTypes Types { get; set; } = new AssemblyEntryTypes();

        public string Name { get; set; }
        public string ResolutionName { get; set; }
        public Assembly Assembly { get; set; }
    }
}
