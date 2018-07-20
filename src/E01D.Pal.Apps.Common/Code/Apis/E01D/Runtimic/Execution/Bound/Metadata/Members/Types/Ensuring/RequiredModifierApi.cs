using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
	public class RequiredModifierApi<TContainer> : BoundApiNode<TContainer>, RequiredModifierApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType)
		{
			//  Try to see if the model is already present
			if (Models.Types.Collection.TryGet(semanticModel, input, out SemanticTypeDefinitionMask_I maskedType))
			{
				if (!(maskedType is BoundTypeDefinitionMask_I boundType))
				{
					throw new System.Exception(
						$"The type {input.FullName} was found in the conversion model, but it is not a bound type definition.  " +
						$"A bound type is required due to the need for a underlying type when creating type builders.");
				}

				return boundType;
			}

			//---------------------------------
			// Conversion is going to occur.
			//---------------------------------

			var bound = Types.Creation.Create(semanticModel, input, underlyingType);



			// Add the type instance to the model.  Do not do any recursive calls till this methods is called.
			//Types.Addition.Add(semanticModel, boundModule, bound);

			// Done on purpose to find errors
			var requiredModifierType = (RequiredModifierType)input;



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

			Members.TypeParameters.Building.EnsureTypeParametersIfAny(semanticModel, bound);







			return bound;
		}
	}
}
