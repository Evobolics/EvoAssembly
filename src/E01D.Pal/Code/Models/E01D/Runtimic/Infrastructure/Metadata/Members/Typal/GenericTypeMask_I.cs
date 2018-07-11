using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal
{
    public interface GenericTypeMask_I
    {
        TypeReference GenericTypeDefinition { get;  }

        GenericTypeKind GenericKind { get;  }

	    
    
	}
}
