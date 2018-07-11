using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Creation;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface TypeApi_I<TContainer> : TypeApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new AdditionApi_I<TContainer> Addition { get; }

        new BaseTypeApi_I<TContainer> BaseTypes { get;  }

        new CreationApi_I<TContainer> Creation { get; }

        new DependencyApi_I<TContainer> Dependencies { get; }

        new EnsuringApi_I<TContainer> Ensuring { get; }

	    new GenericInstanceApi_I<TContainer> GenericInstances { get; }

		new GettingApi_I<TContainer> Getting { get; }

        new InterfaceApi_I<TContainer> Interfaces { get; }

        new NamingApi_I<TContainer> Naming { get; }
		//new TypeParameterApi_I<TContainer> TypeParameters { get; set; }



	}
}
