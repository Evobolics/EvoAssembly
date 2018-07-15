﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{
	public interface InternalApi_I<TContainer> : InternalApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}