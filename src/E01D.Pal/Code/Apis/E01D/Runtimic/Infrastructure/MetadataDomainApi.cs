using Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Attributes.E01D;
using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure
{
    public class MetadataDomainApi: MetadataDomainApi_I
    {
        [DynamicallyReplaceWithContainerApi]
        public AssemblyDomainApi Assemblies { get; set; } = new AssemblyDomainApi();

        [DynamicallyReplaceWithContainerApi]
        public MemberDomainApi_I Members { get; } = new MemberDomainApi();

        public bool Is(RuntimicNode_I metadata, RuntimicKind kind)
        {
            return (metadata.RuntimicKind & kind) == kind;
        }

        

        public bool IsBound(RuntimicNode_I assembly)
        {
            return Is(assembly, RuntimicKind.Bound);
        }

        public bool IsConverted(RuntimicNode_I assembly)
        {
            return Is(assembly, RuntimicKind.Converted);
        }

        public bool IsEmitted(RuntimicNode_I assembly)
        {
            return Is(assembly, RuntimicKind.Emitted);
        }

        public bool IsSemantic(RuntimicNode_I assembly)
        {
            return Is(assembly, RuntimicKind.Semantic);
        }
    }
}
