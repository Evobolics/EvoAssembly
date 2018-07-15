using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public interface GettingApi_I<TContainer> : GettingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    Assembly GetCorrespondingOutput(ILConversionResult result, Assembly assembly);
    }
}
