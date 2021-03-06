﻿using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface AdditionApiMask_I
    {
	    SemanticTypeMask_I Add(RuntimicSystemModel semanticModel, SemanticModuleMask_I module,
		    SemanticTypeDefinitionMask_I entry);

    }
}
