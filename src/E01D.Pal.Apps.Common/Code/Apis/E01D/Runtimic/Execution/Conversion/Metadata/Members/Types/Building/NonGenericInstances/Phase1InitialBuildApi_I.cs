﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances
{
	public interface Phase1InitialBuildApi_I<TContainer> : Phase1InitialBuildApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
