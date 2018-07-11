using System.IO;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface EnsuringApiMask_I
	{
		void Ensure(ILConversion conversion, Stream[] streams);

		SemanticAssemblyMask_I Ensure(ILConversion conversion, Assembly assembly);

		SemanticAssemblyMask_I Ensure(ILConversion conversion, Stream stream);

		SemanticAssemblyMask_I Ensure(ILConversion conversion, IMetadataScope assemblyNameReference);

		SemanticAssemblyMask_I Ensure(ILConversion conversion, string typeReferenceFullName);

		SemanticAssemblyMask_I Ensure(ILConversion conversion, TypeReference typeReference);



		/// <summary>
		/// Creates a bound or converted assembly depending if isonvered is set to true.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assemblyDefinition"></param>
		/// <returns></returns>
		SemanticAssemblyMask_I Ensure(ILConversion conversion, AssemblyDefinition assemblyDefinition);
	}
}
