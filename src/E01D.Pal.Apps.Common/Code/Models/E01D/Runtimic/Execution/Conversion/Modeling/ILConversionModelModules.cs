using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling
{
    public class ILConversionModelModules: SemanticModelModulesMask_I
    {
        public Dictionary<string, ModuleDefinition> DefinitionsByName { get; set; } = new Dictionary<string, ModuleDefinition>();
    }
}
