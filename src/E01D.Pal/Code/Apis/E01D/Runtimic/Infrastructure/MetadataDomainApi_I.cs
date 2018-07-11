using Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Attributes.E01D;
using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure
{
    [StaticApi]
    [PhenotypeMask]
    public interface MetadataDomainApi_I
    {
        MemberDomainApi_I Members { get; }

        AssemblyDomainApi Assemblies { get;  }

        bool Is(RuntimicNode_I metadata, RuntimicKind kind);

        bool IsConverted(RuntimicNode_I assembly);

        bool IsBound(RuntimicNode_I assembly);

        bool IsEmitted(RuntimicNode_I assembly);

        bool IsSemantic(RuntimicNode_I assembly);
    }
}
