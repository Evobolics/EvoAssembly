﻿using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface BoundTypeWithBaseTypeMask_I: BoundTypeMask_I
    {
         SemanticTypeMask_I BaseType { get;  }
    }
}