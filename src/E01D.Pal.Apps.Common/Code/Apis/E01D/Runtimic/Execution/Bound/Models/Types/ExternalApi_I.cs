﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
	public interface ExternalApi_I<TContainer> : ExternalApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
