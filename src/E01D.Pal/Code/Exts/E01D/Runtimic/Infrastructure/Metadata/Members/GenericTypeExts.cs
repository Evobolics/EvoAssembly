using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Domains.E01D;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members
{
    public static class GenericTypeExts
    {
        public static bool IsClosedType(this GenericTypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsClosedType(type);
        }

        public static bool IsOpenType(this GenericTypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsOpenType(type);
        }
    }
}
