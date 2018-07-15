using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface QueryApi_I<TContainer> : QueryApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
