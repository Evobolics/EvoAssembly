using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public abstract class ConvertedType: ConvertedMember, ConvertedType_I
    {
        public string AssemblyQualifiedName { get; set; }

        public string FullName { get; set; }
	    public string ResolutionName { get; set; }


		public virtual TypeKind TypeKind { get; set; } = TypeKind.App;

        public MemberKind MemberKind => MemberKind.Type;
        
        
        
    }
}
