using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeParameters;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Apis.E01D.Sorting;
using Root.Code.Containers.E01D.Runtimic;
using TypeApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.TypeApiMask_I;


namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound
{
    public abstract class BoundApiNode<TContainer>: RuntimeApiNode<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public Metadata.Assemblies.AssemblyApiMask_I Assemblies => Container.Api.Runtimic.Execution.Bound.Metadata.Assemblies;

        public BindingApiMask_I Bound => Container.Api.Runtimic.Execution.Bound;

        public CecilApiMask_I Cecil => Container.Api.Runtimic.Infrastructure.Structural.Cecil;

        public ConstructorApiMask_I Constructors => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Constructors;

        public ConversionApiMask_I Conversion => Container.Api.Runtimic.Execution.Conversion;

        public EmittingApiMask_I Emitting => Container.Api.Runtimic.Execution.Emitting;

        public EventApiMask_I Events => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Events;

        public FieldApiMask_I Fields => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Fields;

        

        public Infrastructure.Semantic.SemanticApiMask_I Semantic => Container.Api.Runtimic.Infrastructure.Semantic;

        public InstructionApiMask_I Instructions => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Instructions;

        public LocalApiMask_I Locals => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Locals;

        public MemberApiMask_I Members => Container.Api.Runtimic.Execution.Bound.Metadata.Members;

        public Metadata.MetadataApiMask_I Metadata => Container.Api.Runtimic.Execution.Bound.Metadata;

        public MethodApiMask_I Methods => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Methods;

        public ModelApiMask_I Models => Container.Api.Runtimic.Execution.Bound.Models;

        public ModuleApiMask_I Modules => Container.Api.Runtimic.Execution.Bound.Metadata.Modules;

        public ParameterApiMask_I Parameters => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Parameters;

        public PropertyApiMask_I Properties => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Properties;

        public RuntimicApiMask_I Runtimic => Container.Api.Runtimic;

        public SortingApiMask_I Sorting => Container.Api.Sorting;

        public TypeParameterApiMask_I TypeParameters => Container.Api.Runtimic.Execution.Bound.Metadata.Members.TypeParameters;

        public TypeApiMask_I Types => Container.Api.Runtimic.Execution.Bound.Metadata.Members.Types;

    }
}
