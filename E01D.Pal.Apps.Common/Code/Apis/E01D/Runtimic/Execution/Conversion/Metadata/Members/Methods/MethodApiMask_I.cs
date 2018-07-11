using System.Reflection;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods
{
    public interface MethodApiMask_I
    {
        
        

        BuildingApiMask_I Building { get; }

	    GettingApiMask_I Getting { get;  }

        TypeParameterApiMask_I TypeParameters { get; }

        TypeScanningApiMask_I TypeScanning { get; }

	    


		



		CallingConventions GetCallingConventions(MethodReference methodDefinition);

        //MethodInfo FindMethodByNameAndSignature(ILConversion conversion, BoundTypeDefinitionMask_I typeEntry, MethodReference methodSpecification);
        //MethodInfo FindGenericMethodBySignature(ILConversion conversion, BoundTypeDefinitionMask_I typeEntry, GenericInstanceMethod genericMethod);
        

        
	    
    }
}
