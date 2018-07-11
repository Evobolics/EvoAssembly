using System.Reflection;
using Root.Code.Models.E01D.Reflection.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members
{
    public interface PalMethodApi_I
    {
        PalMethodInfo_I GetMethod(MethodInfo propertyInfoGetMethod);
        object Invoke(PalMethodInfo_I method, object bucket);

        object Invoke(PalMethodInfo_I method, object bucket, object[] args);
    }
}
