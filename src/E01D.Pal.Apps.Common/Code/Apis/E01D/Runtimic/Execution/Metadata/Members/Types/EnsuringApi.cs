using System;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using GatheringApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering.GatheringApiMask_I;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types
{
	public class EnsuringApi<TContainer> : ExecutionApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {

	    public BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, System.Type type)
	    {
		    var typeReference = Bound.Models.Types.GetTypeReference(conversion.Model, type, out SemanticTypeDefinitionMask_I possibleSemanticType);

		    if (possibleSemanticType != null && possibleSemanticType is BoundTypeDefinitionMask_I bound1)
		    {
			    return bound1;
		    }

		    return Execution.Types.Ensuring.EnsureBound(conversion, typeReference);
	    }





	    public System.Type EnsureToType(ILConversion conversion, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType)
	    {
		    boundType = Execution.Types.Ensuring.EnsureBound(conversion, typeReference);

		    return EnsureToType(conversion, boundType);
	    }

	    public System.Type EnsureToType(ILConversion conversion, TypeReference typeReference)
	    {
		    var boundType = Execution.Types.Ensuring.EnsureBound(conversion, typeReference);

		    return EnsureToType(conversion, boundType);
	    }

	    public System.Type EnsureToType(ILConversion conversion, SemanticTypeDefinitionMask_I semanticType)
	    {
		    if (!(semanticType is BoundTypeDefinitionMask_I bound))
		    {
			    throw new Exception("A semantic type must be a bound type to be resolved to a runtime type.");
		    }

		    return EnsureToType(conversion, bound);
	    }

	    // TODO: Rename to GetRuntimeType
	    public System.Type EnsureToType(ILConversion conversion, BoundTypeDefinitionMask_I semanticType)
	    {
		    return Bound.Models.Types.ResolveToType(conversion.Model, semanticType);
	    }


		public BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference typeReference)
	    {
		    return EnsureBound(conversion.Model, typeReference, null);
	    }

		public BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I semanticModel, System.Type type)
	    {
		    throw new Exception("Debug");
			//var typeReference = Cecil.Types.Getting.GetTypeReference(semanticModel, type);

			//return EnsureBound(semanticModel, typeReference, type);
		}


	    public BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I semanticModel, TypeReference typeReference, System.Type type)
	    {
		    var semanticMask = Ensure(semanticModel, typeReference, type, null);

		    if (!(semanticMask is BoundTypeDefinitionMask_I bound))
		    {
			    throw new Exception($"Expected the resolved semantic type of type '{semanticMask.GetType()}' to be a bound type definition.");
		    }

		    return bound;
	    }

	    /// <summary>
	    /// Ensures the type is part of the module.
	    /// </summary>
	    /// <param name="semanticModel"></param>
	    /// <param name="semanticModule"></param>
	    /// <param name="input"></param>
	    /// <returns></returns>
	    public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, Type input)
	    {
			var typeReference = Bound.Models.Types.GetTypeReference(semanticModel, input);

		    return Ensure(semanticModel, typeReference, input, null);
	    }

		

	    

		public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I boundModel, TypeReference typeReference, System.Type underlyingType, BoundTypeDefinitionMask_I declaringType)
		{
			// Check to see if this input is to be converted, or needs to be relegated to bound only.
			if (Types.IsConverted(boundModel, typeReference)) // The call does not belong to the conversion code because 
			{
				var conversionModel = (ILConversionRuntimicModel)boundModel;

				return Conversion.Metadata.Members.Types.Ensuring.Ensure(conversionModel.Conversion, typeReference, (ConvertedTypeDefinition_I)declaringType);

			}
			else
			{
				return Bound.Metadata.Members.Types.Ensuring.Ensure(boundModel, typeReference, underlyingType, declaringType);
			}
			
		}











	}
}
