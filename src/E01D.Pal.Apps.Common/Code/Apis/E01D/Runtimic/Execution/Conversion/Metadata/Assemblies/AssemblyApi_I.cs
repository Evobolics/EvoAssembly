using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public interface AssemblyApi_I<TContainer>: AssemblyApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new AdditionApi_I<TContainer> Addition { get; set; }

        new CreationApi_I<TContainer> Creation { get; set; }

	    new EnsuringApi_I<TContainer> Ensuring { get; set; }

		new NamingApi_I<TContainer> Naming { get; set; }

        new StreamApi_I<TContainer> Streams { get; set; }

        new TypeApi_I<TContainer> Types { get; set; }
    }
}
