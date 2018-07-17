using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
    public class AssemblyApi<TContainer> : CecilApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    public CreatingApi_I<TContainer> Creating { get; set; }

	    CreatingApiMask_I AssemblyApiMask_I.Creating => Creating;

		public EnsuringApi_I<TContainer> Ensuring { get; set; }

	    EnsuringApiMask_I AssemblyApiMask_I.Ensuring => Ensuring;

	    public ExtendingApi_I<TContainer> Extending { get; set; }

	    ExtendingApiMask_I AssemblyApiMask_I.Extending => Extending;

		public GettingApi_I<TContainer> Getting { get; set; }

	    GettingApiMask_I AssemblyApiMask_I.Getting => Getting;

		public NamingApi_I<TContainer> Naming { get; set; }

	    NamingApiMask_I AssemblyApiMask_I.Naming => Naming;


		
		

		

	}
}
