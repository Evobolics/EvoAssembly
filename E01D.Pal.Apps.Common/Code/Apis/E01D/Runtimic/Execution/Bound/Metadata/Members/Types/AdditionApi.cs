using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
	public class AdditionApi<TContainer> : BindingApiNode<TContainer>, AdditionApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
        

        public T Add<T>(Dictionary<string, T> results, T entry)
            where T : TypeMask_I
        {
			

	        var resolutionName = entry.ResolutionName();

	        if (resolutionName == null)
	        {
		        throw new System.Exception("Resolution name cannot be null.");
	        }

	        

			results.Add(resolutionName, entry);

            return entry;
        }

        public Dictionary<string, SemanticTypeMask_I> Add(Dictionary<string, SemanticTypeMask_I> results, Dictionary<string, SemanticTypeMask_I> dependencies)
        {
            foreach (var entry in dependencies.Values)
            {
                if (!results.TryGetValue(entry.ResolutionName(), out SemanticTypeMask_I typeEntry))
                {
                    results.Add(entry.ResolutionName(), entry);
                }
            }

            return dependencies;
        }

        public SemanticTypeMask_I Add(InfrastructureModelMask_I semanticModel, SemanticModuleMask_I module, SemanticTypeDefinitionMask_I entry)
        {
            Add(module.Types.ByResolutionName, entry);

			Models.Types.Collection.Add(semanticModel, entry);

            if (entry.IsDefinition() && entry is SemanticTypeDefinitionMask_I definitionMask)
            {
                Add(module.Types.DefinitionsByName, definitionMask);

                //Models.Types.Ensure(semanticModel, definitionMask);
                
            }

            if (entry.IsReference() && entry is TypeReferenceMask_I referenceMask)
            {
                Add(module.Types.ReferencesByName, referenceMask);
            }

            

            return entry;
        }
    }
}
