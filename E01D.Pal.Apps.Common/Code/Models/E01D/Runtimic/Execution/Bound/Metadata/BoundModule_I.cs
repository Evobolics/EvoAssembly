using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
    public interface BoundModule_I: SemanticModule_I, BoundModuleMask_I
    {
        new bool IsBuiltOut { get; set; }

        
        
    }
}
