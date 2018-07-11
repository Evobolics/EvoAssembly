using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
    public interface CreationApiMask_I
    {

        //CecilApiMask_I Cecil { get; }
        DefinitionApiMask_I Definitions { get; }

        DotNetApiMask_I DotNet { get; }

        GenericApiMask_I Generics { get; }

        ReferenceApiMask_I References { get; }



        ConvertedTypeDefinition Create(ILConversion conversion, ModuleDefinition sourceModule, ConvertedModule_I semanticModule, System.Type type);

        ConvertedTypeDefinition Create(ILConversion conversion, ModuleDefinition sourceModule, ConvertedModule_I semanticModule, TypeReference typeReference);
    }
}
