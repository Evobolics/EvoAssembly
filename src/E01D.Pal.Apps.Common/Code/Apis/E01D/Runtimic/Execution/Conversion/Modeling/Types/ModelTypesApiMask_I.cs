using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.Types
{
    public interface ModelTypesApiMask_I
    {
        

        SemanticTypeDefinitionMask_I Get(RuntimicSystemModel conversion, string typeDefinitionFullName);

        

        System.Type GetBoundUnderlyingTypeOrThrow(SemanticTypeMask_I semanticType);
        BoundTypeDefinitionMask_I GetBoundTypeOrThrow(SemanticTypeMask_I semanticType, bool allowNulls);

        SemanticTypeMask_I GetOrThrow(RuntimicSystemModel conversion, string typeDefinitionFullName);

        

        TypeReference GetTypeReference(ILConversion conversion, Type input);

	    TypeReference GetTypeReference(ILConversion conversion, Type input,
		    out SemanticTypeDefinitionMask_I possibleSemanticType);


		

		



		TypeDefinition ResolveToTypeDefinition(RuntimicSystemModel model, TypeReference typeReference);

        bool TryGet(RuntimicSystemModel model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry);

        

        bool TryGet(RuntimicSystemModel model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry);


        
    }
}
