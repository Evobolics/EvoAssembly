using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances
{
	public class Phase1InitialBuildApi<TContainer> : ConversionApiNode<TContainer>, Phase1InitialBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		/// <summary>
		/// Assigns the generic blueprint and the type arguments to the generic instance type.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="converted"></param>
		/// <param name="convertedDeclaringType"></param>
		/// <returns></returns>
		public void Build(ILConversion conversion, ConvertedTypeDefinition_I converted, ConvertedTypeDefinition_I convertedDeclaringType)
		{
			//Done on purpose to find errors
			var typeDefinition = (TypeDefinition)converted.SourceTypeReference;

			System.Reflection.TypeAttributes attributes = Cecil.Metadata.Members.Types.GetTypeAttributes(typeDefinition);

			if (converted is ConvertedTypeDefinitionWithDeclaringType_I withDeclaringType)
			{
				var packingSize = Cecil.GetPackingSize(typeDefinition);

				withDeclaringType.DeclaringType = convertedDeclaringType ?? throw new Exception("Declaring type is null.  Cannot create a nested type.");

				converted.TypeBuilder = convertedDeclaringType.TypeBuilder.DefineNestedType(converted.FullName, attributes, null, packingSize);
			}
			else
			{
				converted.TypeBuilder = converted.Module.ModuleBuilder.DefineType(converted.FullName, attributes);
			}

			converted.UnderlyingType = converted.TypeBuilder;

			this.Unified.Types.ExtendWithCrossReference(conversion.Model, converted, converted.UnderlyingType.AssemblyQualifiedName);

			Types.Building.UpdateBuildPhase(converted, 1);
		}
	}
}
