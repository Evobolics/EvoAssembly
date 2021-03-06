﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution
{
	public interface ExecutionArrayTypeDefinition_I: ExecutionTypeDefinition_I, ExecutionArrayTypeDefinitionMask_I
	{
		new SemanticTypeDefinitionMask_I ElementType { get; set; }
	}
}
