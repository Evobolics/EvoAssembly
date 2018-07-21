using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Events;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeArguments;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Parameters;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using TypeParameterApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeParameters.TypeParameterApiMask_I;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class MemberApi<TContainer>: ConversionApiNode<TContainer>, MemberApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

        #region Api(s)
        public new ConstructorApi_I<TContainer> Constructors { get; set; }

        public new EventApi_I<TContainer> Events { get; set; }

        public new FieldApi_I<TContainer> Fields { get; set; }

        public new InstructionApi_I<TContainer> Instructions { get; set; }

        public new LocalApi_I<TContainer> Locals { get; set; }

        public new MethodApi_I<TContainer> Methods { get; set; }

        public new ModelApi_I<TContainer> Models { get; set; }

        public new ModuleApiMask_I Modules { get; set; }

        public new ParameterApi_I<TContainer> Parameters { get; set; }

        public new PropertyApi_I<TContainer> Properties { get; set; }

        public new RoutineApi_I<TContainer> Routines { get; set; }

        public new TypeApi_I<TContainer> Types { get; set; }

	    public TypeArguments.TypeArgumentApi_I<TContainer> TypeArguments { get; set; }

		public TypeParameters.TypeParameterApi_I<TContainer> TypeParameters { get; set; }

		

        ConstructorApiMask_I MemberApiMask_I.Constructors => Constructors;

        EventApiMask_I MemberApiMask_I.Events => Events;

        FieldApiMask_I MemberApiMask_I.Fields => Fields;

        InstructionApiMask_I MemberApiMask_I.Instructions => Instructions;

        LocalApiMask_I MemberApiMask_I.Locals => Locals;

        MethodApiMask_I MemberApiMask_I.Methods => Methods;

        

        

        PropertyApiMask_I MemberApiMask_I.Properties => Properties;

        ParameterApiMask_I MemberApiMask_I.Parameters => Parameters;

	    TypeArgumentApiMask_I MemberApiMask_I.TypeArguments => TypeArguments;

		TypeParameterApiMask_I MemberApiMask_I.TypeParameters => TypeParameters;

        TypeApiMask_I MemberApiMask_I.Types => Types;

        #endregion

        public bool GetMemberInfo(ILConversion conversion, ConvertedTypeDefinition_I typeBeingBuilt, MethodReference methodReference, out MemberInfo memberInfo)
        {
            if (methodReference == null)
            {
                throw new System.Exception($"Member reference is null. Cannot resolve member info.");
            }

	        

			// If a constructor 
			if (methodReference.Name == ConstructorInfo.ConstructorName)
            {
	            // how does the member reference declaring type be resolved?
	            var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion.Model, methodReference.DeclaringType);

				return Constructors.Getting.GetConstructor(conversion, typeBeingBuilt, declaringBound, methodReference, out memberInfo);
            }
			
			memberInfo = Methods.Getting.GetMethodInfoOrThrow(conversion, typeBeingBuilt, methodReference);

			return memberInfo != null;
	       
        }

        public BoundTypeDefinitionMask_I GetDeclaringType(ILConversion conversion, MemberReference memberReference)
        {
            if (memberReference == null)
            {
                throw new System.Exception($"Member reference is null. Cannot get member declaring type.");
            }

            var declaringTypeRef = memberReference.DeclaringType;

            return Execution.Types.Ensuring.EnsureBound(conversion.Model, declaringTypeRef);
        }
    }
}
