using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil
{
    public interface CecilApiMask_I
    {


	    MetadataApiMask_I Metadata { get; }

	    



		System.Type GetUnderlyingType(TypeReference input);

        PackingSize GetPackingSize(TypeDefinition typeDefinition);
        bool IsClass(TypeReference constraint);
        TypeReference GetBaseType(TypeReference typeReference);
        TypeReference ResolveAnyTypeArguments(TypeReference genericArgumentSource, TypeReference returnTypeReference);

        TypeReference ResolveForTypeScan(TypeReference genericArgumentSource, TypeReference returnTypeReference);
        TypeDefinition GetFundamentalTypeDefinition(TypeReference typeReference);
	    bool IsExternal(TypeReference typeReference);
    }
}
