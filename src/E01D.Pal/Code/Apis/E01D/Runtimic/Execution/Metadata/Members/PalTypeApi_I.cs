using Root.Code.Models.E01D.Reflection.Members;
using Root.Code.Models.E01D.Reflection.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members
{
    public interface PalTypeApi_I
    {
        Type_I TypeOf<T>();
        Type_I GetTypeFromHandle(PalTypeHandle_I bucketApiTypeHandle);
        Type_I MakeGenericType(Type_I genericIpiHubEntryType, Type_I apiType);
        Type_I GenericTypeOf<T>();
        PalPropertyInfo_I GetProperty(Type_I ipiHubEntryType, string ipis);
    }
}
