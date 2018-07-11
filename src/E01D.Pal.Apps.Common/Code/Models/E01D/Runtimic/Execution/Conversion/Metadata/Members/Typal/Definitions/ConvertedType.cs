using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal
{
    public abstract class ConvertedType: ConvertedMember, ConvertedType_I
    {
        public ConvertedType()
        {
                
        }

        public string AssemblyQualifiedName { get; set; }

        public string FullName { get; set; }

        

        public virtual TypeKind TypeKind { get; set; } = TypeKind.App;

        public MemberKind MemberKind => MemberKind.Type;
        
        public SemanticModuleMask_I Module { get; set; }
        public SemanticTypeMask_I BaseType { get; set; }
        

        public Dictionary<string, SemanticTypeMask_I> NestedTypes { get; set; } = new Dictionary<string, SemanticTypeMask_I>();
        

        public PackingSize PackingSize { get; set; }
        
    }
}
