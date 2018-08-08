using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

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

	    ConvertedAssemblyNode EnsureNode(ILConversion conversion, Assembly assembly);

	    ConvertedAssemblyNode EnsureNode(ILConversion conversion, System.IO.Stream stream);

		ConvertedAssemblyNode EnsureNode(ILConversion conversion, StructuralAssemblyNode assemblyNode);
    }
}
