using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public class GettingApi<TContainer> : BoundApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public SemanticMethodMask_I FindMethodByDefinition(InfrastructureRuntimicModelMask_I model, BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods, MethodDefinition methodDefinition)
		{
			if (!boundTypeWithMethods.Methods.ByName.TryGetValue(methodDefinition.Name, out List<SemanticMethodMask_I> list))
			{
				throw new Exception($"Could not find the method named {methodDefinition.Name}.");
			}

			for (int i = 0; i < list.Count; i++)
			{
				var method = list[i];

				if (Cecil.Metadata.Members.Methods.AreSame(model, methodDefinition, method.MethodReference, false))
				{
					return method;
				}
			}

			throw new Exception("Could not find the method.");
		}
	}
}
