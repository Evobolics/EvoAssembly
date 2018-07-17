using System;
using System.Reflection;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public class AssemblyApi<TContainer> : BoundApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		#region Api(s)

	    
	    public AdditionApi_I<TContainer> Addition { get; set; }

        
        public BuildingApi_I<TContainer> Building { get; set; }

        
	    public CreationApi_I<TContainer> Creation { get; set; }

        
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

        
        public GettingApi_I<TContainer> Getting { get; set; }

        
		public NamingApi_I<TContainer> Naming { get; set; }

	    
		public StreamApi_I<TContainer> Streams { get; set; }

	    
	    public new TypeApi_I<TContainer> Types { get; set; }

        

        AdditionApiMask_I AssemblyApiMask_I.Addition => Addition;

        BuildingApiMask_I AssemblyApiMask_I.Building => Building;

        CreationApiMask_I AssemblyApiMask_I.Creation => Creation;

        EnsuringApiMask_I AssemblyApiMask_I.Ensuring => Ensuring;

        GettingApiMask_I AssemblyApiMask_I.Getting => Getting;

        NamingApiMask_I AssemblyApiMask_I.Naming => Naming;

	    StreamApiMask_I AssemblyApiMask_I.Streams => Streams;

	    TypeApiMask_I AssemblyApiMask_I.Types => Types;

        

        #endregion

        

        public Type GetTypeFromAssembly(Assembly loadedAssembly, string inputFullName)
        {
            var types = loadedAssembly.GetTypes();

            for (int i = 0; i < types.Length; i++)
            {
                var type = types[i];

                if (type.FullName == inputFullName)
                {
                    return type;
                }
            }

            return null;
        }


    }
}
