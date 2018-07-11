using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface GettingApiMask_I
    {
        
        /// <summary>
        /// Gets the semantic type that is specifically associated with the module.
        /// </summary>
        /// <param name="semanticModel"></param>
        /// <param name="module"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        SemanticTypeMask_I Get(InfrastructureModelMask_I semanticModel, SemanticModuleMask_I module, TypeReference input);
    }
}
