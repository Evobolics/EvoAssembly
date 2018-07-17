using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties
{
    public interface PropertyApiMask_I
    {
        //void DeclareAll(ModuleEntry module);

        BuildingApiMask_I Building { get; }

        TypeScanningApiMask_I TypeScanning { get; }

	    BoundPropertyDefinitionMask_I GetBoundProperty(BoundTypeDefinitionMask_I converted, string namedArgumentName);
    }
}
