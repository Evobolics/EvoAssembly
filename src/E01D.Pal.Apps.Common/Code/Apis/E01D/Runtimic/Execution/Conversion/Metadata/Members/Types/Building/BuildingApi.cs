using System.Collections.Generic;
using System.Linq;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.GenericInstances;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;


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
			// There is not just building work to be done.  There is actually pre and post being working to be done.  The dependency check is to verify if there is any
			// post build work to be done.  
			List<ConvertedTypeDefinition_I> dependencies = CheckForBuildDependencies(conversion, converted, 2);

			if (dependencies.Count < 1)
			{
				// Build all members
				BuildPhase2(conversion, converted);

				// Give a chance for all dependencies to build all members
				var dependents = converted.Phase2Dependents;

				for (int i = 0; i < dependents.Count; i++)
				{
					var dependent = dependents[i];

					dependent.Phase2Dependencies.Remove(converted);

					if (dependent.Phase2Dependencies.Count == 0)
					{
						BuildPhase2(conversion, dependent);
					}
				}

				converted.Phase2Dependents.Clear();

				BuildPhase3(conversion, converted);
			}
			else
			{
				for (int i = 0; i < dependencies.Count; i++)
				{
					var dependency = dependencies[i];

					converted.Phase2Dependencies.Add(dependency);

					dependency.Phase2Dependents.Add(converted);
				}
			}
		}

	    

	    private List<ConvertedTypeDefinition_I> CheckForBuildDependencies(ILConversion conversion, ConvertedTypeDefinition_I converted, int targetPhase)
	    {
		    List<ConvertedTypeDefinition_I> result = new List<ConvertedTypeDefinition_I>();

		    if (converted is ConvertedGenericTypeDefinition_I generic)
		    {
			    if (generic.Blueprint != null && generic.Blueprint is ConvertedTypeDefinition_I convertedBlueprint && convertedBlueprint.BuildPhase < targetPhase)
			    {
				    result.Add(convertedBlueprint);
			    }
		    }

		    return result;

	    }

	    public void BuildPhase2(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
		    

		    if (converted.BuildPhase != 1)
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

		    Types.Building.UpdateBuildPhase(converted, 2);
		}

		private void BuildPhase3(ILConversion conversion, ConvertedTypeDefinition_I converted)
		{
			

			if (converted.BuildPhase != 2)
			{
				throw new System.Exception("Expecting the current build phase to be phase 2");
			}

			
			// This is null for closed generic types
			if (converted.TypeBuilder != null)
			{
				var dependencies = CheckForPhase3Dependencies(converted);

				if (dependencies.Count == 0)
				{
					BuildPhase3_NoDependencies(conversion, converted);
				}
			}
			else
			{
				// Go ahead and set their phase to 3.
				Types.Building.UpdateBuildPhase(converted, 3);
			}
			
		}

	    private void BuildPhase3_NoDependencies(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
		    if (converted.AssemblyQualifiedName ==
		        "Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies.AdditionApi_I`1, E01D.Pal.Apps.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
		    )
		    {
			    
		    }

		    if (!(converted is ConvertedGenericTypeDefinition_I generic && generic.IsClosedType()))
		    {
			    NonGenericInstances.Phase3Instructions.Build(conversion, converted);
		    }

			converted.TypeBuilder.CreateType();

		    Types.Building.UpdateBuildPhase(converted, 3);

		    var dependents = converted.Phase3Dependents;

		    for (int i = 0; i < dependents.Count; i++)
		    {
			    var dependent = dependents[i];

			    dependent.Phase3Dependencies.Remove(converted);

			    if (dependent.Phase3Dependencies.Count == 0)
			    {
				    BuildPhase3_NoDependencies(conversion, dependent);
			    }
		    }
	    }

	    private static List<ConvertedTypeDefinition_I> CheckForPhase3Dependencies(ConvertedTypeDefinition_I converted)
	    {
		    if (converted.BaseType != null)
		    {
			    var baseType = converted.BaseType;

			    if (baseType is ConvertedTypeDefinition_I convertedBaseType)
			    {
				    if (convertedBaseType.BuildPhase != 3)
				    {
					    convertedBaseType.Phase3Dependents.Add(converted);

					    converted.Phase3Dependencies.Add(convertedBaseType);
				    }
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
					    if (convertedInterface.BuildPhase != 3)
					    {
						    convertedInterface.Phase3Dependents.Add(converted);

						    converted.Phase3Dependencies.Add(convertedInterface);
					    }
				    }
			    }

			    
		    }

		    if (converted is ConvertedGenericTypeDefinition_I genericType)
		    {
			    var typeParameters = genericType.TypeParameters.All;

			    for (int i = 0; i < typeParameters.Count; i++)
			    {
				    var typeParameter = typeParameters[i];

				    if (typeParameter is ConvertedGenericParameterTypeDefinitionMask_I convertedTypeParameter)
				    {
					    var semanticBaseTypeConstraint = convertedTypeParameter?.BaseTypeConstraint?.SemanticType;

					    if (semanticBaseTypeConstraint != null && semanticBaseTypeConstraint is ConvertedTypeDefinition_I convertedBaseTypeConstraint)
					    {
							if (convertedBaseTypeConstraint.BuildPhase != 3)
							{
								convertedBaseTypeConstraint.Phase3Dependents.Add(converted);

								converted.Phase3Dependencies.Add(convertedBaseTypeConstraint);
							}
						}

					    var semanticInterfaceConstraints = convertedTypeParameter?.InterfaceTypeConstraints;

					    if (semanticInterfaceConstraints != null)
					    {
						    for (int j = 0; j < semanticInterfaceConstraints.Count; j++)
						    {
							    var semanticInterface = semanticInterfaceConstraints[j].SemanticType;

							    if (semanticInterface is ConvertedTypeDefinition_I convertedInterface)
							    {
								    if (convertedInterface.BuildPhase != 3)
								    {
									    convertedInterface.Phase3Dependents.Add(converted);

									    converted.Phase3Dependencies.Add(convertedInterface);
								    }
							    }
						    }
					    }
				    }
			    }
		    }

			return converted.Phase3Dependencies;


	    }

	    public void UpdateBuildPhase(ConvertedTypeDefinition_I converted, int newPhaseNumber)
	    {
		    converted.BuildPhase = newPhaseNumber;
	    }
	}
}
