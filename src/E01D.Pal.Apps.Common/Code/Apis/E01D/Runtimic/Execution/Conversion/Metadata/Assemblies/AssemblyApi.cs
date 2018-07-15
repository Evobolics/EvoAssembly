using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public class AssemblyApi<TContainer> : ConversionApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		#region Api(s)

	    
	    public AdditionApi_I<TContainer> Addition { get; set; }

        
        public BuildingApi_I<TContainer> Building { get; set; }

        
	    public CreationApi_I<TContainer> Creation { get; set; }

	    
	    public EnsuringApi_I<TContainer> Ensuring { get; set; }

	    
	    public GettingApi_I<TContainer> Getting { get; set; }

	    
	    public LoadingApi_I<TContainer> Loading { get; set; }

		
		public NamingApi_I<TContainer> Naming { get; set; }

	    
	    public QueryApi_I<TContainer> Query { get; set; }

		
		public StreamApi_I<TContainer> Streams { get; set; }

	    
	    public new TypeApi_I<TContainer> Types { get; set; }

		AdditionApiMask_I AssemblyApiMask_I.Addition => Addition;

        BuildingApiMask_I AssemblyApiMask_I.Building => Building;

        CreationApiMask_I AssemblyApiMask_I.Creation => Creation;

	    EnsuringApiMask_I AssemblyApiMask_I.Ensuring => Ensuring;

	    GettingApiMask_I AssemblyApiMask_I.Getting => Getting;

	    LoadingApiMask_I AssemblyApiMask_I.Loading => Loading;

		NamingApiMask_I AssemblyApiMask_I.Naming => Naming;

	    QueryApiMask_I AssemblyApiMask_I.Query => Query;

		StreamApiMask_I AssemblyApiMask_I.Streams => Streams;

	    Assemblies.TypeApiMask_I AssemblyApiMask_I.Types => Types;

		#endregion

		#region Methods

		

		

        #endregion
    }
}
