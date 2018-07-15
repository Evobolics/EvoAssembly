using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{
	public class ResultApi<TContainer> : ConversionApiNode<TContainer>, ResultApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public Assembly GetCorrespondingOutput(ILConversionResult result, Assembly assembly)
		{
			throw new System.NotImplementedException();
		}
	}
}
