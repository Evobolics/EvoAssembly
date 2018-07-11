using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors
{
	public class MethodApi<TContainer> : RuntimeApiNode<TContainer>, ConstructorApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		//public BuildingApi_I<TContainer> Building { get; set; }


		//BuildingApiMask_I ConstructorApiMask_I.Building => Building;

		//public EnsuringApi_I<TContainer> Ensuring { get; set; }
		

		//EnsuringApiMask_I ConstructorApiMask_I.Ensuring => Ensuring;

		public GettingApi_I<TContainer> Getting { get; set; }


		GettingApiMask_I ConstructorApiMask_I.Getting => Getting;


		

	}
}
