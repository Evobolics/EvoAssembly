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

				if (convertedDeclaringType == null) // Can occur if passing in a single nested type or if a nested class gets processed before its parents gets
													// processed.
				{
					if (!(converted.SourceTypeReference is TypeDefinition))
					{
						throw new Exception("Expected a type definition");
					}

					var semanticDeclaringType = Types.Ensuring.Ensure(conversion, converted.SourceTypeReference.DeclaringType, null);

					if (!(semanticDeclaringType is ConvertedTypeDefinition_I producedDeclaringType))
					{
						throw new Exception($"Expected the declaring type of a nested class to be castable to {typeof(ConvertedTypeDefinition_I)}");
					}

					convertedDeclaringType = producedDeclaringType;
				}

				withDeclaringType.DeclaringType = convertedDeclaringType;

				// The plus sign and the parent class name before it needs to be dropped from the full name prior to calling define nested class
				// as the type builder will automatically add them back on based upon the name of the declaring type.
				var fullName = Types.Naming.GetTypeBuilderNestedClassFullName(converted.FullName);

				converted.TypeBuilder = convertedDeclaringType.TypeBuilder.DefineNestedType(fullName, attributes, null, packingSize);
			}
			else
			{
				if (converted.FullName == "<Module>")
				{
					var x = converted.Module.ModuleBuilder.GetType("<Module>", true);
				}

				converted.TypeBuilder = converted.Module.ModuleBuilder.DefineType(converted.FullName, attributes);
			}

			converted.UnderlyingType = converted.TypeBuilder;

			this.Unified.Types.ExtendWithCrossReference(conversion.Model, converted, converted.UnderlyingType.AssemblyQualifiedName);

			Types.Building.UpdateBuildPhase(converted, 1);
		}
	}
}
