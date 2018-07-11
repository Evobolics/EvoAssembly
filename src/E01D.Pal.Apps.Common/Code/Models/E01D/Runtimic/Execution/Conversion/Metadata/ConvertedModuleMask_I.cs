using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public interface ConvertedModuleMask_I:BoundModuleMask_I
    {
	    ModuleBuilder ModuleBuilder { get; }

	    new ConvertedModuleTypes_I Types { get; }
	}
}
