using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface SemanticAssemblyAssembliesMask_I
    {
        Dictionary<string, SemanticAssemblyMask_I> Referenced { get; }

        Dictionary<string, SemanticAssemblyMask_I> Referencing { get; }
    }
}
