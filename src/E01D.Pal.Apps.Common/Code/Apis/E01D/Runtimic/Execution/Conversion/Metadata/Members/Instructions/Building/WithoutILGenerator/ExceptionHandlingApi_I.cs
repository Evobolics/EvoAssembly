using Root.Code.Containers.E01D.Runtimic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator
{
    public interface ExceptionHandlingApi_I<TContainer> : ExceptionHandlingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
