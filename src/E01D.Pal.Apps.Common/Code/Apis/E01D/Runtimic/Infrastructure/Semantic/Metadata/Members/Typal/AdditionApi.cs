using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public class AdditionApi<TContainer> : SemanticApiNode<TContainer>, AdditionApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public T Add<T>(Dictionary<string, T> dictionary, T entry)
            where T : TypeMask_I
        {
            string key = entry.ResolutionName();


            dictionary.Add(key, entry);

            return entry;
        }

        public Dictionary<string, T> Add<T>(Dictionary<string, T> results, Dictionary<string, T> dependencies)
            where T : TypeMask_I
        {
            foreach (var entry in dependencies.Values)
            {
                if (!results.TryGetValue(entry.ResolutionName(), out T typeEntry))
                {
                    results.Add(entry.ResolutionName(), entry);
                }
            }

            return dependencies;
        }

        public SemanticTypeMask_I Add(InfrastructureModelMask_I model, SemanticModuleMask_I module, SemanticTypeDefinitionMask_I entry)
        {
            
            // 1.) Add the semantic type to the module

            // 1.a)  Add by resolution name
            Add(module.Types.ByResolutionName, entry);
            // 1.b) Add by defintion name
            Add(module.Types.DefinitionsByName, entry);

            // 2) Add the semantic to type to the base class
            // nothin to do right now
            
            // 3) Add semantic type to model 
            Infrastructure.Models.Semantic.Types.Ensure(model, entry);

            return entry;

        }
    }
}
