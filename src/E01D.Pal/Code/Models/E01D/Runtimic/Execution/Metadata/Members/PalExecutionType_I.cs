using Root.Code.Models.E01D.Reflection.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
    public interface PalExecutionType_I:Type_I
    {
        PalTypeHandle_I TypeHandle { get;  }
    }
}
