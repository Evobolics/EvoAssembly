using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class LoadingApi<TContainer> : CecilApiNode<TContainer>,LoadingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		//public int Load(InfrastructureRuntimicModelMask_I model, List<AssemblyDefinition> assemblies)
		//{
		//	EnsureAndGetTypeList(model, assemblies, false, out int count);

		//	return count;
		//}

		//public void Load(ILConversionExecutionModel model, TypeReference[] inputTypes)
		//{
		//	throw new NotImplementedException();
		//}

		
	}
}
