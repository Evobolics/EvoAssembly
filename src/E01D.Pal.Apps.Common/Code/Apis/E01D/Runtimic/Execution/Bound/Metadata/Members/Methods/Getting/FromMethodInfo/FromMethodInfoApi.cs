using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Mono.Collections.Generic;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public class FromMethodInfoApi<TContainer> : BindingApiNode<TContainer>, FromMethodInfoApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public DefinitionApi_I<TContainer> Definitions { get; set; }


		DefinitionApiMask_I FromMethodInfoApiMask_I.Definitions => Definitions;

		public ReferenceApi_I<TContainer> References { get; set; }


		ReferenceApiMask_I FromMethodInfoApiMask_I.References => References;

		

		
	}
}
