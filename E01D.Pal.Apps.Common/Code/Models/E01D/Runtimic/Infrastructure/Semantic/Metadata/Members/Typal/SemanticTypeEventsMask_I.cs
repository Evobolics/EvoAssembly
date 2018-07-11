using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface SemanticTypeEventsMask_I
    {
	    Dictionary<string, List<SemanticEventMask_I>> ByName { get; }
	}
}
