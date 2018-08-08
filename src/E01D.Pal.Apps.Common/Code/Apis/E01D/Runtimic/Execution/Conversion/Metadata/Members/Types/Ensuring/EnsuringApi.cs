using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using GatheringApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering.GatheringApiMask_I;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
	public class EnsuringApi<TContainer> : ConversionApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		#region Api(s)

		
        //public ArrayApi_I<TContainer> Arrays { get; set; }

        //ArrayApiMask_I EnsuringApiMask_I.Arrays => Arrays;

        

        
        public DotNetApi<TContainer> DotNet { get; set; }

        DotNetApiMask_I EnsuringApiMask_I.DotNet => DotNet;

        
        public EnumApi_I<TContainer> Enums { get; set; }

        EnumApiMask_I EnsuringApiMask_I.Enums => Enums;

        public GenericApi_I<TContainer> Generic { get; set; }

        GenericInstancesApiMask_I EnsuringApiMask_I.Generic => Generic;

        public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

        GenericParameterApiMask_I EnsuringApiMask_I.GenericParameters => GenericParameters;

        public Gathering.GatheringApi<TContainer> Gathering { get; set; }

        GatheringApiMask_I EnsuringApiMask_I.Gathering => Gathering;

        public NonGenericInstanceApi_I<TContainer> NonGenericInstances { get; set; }

        NonGenericInstanceApiMask_I EnsuringApiMask_I.NonGenericInstances => NonGenericInstances;

	    //public new UnifiedApi_I<TContainer> Unified { get; set; }

	    //UnifiedApiMask_I EnsuringApiMask_I.Unified => Unified;

		#endregion



		public bool EnsurePhase3Type(ILConversion conversion,
			ConvertedTypeDefinitionMask_I routineDeclaringType,
			MethodDefinition methodDefinition,
			TypeReference typeReference,
			out BoundTypeDefinitionMask_I type)
		{
			type = Execution.Types.Ensuring.EnsureBound(new ExecutionEnsureContext()
			{
				RuntimicSystem = conversion.RuntimicSystem,
				Conversion = conversion,
				TypeReference = typeReference,
				MethodReference = methodDefinition,
				RoutineDeclaringType = routineDeclaringType
			});

			if ((type is ConvertedTypeDefinition_I convertedType))
			{
				if (Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routineDeclaringType, true))
				{
					return false;
				}
			}
			return true;
		}




		/// <summary>
		/// Ensures the type has been added to the module.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="convertedModule">The module that is going to house the type.  This should be a convertible module if the type is being converted as the 
		/// converter will need a module builder. </param>
		/// <param name="input"></param>
		/// <param name="declaringType"></param>
		public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion,TypeReference typeReference, ConvertedTypeDefinition_I declaringType)
        {
	        // Check to see if this input is to be converted, or needs to be relegated to bound only.
	        

			// The choice was made to seperate out the various cases.  This enables each one to be developed seperately without having ot worry about how code 
			// changes will affect the other cases.  It does have some duplication of code, but not much.  This keeps the code cleaner and easier to read.

			
	        

			if (typeReference.IsGenericInstance)
            {
                return Generic.Ensure(conversion, (GenericInstanceType)typeReference, declaringType);
            }

            return NonGenericInstances.Ensure(conversion, typeReference, declaringType);

            
        }

        

        

       

    }
}
