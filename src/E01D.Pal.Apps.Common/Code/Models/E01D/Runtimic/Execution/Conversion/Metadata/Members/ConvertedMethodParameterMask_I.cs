using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedMethodParameterMask_I: BoundMethodParameterMask_I
    {
        ParameterBuilder Builder { get;  }
    }
}
