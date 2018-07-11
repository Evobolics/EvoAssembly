using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata
{
    public interface EmittedAssembly_I:BoundAssemblyMask_I
    {
        new bool IsBuiltOut { get; set; }
    }
}
