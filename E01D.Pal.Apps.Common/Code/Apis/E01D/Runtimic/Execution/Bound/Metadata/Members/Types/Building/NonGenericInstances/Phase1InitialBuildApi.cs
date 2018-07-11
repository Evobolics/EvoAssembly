using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Building.NonGenericInstances
{
	public class Phase1InitialBuildApi<TContainer> : BindingApiNode<TContainer>, Phase1InitialBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public BoundTypeDefinition Build(InfrastructureModelMask_I semanticModel, BoundTypeDefinition bound, Type underlyingType, BoundTypeDefinitionMask_I declaringType)
		{
			if (bound.IsNestedType())
			{
				if (declaringType == null)
				{
					throw new Exception("Declaring type is null.  Cannot create a nested type.");
				}

				var nestedType = (BoundTypeDefinitionWithDeclaringType_I)bound;

				nestedType.DeclaringType = declaringType;
			}

			bound.UnderlyingType = underlyingType;

			if (underlyingType == null) return bound;

			Members.TypeParameters.Building.EnsureTypeParametersIfAny(semanticModel, bound);

			Fields.Building.NonGeneric.BuildFields(semanticModel, bound);

			Constructors.Building.RuntimeCreated.BuildConstructors(semanticModel, bound);

			Methods.Building.RuntimeCreated.BuildMethods(semanticModel, bound);

			return bound;
		}
	}
}
