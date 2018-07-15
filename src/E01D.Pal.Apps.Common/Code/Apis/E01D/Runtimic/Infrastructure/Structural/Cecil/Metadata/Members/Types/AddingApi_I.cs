using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface AddingApi_I<TContainer> : AddingApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{

	}
}
