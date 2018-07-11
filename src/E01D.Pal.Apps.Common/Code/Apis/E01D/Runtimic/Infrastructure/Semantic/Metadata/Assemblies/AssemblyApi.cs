using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Assemblies
{
    public class AssemblyApi<TContainer> : SemanticApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    

        [ValueSetDynamically]
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I AssemblyApiMask_I.Building => Building;

        [ValueSetDynamically]
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

        EnsuringApiMask_I AssemblyApiMask_I.Ensuring => Ensuring;


    }
}
