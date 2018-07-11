using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface SemanticTypeMask_I: SemanticMemberMask_I, TypeMask_I
    {
        

	    string ResolutionName { get;  }
	}
}
