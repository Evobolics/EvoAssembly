using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeArguments;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeParameters;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using TypeApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.TypeApiMask_I;


namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public class MemberApi<TContainer>: BoundApiNode<TContainer>, MemberApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public new AssemblyApi_I<TContainer> Assemblies { get; set; }

        public new ConstructorApi_I<TContainer> Constructors { get; set; }

        public new EventApi_I<TContainer> Events { get; set; }

        public new FieldApi_I<TContainer> Fields { get; set; }

        public new InstructionApi_I<TContainer> Instructions { get; set; }

        public new LocalApi_I<TContainer> Locals { get; set; }

        public new MethodApi_I<TContainer> Methods { get; set; }

        

        public new ModuleApiMask_I Modules { get; set; }

        public new ParameterApi_I<TContainer> Parameters { get; set; }

        public new PropertyApi_I<TContainer> Properties { get; set; }

	    public TypeArguments.TypeArgumentApi_I<TContainer> TypeArguments { get; set; }

		public new TypeParameterApi_I<TContainer> TypeParameters { get; set; }

        public new Types.TypeApi_I<TContainer> Types { get; set; }
        


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

        public BoundTypeDefinitionMask_I GetDeclaringType(BoundRuntimicModelMask_I model, MemberReference memberReference)
        {
            if (memberReference == null)
            {
                throw new System.Exception($"Member reference is null. Cannot get member declaring type.");
            }

            var declaringTypeRef = memberReference.DeclaringType;

            return Models.Types.ResolveToBound(model, declaringTypeRef);
        }
    }
}
