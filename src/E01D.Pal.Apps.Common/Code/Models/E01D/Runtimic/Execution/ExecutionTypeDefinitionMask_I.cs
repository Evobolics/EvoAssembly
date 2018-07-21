using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution
{
    public interface ExecutionTypeDefinitionMask_I: SemanticTypeDefinitionMask_I
    {
        System.Type UnderlyingType { get; }
    }
}
