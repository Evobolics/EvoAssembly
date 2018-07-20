using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Metadata.Members;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata.Members
{
    public class EmittedType: EmittedMember, EmittedType_I, EmittedTypeClassifier_I, SemanticTypeDefinitionBase_I
    {
        public string AssemblyQualifiedName { get; set; }

        public string FullName { get; set; }
        

        public SemanticModuleMask_I Module { get; set; }


        public string ResolutionName { get; set; }

        public virtual TypeKind TypeKind { get; set; } = TypeKind.App;

        public MemberKind MemberKind => MemberKind.Type;

        public TypeReference SourceTypeReference { get; set; }
        public ModuleDefinition SourceModuleDefinition { get; set; }

        public PackingSize PackingSize { get; set; }
        public Dictionary<string, SemanticTypeMask_I> NestedTypes { get; set; }

	    public Dictionary<int, SemanticArrayTypeDefinitionMask_I> Arrays { get; set; } =
		    new Dictionary<int, SemanticArrayTypeDefinitionMask_I>();
	}
}
