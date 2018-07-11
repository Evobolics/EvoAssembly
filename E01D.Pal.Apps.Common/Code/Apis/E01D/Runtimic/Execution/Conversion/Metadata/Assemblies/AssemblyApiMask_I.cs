using System.IO;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public interface AssemblyApiMask_I
    {
		#region Api(s)

	    AdditionApiMask_I Addition { get; }

        BuildingApiMask_I Building { get; }

        CreationApiMask_I Creation { get; }

	    EnsuringApiMask_I Ensuring { get; }

		NamingApiMask_I Naming { get; }

		StreamApiMask_I Streams { get; }

	    Assemblies.TypeApiMask_I Types { get; }


		#endregion

		ILConversionResult Convert(ILConversion conversion, Stream[] streams);

	    ILConversionResult Convert(ILConversion conversion, System.Type[] inputTypes);

        SemanticAssemblyMask_I GetAssembly(ILConversion conversion, AssemblyDefinition assemblyDefinition);

        SemanticAssemblyMask_I GetAssembly(ILConversion conversion, Assembly assembly);

        SemanticAssemblyMask_I GetAssembly(InfrastructureModelMask_I model, string fullName);

        SemanticAssemblyMask_I GetAssembly(InfrastructureModelMask_I model, AssemblyNameReference fullName);

        SemanticAssemblyMask_I GetAssembly(ILConversionExecutionModel conversion, AssemblyDefinition assemblyDefinition);

        

        
        bool IsCorlib(IMetadataScope scope);

        bool IsCorlib(string name);



        bool IsConverted(ILConversion conversion, IMetadataScope scope);

        bool IsConverted(ILConversion conversion, string name);
        AssemblyDefinitionAndStream GetAssemblyDefinition(ILConversion conversion, Assembly assembly);


        bool TryGet(ILConversion conversion, string fullName, out SemanticAssemblyMask_I semanticAssemblyMask);
    }
}
