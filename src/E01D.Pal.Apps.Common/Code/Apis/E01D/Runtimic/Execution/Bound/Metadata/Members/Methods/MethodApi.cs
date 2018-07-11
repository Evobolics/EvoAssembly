using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods.Getting;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
	public class MethodApi<TContainer> : BindingApiNode<TContainer>, MethodApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	    public BuildingApi_I<TContainer> Building { get; set; }

	    BuildingApiMask_I MethodApiMask_I.Building => Building;

	    public GettingApi_I<TContainer> Getting { get; set; }

	    GettingApiMask_I MethodApiMask_I.Getting => Getting;

		public SemanticMethodMask_I FindMethodByDefinition(InfrastructureModelMask_I model, BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods, MethodDefinition methodDefinition)
		{
			

            if (!boundTypeWithMethods.Methods.ByName.TryGetValue(methodDefinition.Name, out List<SemanticMethodMask_I> list))
            {
                throw new System.Exception("Could not find the method.");
            }

            for (int i = 0; i < list.Count; i++)
            {
                var method = list[i];

                if (method.MethodReference == methodDefinition)
                {
                    return method;
                }
            }

            throw new System.Exception("Could not find the method.");
        }
    }
}
