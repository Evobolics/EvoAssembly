using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
    public interface ModelTypesApiMask_I
    {
	    CollectionApiMask_I Collection { get; }

	    



		

        void Ensure(RuntimicSystemModel semanticModel, SemanticTypeDefinitionMask_I semanticType);

        

        ModuleDefinition GetModuleFromType(RuntimicSystemModel semanticModel, string resolutionName);

        

        TypeReference GetTypeReference(RuntimicSystemModel model, Type input);

	    TypeReference GetTypeReference(RuntimicSystemModel model, Type input, out SemanticTypeDefinitionMask_I semanticType);



		Type ResolveToType(RuntimicSystemModel model, SemanticTypeDefinitionMask_I semanticType);
    }
}
