using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil
{
    public interface CecilApiMask_I
    {

	    AssemblyApiMask_I Assemblies { get; }

	    

		MetadataApiMask_I Metadata { get; }

	    ModuleApiMask_I Modules { get; }

		TypeApiMask_I Types { get; }



		System.Type GetUnderlyingType(TypeReference input);

        PackingSize GetPackingSize(TypeDefinition typeDefinition);
        
        TypeReference GetBaseType(TypeReference typeReference);
        TypeReference ResolveAnyTypeArguments(TypeReference genericArgumentSource, TypeReference returnTypeReference);

        TypeReference ResolveForTypeScan(TypeReference genericArgumentSource, TypeReference returnTypeReference);
        TypeDefinition GetFundamentalTypeDefinition(TypeReference typeReference);
	    
    }
}
