using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{
	public interface ResultApi_I<TContainer> : ResultApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		Assembly GetCorrespondingOutput(ILConversionResult result, Assembly assembly);
	}
}
