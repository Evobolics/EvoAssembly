using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Baking;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface TypeApi_I<TContainer> : TypeApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new AdditionApi_I<TContainer> Addition { get; set; }

        new BakingApi_I<TContainer> Baking { get; set; }

        new BaseTypeApi_I<TContainer> BaseTypes { get; set; }

        new BuildingApi_I<TContainer> Building { get; set; }

        new CreationApi_I<TContainer> Creation { get; set; }

        new DependencyApi_I<TContainer> Dependencies { get; set; }

        new EnsuringApi_I<TContainer> Ensuring { get; set; }

	    new Generics.GenericApi_I<TContainer> Generic { get; set; }

		new GettingApi_I<TContainer> Getting { get; set; }

        new InterfaceApi_I<TContainer> Interfaces { get; set; }

        new NamingApi_I<TContainer> Naming { get; set; }

        new TypeScanningApi_I<TContainer> Scanning { get; set; }

        new TypeParameterApi_I<TContainer> TypeParameters { get; set; }




    }
}
