using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
	/// <summary>
	/// Provides functionality to manipulate types that are generic instances - i.e. closed generics
	/// </summary>
	/// <typeparam name="TContainer"></typeparam>
	public class GenericInstanceApi<TContainer> : BindingApiNode<TContainer>, GenericInstanceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeDefinition GetElementType(InfrastructureModelMask_I semanticModel, BoundTypeDefinitionMask_I bound)
		{
			return Infrastructure.Semantic.Metadata.Members.Types.GenericInstances.GetElementType(semanticModel, bound);

		}

		public TypeDefinition GetElementType(InfrastructureModelMask_I model, GenericInstanceType genericInstanceType)
		{
			return Infrastructure.Semantic.Metadata.Members.Types.GenericInstances.GetElementType(model, genericInstanceType);
		}

		
	}
}
