﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Building.NonGenericInstances
{
	public class Phase0PreSearchBuildApi<TContainer> : BoundApiNode<TContainer>, Phase0PreSearchBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		///// <summary>
		///// Assigns the generic blueprint and the type arguments to the generic instance type.
		///// </summary>
		///// <param name="conversion"></param>
		///// <param name="converted"></param>
		///// <returns></returns>
		//public Type[] Build(ILConversion conversion, ConvertedGenericTypeDefinition_I converted)
		//{
		//	throw new Exception();
		//}

		//public BoundGenericTypeDefinitionMask_I EnsureGenericBlueprint(ILConversion conversion, ConvertedGenericTypeDefinition_I converted)
		//{
		//	throw new Exception();
		//}
	}
}
