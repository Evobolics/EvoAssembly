using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public interface RuntimicContainerB_I<TContainer>
		where TContainer : RuntimicContainerB_I<TContainer>
	{
		RuntimicContainerBApi_I<TContainer> Api { get; }
	}
}
