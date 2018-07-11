using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.CustomAttributes
{
    public interface CustomAttributeApi_I<TContainer>: CustomAttributeApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        

        

    }
}
