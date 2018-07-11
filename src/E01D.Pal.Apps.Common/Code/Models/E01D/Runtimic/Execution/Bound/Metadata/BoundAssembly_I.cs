using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
    public interface BoundAssembly_I: SemanticAssembly_I, BoundAssemblyMask_I
    {
        new bool IsBuiltOut { get; set; }
    }
}
