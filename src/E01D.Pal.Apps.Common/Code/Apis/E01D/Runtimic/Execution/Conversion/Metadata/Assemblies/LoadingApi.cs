﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class LoadingApi<TContainer> : ConversionApiNode<TContainer>, LoadingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		//public List<AssemblyDefinition> LoadAssemblyDefinitions(ILConversion conversion, Assembly[] assemblies)
		//{
		//	var results = new List<AssemblyDefinition>(assemblies.Length);

		//	for (int i = 0; i < assemblies.Length; i++)
		//	{
		//		var assembly = assemblies[i];

		//		results[i] = LoadAssemblyDefinition(conversion, assembly);
		//	}

		//	return results;
		//}

		//public AssemblyDefinition LoadAssemblyDefinition(ILConversion conversion, Assembly assembly)
		//{
		//	//return Cecil.Assemblies.Ensuring.Ensure(conversion.Model, assembly);
		//	throw new Exception("Debug");
		//}
	}
}
