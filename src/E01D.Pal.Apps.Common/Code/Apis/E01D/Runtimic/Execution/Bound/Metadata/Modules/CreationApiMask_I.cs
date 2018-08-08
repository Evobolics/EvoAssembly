using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface CreationApiMask_I
    {
		

	    BoundModule Create(RuntimicSystemModel runtimicSystem, BoundModuleNode moduleDefinition);
    }
}
