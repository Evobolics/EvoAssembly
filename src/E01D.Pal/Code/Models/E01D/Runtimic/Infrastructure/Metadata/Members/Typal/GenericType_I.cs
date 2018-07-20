using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal
{
    public interface GenericType_I: GenericTypeMask_I
    {
        

        new GenericTypeKind GenericKind { get; set; }
    }
}
