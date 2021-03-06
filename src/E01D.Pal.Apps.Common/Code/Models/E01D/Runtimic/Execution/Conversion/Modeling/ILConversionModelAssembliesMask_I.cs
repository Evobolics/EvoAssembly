﻿using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling
{
	public interface ILConversionModelAssembliesMask_I: SemanticModelAssembliesMask_I
	{
		Dictionary<string, ConvertedAssembly_I> Collectible { get; }
	}
}
