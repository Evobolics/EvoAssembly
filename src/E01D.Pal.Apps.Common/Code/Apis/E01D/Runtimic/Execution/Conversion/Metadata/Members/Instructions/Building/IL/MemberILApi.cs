﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Instructions.Building.IL
{
    public class MemberApi<TContainer> : ConversionApiNode<TContainer>, MemberApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}