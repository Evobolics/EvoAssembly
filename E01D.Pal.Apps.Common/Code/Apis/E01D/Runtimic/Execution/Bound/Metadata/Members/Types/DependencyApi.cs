using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
	public class DependencyApi<TContainer> : BindingApiNode<TContainer>, DependencyApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
        public List<SemanticTypeMask_I> Calculate(SemanticTypeMask_I convertedModule, List<SemanticTypeMask_I> list)
        {
            throw new System.NotImplementedException();
        }

        public void PutInDependencyOrder(List<SemanticTypeMask_I> list)
        {
            //Sorting.Quick.Sort(list, (x, y) => x.Dependencies.Count - y.Dependencies.Count);
        }

        public void Add(SemanticTypeMask_I typeDefinitionEntry, SemanticTypeMask_I dependent)
        {
            //if (!typeDefinitionEntry.Dependencies.TryGetValue(dependent.ResolutionName(), out SemanticNodeBaseMask_I node1))
            //{
            //    typeDefinitionEntry.Dependencies.Add(dependent.ResolutionName(), dependent);
            //}

            //if (!dependent.Dependencies.TryGetValue(typeDefinitionEntry.ResolutionName(), out SemanticNodeBaseMask_I node2))
            //{
            //    dependent.Dependencies.Add(typeDefinitionEntry.ResolutionName(), typeDefinitionEntry);
            //}
        }
    }
}
