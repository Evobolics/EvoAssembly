using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models
{
    public interface InfrastructureModelAssembliesMask_I
    {
        Dictionary<string, SemanticAssemblyMask_I> ByResolutionName { get;  } 

        Dictionary<string, SemanticAssemblyMask_I> ByName { get;  } 

        Dictionary<string, ConvertedAssembly_I> Collectible { get;  } 
        List<SemanticAssemblyMask_I> InDependencyOrder { get;  }
        
    }
}
