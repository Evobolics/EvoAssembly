using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedMethodMask_I: ConvertedMemberMask_I, BoundMethodDefinitionMask_I
    {
        

        

        new ConvertedRoutineParameters_I Parameters { get;  }


    }
}
