﻿using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public class BoundGenericTypeDefinitionGenericTypeArguments: BoundGenericTypeDefinitionGenericTypeArguments_I
	{
		public List<SemanticTypeDefinitionMask_I> All { get; set; } = new List<SemanticTypeDefinitionMask_I>();

		

		List<SemanticTypeDefinitionMask_I> SemanticGenericTypeDefinitionGenericTypeArgumentsMask_I.All => All;

		
	}
}
