using Root.Code.Domains.E01D;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata;

namespace Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata
{
    public static class MetadataExts
    {
        public static bool IsBound(this RuntimicNode_I assembly)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.IsBound(assembly);
        }

        public static bool IsConverted(this RuntimicNode_I assembly)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.IsConverted(assembly);
        }

        

        public static bool IsEmitted(this RuntimicNode_I assembly)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.IsEmitted(assembly);
        }

        public static bool IsSemantic(this RuntimicNode_I assembly)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.IsSemantic(assembly);
        }
    }
}
