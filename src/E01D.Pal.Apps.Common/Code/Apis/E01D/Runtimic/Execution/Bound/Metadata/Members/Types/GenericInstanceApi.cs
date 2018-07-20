using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	/// <summary>
	/// Provides functionality to manipulate types that are generic instances - i.e. closed generics
	/// </summary>
	/// <typeparam name="TContainer"></typeparam>
	public class GenericInstanceApi<TContainer> : BoundApiNode<TContainer>, GenericInstanceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeDefinition GetElementType(InfrastructureRuntimicModelMask_I semanticModel, BoundTypeDefinitionMask_I bound)
		{
			return Infrastructure.Semantic.Metadata.Members.Types.GenericInstances.GetElementType(semanticModel, bound);

		}

		public TypeDefinition GetElementType(InfrastructureRuntimicModelMask_I model, GenericInstanceType genericInstanceType)
		{
			return Infrastructure.Semantic.Metadata.Members.Types.GenericInstances.GetElementType(model, genericInstanceType);
		}

		
	}
}
