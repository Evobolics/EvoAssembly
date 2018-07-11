using System.Collections.Generic;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public abstract class BoundType:BoundMember, BoundType_I
    {
        public abstract TypeKind TypeKind { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public string FullName { get; set; }
        
        public MemberKind MemberKind => MemberKind.Type;


        public SemanticTypeMask_I BaseType { get; set; }

	    public string ResolutionName { get; set; }
		public System.Type UnderlyingType { get; set; }

        public Dictionary<string, SemanticTypeMask_I> NestedTypes { get; set; } = new Dictionary<string, SemanticTypeMask_I>();
        public TypeReference SourceTypeReference { get; set; }

        public ModuleDefinition SourceModuleDefinition { get; set; }

        public BoundModuleMask_I Module { get; set; }

        public PackingSize PackingSize { get; set; }

        


    }
}
