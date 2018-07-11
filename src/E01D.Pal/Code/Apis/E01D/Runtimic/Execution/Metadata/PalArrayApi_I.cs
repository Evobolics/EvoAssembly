using System;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata
{
    public interface PalArrayApi_I
    {
        Array CreateInstance(Type_I apiType, long length);
    }
}
