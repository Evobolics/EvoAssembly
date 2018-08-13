using System;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
	public class DefinitionTypeApi<TContainer> : ExecutionApiNode<TContainer>, DefinitionTypeApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public ExecutionTypeNode_I Ensure(ExecutionEnsureContext context)
		{
			if (!context.IsConverted.HasValue) throw new Exception("Expected conversion to be figured out.");

			if (context.StructuralInputTypeNode.CecilTypeReference.IsNested && context.DeclaringType == null)
			{
				context.DeclaringType = Execution.Types.Ensuring.EnsureBound(context,
					context.StructuralInputTypeNode.CecilTypeReference.DeclaringType, cloneContext: true);
			}

			if (context.IsConverted.Value)
			{
				var conversion = context.Conversion;

				var structuralInputTypeNode = context.StructuralInputTypeNode;

				var metadataToken = structuralInputTypeNode.MetadataToken;

				var structuralAssembly = Conversion.Metadata.Assemblies.EnsureNode(context.Conversion, structuralInputTypeNode.Module.Assembly);

				var convertedModuleNode = Conversion.Metadata.Modules.Ensure(context.Conversion, structuralAssembly, structuralInputTypeNode.Module);

				var tableId = (int)(metadataToken & 0xFF000000);

				if (!convertedModuleNode.Tables.TryGetValue(tableId, out ConvertedTypeTable table))
				{
					table = new ConvertedTypeTable();

					convertedModuleNode.Tables.Add(tableId, table);
				}

				if (table.ByRow.TryGetValue((uint)context.RowId, out ConversionTypeNode conversionTypeNode))
				{
					return conversionTypeNode;
				}

				

				var converted = Conversion.Metadata.Members.Types.Creation.Create(conversion.RuntimicSystem, structuralInputTypeNode.CecilTypeReference);

				converted.Module = convertedModuleNode.ConvertedModule;

				conversionTypeNode = new ConversionTypeNode()
				{
					Assembly = structuralAssembly,
					ByReferenceType = null,
					Id = 0,
					InputStructuralNode = structuralInputTypeNode,
					IsByReferenceType = false,
					IsDerived = false,
					IsPointerType = false,
					MetadataToken = metadataToken,
					Module = convertedModuleNode,
					PointerType = null,
					Type = converted
				};

				table.ByRow.Add((uint)context.RowId, conversionTypeNode);

				var convertedDeclaringType = context.ConvertedDeclaringType;

				Converted_BuildPhase1(conversion, structuralInputTypeNode, converted, convertedDeclaringType);

				Conversion.Metadata.Members.Types.Building.IfPossibleBuildPhase2(conversion, converted);

				return conversionTypeNode;
			}
			else
			{
				

				var structuralInputTypeNode = context.StructuralInputTypeNode;

				if (structuralInputTypeNode.FullName == "Root.Code.Containers.E01D.Sorting.SortingContainer_I`1")
				{
					
				}

				var metadataToken = structuralInputTypeNode.MetadataToken;

				var boundAssembly = Bound.Metadata.Assemblies.EnsureNode(context.RuntimicSystem, structuralInputTypeNode.Module.Assembly);

				var boundModuleNode = Bound.Metadata.Modules.Ensuring.EnsureNode(context.RuntimicSystem, boundAssembly, structuralInputTypeNode.Module);

				var tableId = (int)(metadataToken & 0xFF000000);

				if (!boundModuleNode.Tables.TryGetValue(tableId, out BoundTypeTable table))
				{
					table = new BoundTypeTable();

					boundModuleNode.Tables.Add(tableId, table);
				}

				if (table.ByRow.TryGetValue((uint)context.RowId, out BoundTypeNode boundTypeNode))
				{
					return boundTypeNode;
				}
				//---------------------------------
				// Conversion is going to occur.
				//---------------------------------

				if (context.UnderlyingType == null)
				{


					context.UnderlyingType = Cecil.GetUnderlyingType(structuralInputTypeNode.CecilTypeReference);

					if (context.UnderlyingType == null)
					{
						throw new Exception("Null type");
					}
				}

				var bound = Bound.Metadata.Members.Types.Creation.Create(context.RuntimicSystem, context.StructuralInputTypeNode.CecilTypeReference, context.UnderlyingType);

				boundTypeNode = new BoundTypeNode()
				{
					Assembly = boundAssembly,
					ByReferenceType = null,
					Id = 0,
					InputStructuralNode = structuralInputTypeNode,
					IsByReferenceType = false,
					IsDerived = false,
					IsPointerType = false,
					MetadataToken = metadataToken,
					Module = boundModuleNode,
					PointerType = null,
					Type = bound
				};


				bound.Module = boundModuleNode.BoundModule;

				//// Add the type instance to the model.  Do not do any recursive calls till this methods is called.
				table.ByRow.Add((uint)context.RowId, boundTypeNode);


				
				//Types.Addition.Add(semanticModel, boundModule, bound);

				Bound.Metadata.Members.Types.Building.NonGenericInstances.Phase1Initial.Build(context.RuntimicSystem, bound, context.UnderlyingType, context.DeclaringType);

				return boundTypeNode;
			}
		}

		private void Converted_BuildPhase1(ILConversion conversion, StructuralTypeNode structuralInputTypeNode, ConvertedTypeDefinition converted,
			ConvertedTypeDefinition_I convertedDeclaringType)
		{
			var typeDefinition = (TypeDefinition) structuralInputTypeNode.CecilTypeReference;

			System.Reflection.TypeAttributes attributes = Cecil.Metadata.Members.Types.GetTypeAttributes(typeDefinition);

			var packingSize = Cecil.GetPackingSize(typeDefinition);

			if (converted is ConvertedTypeDefinitionWithDeclaringType_I withDeclaringType)
			{
				

				if (convertedDeclaringType == null
					) // Can occur if passing in a single nested type or if a nested class gets processed before its parents gets
					// processed.
				{
					if (!(converted.SourceTypeReference is TypeDefinition))
					{
						throw new Exception("Expected a type definition");
					}

					var semanticDeclaringType =
						Execution.Types.Ensuring.Ensure(conversion, converted.SourceTypeReference.DeclaringType, null,
							null);

					if (!(semanticDeclaringType is ConvertedTypeDefinition_I producedDeclaringType))
					{
						throw new Exception(
							$"Expected the declaring type of a nested class to be castable to {typeof(ConvertedTypeDefinition_I)}");
					}

					convertedDeclaringType = producedDeclaringType;
				}

				withDeclaringType.DeclaringType = convertedDeclaringType;

				// The plus sign and the parent class name before it needs to be dropped from the full name prior to calling define nested class
				// as the type builder will automatically add them back on based upon the name of the declaring type.
				var fullName = Conversion.Metadata.Members.Types.Naming.GetTypeBuilderNestedClassFullName(converted.FullName);

				// The !IsEnum check prevents: [MD]: Error: ClassLayout has parent TypeDef token=0x02000036 marked AutoLayout. [token:0x00000001]
				// The Class or ValueType indexed by Parent shall be SequentialLayout or ExplicitLayout (§II.23.1.15). 
				// That is, AutoLayout types shall not own any rows in the ClassLayout table. [ERROR]
				if (typeDefinition.IsValueType && !typeDefinition.IsEnum) 
				{
					converted.TypeBuilder = convertedDeclaringType.TypeBuilder.DefineNestedType(converted.FullName, attributes, null, (PackingSize)typeDefinition.PackingSize, typeDefinition.ClassSize);
				}
				else
				{
					converted.TypeBuilder = convertedDeclaringType.TypeBuilder.DefineNestedType(fullName, attributes, null, packingSize);
				}
				
			}
			else
			{
				if (converted.FullName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.SimpleValueType")
				{
					
				}

				if (converted.FullName == "<Module>")
				{
					var x = converted.Module.ModuleBuilder.GetType("<Module>", true);
				}

				// The !IsEnum check prevents: [MD]: Error: ClassLayout has parent TypeDef token=0x02000036 marked AutoLayout. [token:0x00000001]
				// The Class or ValueType indexed by Parent shall be SequentialLayout or ExplicitLayout (§II.23.1.15). 
				// That is, AutoLayout types shall not own any rows in the ClassLayout table. [ERROR]
				if (typeDefinition.IsValueType && !typeDefinition.IsEnum)
				{
					converted.TypeBuilder = converted.Module.ModuleBuilder.DefineType(converted.FullName, attributes, null, (PackingSize)typeDefinition.PackingSize, typeDefinition.ClassSize);
				}
				else
				{
					converted.TypeBuilder = converted.Module.ModuleBuilder.DefineType(converted.FullName, attributes, null, packingSize);
				}
				

				
				


			}

			converted.UnderlyingType = converted.TypeBuilder;

			//this.Unified.Types.ExtendWithCrossReference(conversion.Model, converted,
			//	converted.UnderlyingType.AssemblyQualifiedName);

			Conversion.Metadata.Members.Types.Building.UpdateBuildPhase(converted, BuildPhaseKind.TypeDefined);
		}
	}
}
