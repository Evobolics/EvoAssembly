using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling
{
    public interface ModelApiMask_I
    {
        ModelAssembliesApiMask_I Assemblies { get; }

        ModelFieldsApiMask_I Fields { get; }

        ModelModulesApiMask_I Modules { get; }

        ModelTypesApiMask_I Types { get; }

        //void AddAssemblyDefinition(SemanticModelMask_I semanticModel, AssemblyDefinition assemblyDefinition);
        

        bool IsConverted(ILConversion conversion, TypeReference input);

        bool IsConverted(ILConversion conversion, System.Type input);
    }
}
