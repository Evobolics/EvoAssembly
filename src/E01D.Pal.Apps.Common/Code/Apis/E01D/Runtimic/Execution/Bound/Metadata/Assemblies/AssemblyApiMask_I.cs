using System;
using System.Reflection;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public interface AssemblyApiMask_I
    {
		#region Api(s)

	    AdditionApiMask_I Addition { get; }

        BuildingApiMask_I Building { get; }

        CreationApiMask_I Creation { get; }

        EnsuringApiMask_I Ensuring { get; }

        GettingApiMask_I Getting { get; }

        NamingApiMask_I Naming { get; }

		StreamApiMask_I Streams { get; }

	    TypeApiMask_I Types { get; }


		#endregion


        Type GetTypeFromAssembly(Assembly loadedAssembly, string inputFullName);


    }
}
