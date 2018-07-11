using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {



		public DynamicallyCreatedApi_I<TContainer> DynamicallyCreated { get; set; }

	    DynamicallyCreatedApiMask_I BuildingApiMask_I.Emitted => DynamicallyCreated;

	    public RuntimeCreatedApi_I<TContainer> RuntimeCreated { get; set; }

	    RuntimeCreatedApiMask_I BuildingApiMask_I.RuntimeCreated => RuntimeCreated;

	    public MethodInfo MakeArrayMethod(ILConversion conversion, ConvertedTypeDefinition_I callingType,
		    BoundTypeDefinitionMask_I declaringType, MethodReference methodReference)
	    {
			var systemParameters = Parameters.GetSystemParameterTypes(conversion, methodReference.Parameters);

		    var returnType = Types.Ensuring.EnsureToType(conversion, methodReference.ReturnType);

		    var callingConventions = Methods.GetCallingConventions(methodReference);

		    return callingType.Module.ModuleBuilder.GetArrayMethod(declaringType.UnderlyingType, methodReference.Name, callingConventions, returnType, systemParameters);
		}















	}
}
