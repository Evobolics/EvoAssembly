namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
    public interface AssemblyApiMask_I
    {
	    CreatingApiMask_I Creating { get; }

		EnsuringApiMask_I Ensuring { get; }

	    ExtendingApiMask_I Extending { get; }

		GettingApiMask_I Getting { get; }

		NamingApiMask_I Naming { get; }
	}
}
