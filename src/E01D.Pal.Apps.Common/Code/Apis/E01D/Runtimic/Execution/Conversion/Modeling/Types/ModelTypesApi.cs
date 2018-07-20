using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.Types
{
    public class ModelTypesApi<TContainer> : ConversionApiNode<TContainer>, ModelTypesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

        

       

        public SemanticTypeDefinitionMask_I Get(InfrastructureRuntimicModelMask_I model, string resolutionName)
        {
            return Infrastructure.Models.Semantic.Types.Collection.Get(model, resolutionName);
        }

        

        public SemanticTypeMask_I GetOrThrow(InfrastructureRuntimicModelMask_I model, string resolutionName)
        {
            return Infrastructure.Models.Semantic.Types.Collection.GetOrThrow(model, resolutionName);
        }

        

        

        

        public System.Type GetBoundUnderlyingTypeOrThrow(SemanticTypeMask_I semanticType)
        {
            return Binding.Models.Types.GetBoundUnderlyingTypeOrThrow(semanticType);
        }

        public BoundTypeDefinitionMask_I GetBoundTypeOrThrow(SemanticTypeMask_I semanticType, bool allowNulls)
        {
            return Binding.Models.Types.GetBoundTypeOrThrow(semanticType, allowNulls);
        }

		public TypeReference GetTypeReference(ILConversion conversion, Type input)
		{
			return Binding.Models.Types.GetTypeReference(conversion.Model, input);
		}

	    public TypeReference GetTypeReference(ILConversion conversion, Type input, out SemanticTypeDefinitionMask_I possibleSemanticType)
	    {
		    return Binding.Models.Types.GetTypeReference(conversion.Model, input, out possibleSemanticType);
	    }


		public TypeDefinition ResolveToTypeDefinition(InfrastructureRuntimicModelMask_I model, TypeReference typeReference)
	    {
		    if (typeReference.IsDefinition)
		    {
			    return (TypeDefinition)typeReference;
		    }

		    var storedReference = Cecil.Types.Getting.GetStoredTypeReference(model, typeReference);

		    if (storedReference.IsDefinition)
		    {
			    return (TypeDefinition)storedReference;
		    }

		    throw new Exception("Could not resolve the type reference to a type definition.");
	    }

		public bool TryGet(InfrastructureRuntimicModelMask_I model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry)
        {
            string resolutionName = Types.Naming.GetResolutionName(input);

            return TryGet(model, resolutionName, out typeEntry);
        }
	
        public bool TryGet(InfrastructureRuntimicModelMask_I model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry)
        {
            typeEntry = Get(model, resolutionName);

            return typeEntry != null;
        }

        

        
    }
}
