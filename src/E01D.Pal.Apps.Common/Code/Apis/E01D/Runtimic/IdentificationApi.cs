using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic
{
	public class IdentificationApi<TContainer> : RuntimeApiNode<TContainer>, IdentificationApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public long IssueId(RuntimicSystemModel runtimicSystemModel)
		{
			return ++runtimicSystemModel.Identification.LastIdIssued;
		}
	}
}
