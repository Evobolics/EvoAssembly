using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances
{
	public class Phase0PreSearchBuildApi<TContainer> : ConversionApiNode<TContainer>, Phase0PreSearchBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		///// <summary>
		///// Assigns the generic blueprint and the type arguments to the generic instance type.
		///// </summary>
		///// <param name="conversion"></param>
		///// <param name="converted"></param>
		///// <returns></returns>
		//public Type[] Build(ILConversion conversion, ConvertedGenericTypeDefinition_I converted)
		//{
		//	EnsureGenericBlueprint(conversion, converted);

		//	return Bound.Metadata.Members.TypeArguments.Building.Build(conversion.Model, converted);
		//}

		//public BoundGenericTypeDefinitionMask_I EnsureGenericBlueprint(ILConversion conversion, ConvertedGenericTypeDefinition_I converted)
		//{
		//	var genericInstanceType = (GenericInstanceType)converted.SourceTypeReference;

		//	var typeDefinition = (TypeDefinition)genericInstanceType.ElementType;

		//	var semanticBlueprint = Execution.Types.Ensuring.Ensure(conversion.Model, typeDefinition, null, null);

		//	if (!(semanticBlueprint is BoundGenericTypeDefinitionMask_I boundBlueprint))
		//	{
		//		throw new Exception("When creating a conversion model, the base type needs to be a bound type.");
		//	}

		//	converted.Blueprint = boundBlueprint;

		//	return boundBlueprint;
		//}
	}
}
