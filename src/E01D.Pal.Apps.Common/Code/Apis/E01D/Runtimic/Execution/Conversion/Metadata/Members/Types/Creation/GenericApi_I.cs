﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
	public interface GenericApi_I<TContainer> : GenericApiMask_I
	    where TContainer : RuntimicContainer_I<TContainer>
    {
	}
}
