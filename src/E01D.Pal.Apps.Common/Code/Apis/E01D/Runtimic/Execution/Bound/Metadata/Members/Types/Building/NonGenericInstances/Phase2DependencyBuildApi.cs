﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Building.NonGenericInstances
{
	public class Phase2DependencyBuildApi<TContainer> : BoundApiNode<TContainer>, Phase2DependencyBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		//public void Build(ILConversion conversion, ConvertedTypeDefinition_I converted)
		//{
		//	throw new Exception();



		//}
	}
}
