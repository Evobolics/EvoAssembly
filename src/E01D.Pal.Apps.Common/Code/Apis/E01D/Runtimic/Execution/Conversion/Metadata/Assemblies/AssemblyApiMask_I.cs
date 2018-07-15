using System.IO;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public interface AssemblyApiMask_I
    {
		#region Api(s)

	    AdditionApiMask_I Addition { get; }

        BuildingApiMask_I Building { get; }

        CreationApiMask_I Creation { get; }

	    EnsuringApiMask_I Ensuring { get; }

	    GettingApiMask_I Getting { get; }

	    LoadingApiMask_I Loading { get; }

		NamingApiMask_I Naming { get; }

	    QueryApiMask_I Query { get; }

		StreamApiMask_I Streams { get; }

	    Assemblies.TypeApiMask_I Types { get; }


		#endregion

		













	}
}
