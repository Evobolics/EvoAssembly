using System;
using System.Collections.Generic;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Building.NonGenericInstances;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Building
{
	/// <summary>
	/// The type, and its associated sub system types, responsible for building out a type.
	/// </summary>
	/// <typeparam name="TContainer"></typeparam>
    public class BuildingApi<TContainer> : BindingApiNode<TContainer>, BuildingApi_I<TContainer>
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
			throw new Exception();
		}

	    private List<ConvertedTypeDefinition_I> CheckForBakingDependencies(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
			throw new Exception();

		}

	    public void Bake(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
			throw new Exception();



		}

	    

	    

	    public void MarkAsBaked(ConvertedTypeDefinition_I converted)
	    {
			throw new Exception();




		}
	}
}
