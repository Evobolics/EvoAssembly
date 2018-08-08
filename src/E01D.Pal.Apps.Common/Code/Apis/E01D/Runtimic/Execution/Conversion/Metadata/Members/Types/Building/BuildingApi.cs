using System.Collections.Generic;
using System.Linq;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.GenericInstances;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building
{
	/// <summary>
	/// The type, and its associated sub system types, responsible for building out a type.
	/// </summary>
	/// <typeparam name="TContainer"></typeparam>
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

		#region Apis

		public ArrayApi_I<TContainer> Arrays { get; set; }

	    ArrayApiMask_I BuildingApiMask_I.Arrays => Arrays;
	    
	    public EnumApi_I<TContainer> Enums { get; set; }

	    EnumApiMask_I BuildingApiMask_I.Enums => Enums;

	    public GenericInstanceApi_I<TContainer> GenericInstances { get; set; }

	    GenericInstanceApiMask_I BuildingApiMask_I.GenericInstances => GenericInstances;

	    public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

	    GenericParameterApiMask_I BuildingApiMask_I.GenericParameters => GenericParameters;

	    public NonGenericInstanceApi_I<TContainer> NonGenericInstances { get; set; }

	    NonGenericInstanceApiMask_I BuildingApiMask_I.NonGenericInstances => NonGenericInstances;


		#endregion

		public void IfPossibleBuildPhase2(ILConversion conversion, ConvertedTypeDefinition_I converted)
		{
			if (converted.SourceTypeReference.FullName ==
			    "Root.Code.Containers.E01D.Runtimic.RuntimicContainerB_I`1"
			)
			{
				// Does get here
			}

            // There is not just building work to be done.  There is actually pre and post being working to be done.  The dependency check is to verify if there is any
            // post build work to be done.  
            List<ConvertedTypeDefinition_I> dependencies = CheckForBuildDependencies(conversion, converted, BuildPhaseKind.MembersDefined);

			if (dependencies.Count < 1)
			{
				BuildPhase2AndDependencies(conversion, converted);
			}
			else
			{
				for (int i = 0; i < dependencies.Count; i++)
				{
					var dependency = dependencies[i];

					converted.ConversionState.Phase2Dependencies.Add(dependency);

					dependency.ConversionState.Phase2Dependents.Add(converted);
				}
			}
		}

	    private void BuildPhase2AndDependencies(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
// Build all members
		    BuildPhase2(conversion, converted);

		    if (converted.SourceTypeReference.FullName ==
		        "Root.Code.Containers.E01D.Runtimic.RuntimicContainerB_I`1"
		    )
		    {
			    // Does get here
		    }

			// Give a chance for all dependencies to build all members
			var dependents = converted.ConversionState.Phase2Dependents;

		    for (int i = 0; i < dependents.Count; i++)
		    {
			    var dependent = dependents[i];

			    dependent.ConversionState.Phase2Dependencies.Remove(converted);

			    if (dependent.ConversionState.Phase2Dependencies.Count == 0)
			    {
				    BuildPhase2AndDependencies(conversion, dependent);
			    }
		    }

		    converted.ConversionState.Phase2Dependents.Clear();

		    BuildPhase3(conversion, converted);
	    }


	    private List<ConvertedTypeDefinition_I> CheckForBuildDependencies(ILConversion conversion, ConvertedTypeDefinition_I converted, BuildPhaseKind targetPhase)
	    {
		    List<ConvertedTypeDefinition_I> result = new List<ConvertedTypeDefinition_I>();

		    if (converted is ConvertedGenericTypeDefinition_I generic)
		    {
			    if (generic.Blueprint != null && generic.Blueprint is ConvertedTypeDefinition_I convertedBlueprint && (int)convertedBlueprint.ConversionState.BuildPhase < (int)targetPhase)
			    {
				    result.Add(convertedBlueprint);
			    }
		    }

		    return result;

	    }

	    public void BuildPhase2(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
			if (converted.SourceTypeReference.FullName ==
			    "Root.Code.Containers.E01D.Runtimic.RuntimicContainer_I`1<TContainer>"
			)
			{

			}

			if (converted.SourceTypeReference.FullName ==
			    "Root.Code.Containers.E01D.Runtimic.RuntimicContainer_I`1"
			)
			{
				// Does get here
			}

			if (converted.ConversionState.BuildPhase != BuildPhaseKind.TypeDefined)
		    {
			    throw new System.Exception("Expecting the current build phase to be phase 1");
		    }

		    if (converted is ConvertedGenericTypeDefinition_I generic && generic.IsClosedType())
		    {
			    GenericInstances.Phase2Dependency.Build(conversion, generic);
		    }
		    else
		    {
			    NonGenericInstances.Phase2Members.Build(conversion, converted);
		    }

		    Types.Building.UpdateBuildPhase(converted, BuildPhaseKind.MembersDefined);

		    if (converted.SourceTypeReference.FullName ==
		        "Root.Code.Containers.E01D.Runtimic.RuntimicContainer_I`1"
		    )
		    {

		    }


		}

		public void BuildPhase3(ILConversion conversion, ConvertedTypeDefinition_I converted)
		{

			if (converted.AssemblyQualifiedName ==
			    "Root.Code.Containers.E01D.Runtimic.RuntimicContainer_I`1<TContainer>, E01D.Pal.Apps.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
			)
			{
				
			}
			if (converted.SourceTypeReference.FullName ==
			    "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions.InstructionTest_CastClass"
			)
			{

			}

            if (converted.ConversionState.BuildPhase != BuildPhaseKind.MembersDefined)
			{
				throw new System.Exception("Expecting the current build phase to be phase 2 - Members Defined");
			}

			var dependencies = CheckForPhase3Dependencies(conversion, converted);



			if (dependencies.Count > 0) return;
			
			

			BuildPhase4(conversion, converted);
		}

	    private void BuildPhase4(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
		    // This is null for closed generic types
		    if (converted.TypeBuilder != null)
		    {
			    if (!(converted is ConvertedGenericTypeDefinition_I generic && generic.IsClosedType()))
			    {
				    NonGenericInstances.Phase3Instructions.Build(conversion, converted);
			    }

			    if (converted.ConversionState.Phase3Dependencies.Count > 0) return;

				converted.TypeBuilder.CreateType();
		    }

		    Types.Building.UpdateBuildPhase(converted, BuildPhaseKind.TypeCreated);

		    var dependents = converted.ConversionState.Phase3Dependents.Values.ToArray();

		    for (int i = 0; i < dependents.Length; i++)
		    {
			    var dependent = dependents[i];

			    dependent.ConversionState.Phase3Dependencies.Remove(converted.ResolutionName);

			    if (dependent.ConversionState.Phase3Dependencies.Count == 0)
			    {
				    BuildPhase4(conversion, dependent);
			    }
		    }
	    }

	    public Dictionary<string, ConvertedTypeDefinition_I> CheckForPhase3Dependencies(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
			if (converted.TypeBuilder == null) return converted.ConversionState.Phase3Dependencies;

		    if (converted.FullName == "Root.Code.Apis.E01D.Runtimic.RuntimicContainerApi_I`1")
		    {
			    
		    }

		    if (converted.FullName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.RuntimicContainerB_I`1")
		    {

		    }

			if (converted.BaseType != null)
		    {
			    var baseType = converted.BaseType;

			    if (baseType is ConvertedTypeDefinition_I convertedBaseType)
			    {
				    CheckForPhase3Dependency(convertedBaseType, converted);
			    }
		    }

		    if ((converted.SupportsInterfaceTypeList() && converted is SemanticTypeWithInterfaceTypeList_I withInterfaces))
		    {
			    var array = withInterfaces.Interfaces.ByResolutionName.Values.ToArray();

			    for (int i = 0; i < array.Length; i++)
			    {
				    var interfaceDeclaration = array[i];

				    if (interfaceDeclaration is ConvertedTypeDefinition_I convertedInterface)
				    {
					    CheckForPhase3Dependency(convertedInterface, converted);
				    }
			    }

			    
		    }

		    if (converted is ConvertedGenericTypeDefinition_I genericType)
		    {
			    var blueprint = genericType.Blueprint;

			    if (blueprint is ConvertedGenericTypeDefinition_I convertedBlueprint)
			    {
				    CheckForPhase3Dependency(convertedBlueprint, converted);
				}

			    var typeParameters = genericType.TypeParameters.All;

			    for (int i = 0; i < typeParameters.Count; i++)
			    {
				    var typeParameter = typeParameters[i];

				    if (typeParameter is ConvertedTypeParameterDefinitionMask_I convertedTypeParameter)
				    {
					    var semanticBaseTypeConstraint = convertedTypeParameter?.BaseTypeConstraint?.Class;

					    if (semanticBaseTypeConstraint != null && semanticBaseTypeConstraint is ConvertedTypeDefinition_I convertedBaseTypeConstraint)
					    {
						    CheckForPhase3Dependency(convertedBaseTypeConstraint, converted);
						}

					    var semanticInterfaceConstraints = convertedTypeParameter?.InterfaceTypeConstraints;

					    if (semanticInterfaceConstraints != null)
					    {
						    for (int j = 0; j < semanticInterfaceConstraints.Count; j++)
						    {
							    var semanticInterface = semanticInterfaceConstraints[j].Interface;

							    if (semanticInterface is ConvertedTypeDefinition_I convertedInterface)
							    {
									CheckForPhase3Dependency(convertedInterface, converted);
							    }
						    }
					    }
				    }
			    }
		    }

		 //   var typeDefinition = Cecil.Types.Getting.GetDefinition(conversion.Model, converted.SourceTypeReference);

			//var methods = typeDefinition.Methods;

			//for (int i = 0; i < methods.Count; i++)
			//{
			//	var method = methods[i];

			//	if (!method.HasBody || method.Body == null) continue; // can be null if it is a delegate

			//	Instructions.TypeScanning.EnsureTypes(conversion, converted, method, method.Body.Instructions);
			//}

			return converted.ConversionState.Phase3Dependencies;


	    }

	    public void CheckForPhase3Dependency(ConvertedTypeDefinition_I dependency, ConvertedTypeDefinition_I dependent)
	    {
		    CheckForPhase3Dependency(dependency, dependent, false);

	    }

	    public bool CheckForPhase3Dependency(ConvertedTypeDefinition_I dependency, ConvertedTypeDefinition_I dependent, bool allowMembersDefined)
	    {
		    

		    if (ReferenceEquals(dependency, dependent))
		    {
			    return false;
		    }

		    bool foundDependency = false;

			if (dependency.ConversionState.BuildPhase != BuildPhaseKind.TypeCreated 
				&& (!allowMembersDefined || dependency.ConversionState.BuildPhase != BuildPhaseKind.MembersDefined))
		    {
			    AddDependentOrDependency(dependency.ConversionState.Phase3Dependents, dependent);

			    AddDependentOrDependency(dependent.ConversionState.Phase3Dependencies, dependency);

				foundDependency = true;

			}

		    if (dependency is ConvertedGenericTypeDefinition_I genericDependency)
		    {
			    var genericDependencyBlueprint = genericDependency.Blueprint;

			    if (ReferenceEquals(genericDependencyBlueprint, dependent))
			    {
				    return foundDependency;
			    }

			    if (genericDependencyBlueprint is ConvertedGenericTypeDefinition_I convertedGenericDependencyBlueprint)
			    {
				    if (convertedGenericDependencyBlueprint.ConversionState.BuildPhase != BuildPhaseKind.TypeCreated
				        && (!allowMembersDefined || convertedGenericDependencyBlueprint.ConversionState.BuildPhase != BuildPhaseKind.MembersDefined))
				    {
					    AddDependentOrDependency(convertedGenericDependencyBlueprint.ConversionState.Phase3Dependents, dependent);

					    AddDependentOrDependency(dependent.ConversionState.Phase3Dependencies, convertedGenericDependencyBlueprint);

					    foundDependency = true;
					}
			    }
		    }

		    return foundDependency;

	    }

		public void AddDependentOrDependency(Dictionary<string, ConvertedTypeDefinition_I> dictionary, ConvertedTypeDefinition_I converted)
	    {
		    if (!dictionary.ContainsKey(converted.ResolutionName))
		    {
			    dictionary.Add(converted.ResolutionName, converted);
		    }
	    }

	    public void UpdateBuildPhase(ConvertedTypeDefinition_I converted, BuildPhaseKind buildPhase)
	    {
		    converted.ConversionState.BuildPhase = buildPhase;
	    }
	}
}
