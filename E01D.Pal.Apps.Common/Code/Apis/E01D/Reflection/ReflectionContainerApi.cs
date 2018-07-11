using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Reflection;

namespace Root.Code.Apis.E01D.Reflection
{

	public class ReflectionContainerApi : ReflectionContainerApi<ReflectionContainer_I>
	{
		
	}

	public class ReflectionContainerApi<TContainer>:Api<TContainer>, ReflectionContainerApi_I
		where TContainer:ReflectionContainer_I
	{
		[ValueSetDynamically]
		public ReflectionApi<TContainer> Reflection { get; set; }

		ReflectionApi_I ReflectionContainerApi_I.Reflection => Reflection;
	}
}
