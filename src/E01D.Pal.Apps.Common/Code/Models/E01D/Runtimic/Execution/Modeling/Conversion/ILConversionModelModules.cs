using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion
{
    public class ILConversionModelModules: SemanticModelModulesMask_I
    {
        public Dictionary<string, ModuleDefinition> DefinitionsByName { get; set; } = new Dictionary<string, ModuleDefinition>();
    }
}
