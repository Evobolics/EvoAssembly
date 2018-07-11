using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.CustomAttributes;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Events;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Parameters;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Apis.E01D.Runtimic.Execution.Metadata;
using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Apis.E01D.Sorting;
using Root.Code.Containers.E01D.Runtimic;
using ModelApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.ModelApiMask_I;
using TypeApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.TypeApiMask_I;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion
{
    public abstract class ConversionApiNode<TContainer>:Api<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public Metadata.Assemblies.AssemblyApiMask_I Assemblies
        {
            get
            {
                return Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Assemblies;
            }
        } 

        public BindingApiMask_I Binding => Container.Api.Runtimic.Execution.Binding;

        public CecilApiMask_I Cecil => Container.Api.Runtimic.Infrastructure.Structural.Cecil;

        public ConstructorApiMask_I Constructors => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Constructors;

        public ConversionApiMask_I Conversion => Container.Api.Runtimic.Execution.Emitting.Conversion;

	    public CustomAttributeApiMask_I CustomAttributes => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.CustomAttributes;

		public EmittingApiMask_I Emitting => Container.Api.Runtimic.Execution.Emitting;

        public EventApiMask_I Events => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Events;

        public FieldApiMask_I Fields => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Fields;


        public InfrastructureApiMask_I Infrastructure => Container.Api.Runtimic.Infrastructure;


        public InstructionApiMask_I Instructions => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Instructions;

        public LocalApiMask_I Locals => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Locals;


        public MemberApiMask_I Members => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members;

        public MetadataApiMask_I Metadata => Container.Api.Runtimic.Execution.Metadata;

        public MethodApiMask_I Methods => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Methods;

        public ModelApiMask_I Models => Container.Api.Runtimic.Execution.Emitting.Conversion.Models;

        public ModuleApiMask_I Modules => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Modules;

        public RoutineApiMask_I Routines => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Routines;

        public RuntimicApiMask_I Runtimic => Container.Api.Runtimic;

        public ParameterApiMask_I Parameters => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Parameters;

        public PropertyApiMask_I Properties => Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Properties;

        public SemanticApiMask_I Semantic => Container.Api.Runtimic.Infrastructure.Semantic;

	    public StructuralApiMask_I Structural => Container.Api.Runtimic.Infrastructure.Structural;

		public SortingApiMask_I Sorting => Container.Api.Sorting;

        public TypeApiMask_I Types
        {
            get
            {
                return Container.Api.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Types;
            }
        }
    }
}
