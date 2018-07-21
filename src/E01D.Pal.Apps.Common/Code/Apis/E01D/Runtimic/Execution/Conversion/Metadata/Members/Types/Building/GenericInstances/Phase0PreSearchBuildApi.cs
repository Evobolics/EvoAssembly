using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.GenericInstances
{
	public class Phase0PreSearchBuildApi<TContainer> : ConversionApiNode<TContainer>, Phase0PreSearchBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		/// <summary>
		/// Assigns the generic blueprint and the type arguments to the generic instance type.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="converted"></param>
		/// <returns></returns>
		public Type[] Build(ILConversion conversion, ConvertedGenericTypeDefinition_I converted)
		{
			EnsureGenericBlueprint(conversion, converted);

			return Members.TypeArguments.Building.Build(conversion, converted);
		}

		public BoundGenericTypeDefinitionMask_I EnsureGenericBlueprint(ILConversion conversion, ConvertedGenericTypeDefinition_I converted)
		{
			var genericInstanceType = (GenericInstanceType)converted.SourceTypeReference;

			var genericElementType = genericInstanceType.ElementType; // Could be an external reference

			var semanticBlueprint = Execution.Types.Ensuring.EnsureBound(conversion.Model, genericElementType);

			if (!(semanticBlueprint is BoundGenericTypeDefinitionMask_I boundBlueprint))
			{
				throw new Exception($"Expected a type of {typeof(BoundGenericTypeDefinitionMask_I)}.");
			}

			converted.Blueprint = boundBlueprint;

			return boundBlueprint;
		}
	}
}
