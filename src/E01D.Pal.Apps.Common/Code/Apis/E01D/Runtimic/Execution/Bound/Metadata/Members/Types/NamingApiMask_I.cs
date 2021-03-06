﻿using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface NamingApiMask_I
    {
        string GetResolutionName(TypeReference input);

        string GetResolutionName(System.Type input);

	    string GetResolutionName(SemanticTypeMask_I input);

    }
}
