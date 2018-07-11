using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public class SemanticAssemblyAssemblies: SemanticAssemblyAssembliesMask_I
    {
        public Dictionary<string, SemanticAssemblyMask_I> Referenced { get; set; } = new Dictionary<string, SemanticAssemblyMask_I>();

        public Dictionary<string, SemanticAssemblyMask_I> Referencing { get; set; } = new Dictionary<string, SemanticAssemblyMask_I>();
    }
}
