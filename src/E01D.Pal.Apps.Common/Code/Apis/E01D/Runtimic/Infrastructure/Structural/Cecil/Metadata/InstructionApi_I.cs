using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
    public interface InstructionApi_I<TContainer> : InstructionApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
