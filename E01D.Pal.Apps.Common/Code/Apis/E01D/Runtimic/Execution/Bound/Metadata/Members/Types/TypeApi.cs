using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Creation;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Ensuring;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Building;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
	public class TypeApi<TContainer> : BindingApiNode<TContainer>, TypeApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		
		public AdditionApi_I<TContainer> Addition { get; set; }

	    
	    public BaseTypeApi_I<TContainer> BaseTypes { get; set; }

	    
	    public BuildingApi_I<TContainer> Building { get; set; }

		
		public CreationApi_I<TContainer> Creation { get; set; }

        
        public DefinitionApi_I<TContainer> Definitions { get; set; }

        
		public DependencyApi_I<TContainer> Dependencies { get; set; }

		
		public EnsuringApi_I<TContainer> Ensuring { get; set; }

		public GenericInstanceApi_I<TContainer> GenericInstances { get; set; }

		
		public GettingApi_I<TContainer> Getting { get; set; }

	    
	    public InterfaceApi_I<TContainer> Interfaces { get; set; }

        
		public NamingApi_I<TContainer> Naming { get; set; }

        
        public SimpleApi_I<TContainer> Simple { get; set; }

	    


		AdditionApiMask_I TypeApiMask_I.Addition => Addition;

        BaseTypeApiMask_I TypeApiMask_I.BaseTypes => BaseTypes;

	    BuildingApiMask_I TypeApiMask_I.Building => Building;

		CreationApiMask_I TypeApiMask_I.Creation => Creation;

       DefinitionApiMask_I TypeApiMask_I.Definitions => Definitions;

        DependencyApiMask_I TypeApiMask_I.Dependencies => Dependencies;

        EnsuringApiMask_I TypeApiMask_I.Ensuring => Ensuring;

	    GenericInstanceApiMask_I TypeApiMask_I.GenericInstances => GenericInstances;

		GettingApiMask_I TypeApiMask_I.Getting => Getting;

        InterfaceApiMask_I TypeApiMask_I.Interfaces => Interfaces;

        NamingApiMask_I TypeApiMask_I.Naming => Naming;

        SimpleApiMask_I TypeApiMask_I.Simple => Simple;

	    











	}
}
