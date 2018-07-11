using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Fields;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.TypeParameters;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Apis.E01D.Sorting;
using TypeApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.TypeApiMask_I;


namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding
{
    public abstract class BindingApiNode<TContainer>:Api<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public Metadata.Assemblies.AssemblyApiMask_I Assemblies => Container.Api.Runtimic.Execution.Binding.Metadata.Assemblies;

        public BindingApiMask_I Binding => Container.Api.Runtimic.Execution.Binding;

        public CecilApiMask_I Cecil => Container.Api.Runtimic.Infrastructure.Structural.Cecil;

        public ConstructorApiMask_I Constructors => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Constructors;

        public ConversionApiMask_I Conversion => Container.Api.Runtimic.Execution.Emitting.Conversion;

        public EmittingApiMask_I Emitting => Container.Api.Runtimic.Execution.Emitting;

        public EventApiMask_I Events => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Events;

        public FieldApiMask_I Fields => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Fields;

        public InfrastructureApiMask_I Infrastructure => Container.Api.Runtimic.Infrastructure;

        public Infrastructure.Semantic.SemanticApiMask_I Semantic => Container.Api.Runtimic.Infrastructure.Semantic;

        public InstructionApiMask_I Instructions => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Instructions;

        public LocalApiMask_I Locals => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Locals;

        public MemberApiMask_I Members => Container.Api.Runtimic.Execution.Binding.Metadata.Members;

        public Metadata.MetadataApiMask_I Metadata => Container.Api.Runtimic.Execution.Binding.Metadata;

        public MethodApiMask_I Methods => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Methods;

        public ModelApiMask_I Models => Container.Api.Runtimic.Execution.Binding.Models;

        public ModuleApiMask_I Modules => Container.Api.Runtimic.Execution.Binding.Metadata.Modules;

        public ParameterApiMask_I Parameters => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Parameters;

        public PropertyApiMask_I Properties => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Properties;

        public RuntimicApiMask_I Runtimic => Container.Api.Runtimic;

        public SortingApiMask_I Sorting => Container.Api.Sorting;

        public TypeParameterApiMask_I TypeParameters => Container.Api.Runtimic.Execution.Binding.Metadata.Members.TypeParameters;

        public TypeApiMask_I Types => Container.Api.Runtimic.Execution.Binding.Metadata.Members.Types;

    }
}
