using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Mono.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public class FromMethodInfoApi<TContainer> : ConversionApiNode<TContainer>, FromMethodInfoApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public DefinitionApi_I<TContainer> Definitions { get; set; }


		DefinitionApiMask_I FromMethodInfoApiMask_I.Definitions => Definitions;

		public ReferenceApi_I<TContainer> References { get; set; }


		ReferenceApiMask_I FromMethodInfoApiMask_I.References => References;

		

		private List<MethodDefinition> FindMatchingMethod(ILConversion conversion, ConvertedGenericTypeDefinition_I input, Collection<MethodDefinition> methodDefinitions, MethodInfo method)
		{
			var name = method.Name;

			List<MethodDefinition> canidatesBasedUponName = new List<MethodDefinition>();

			for (int i = 0; i < methodDefinitions.Count; i++)
			{
				var methodDefinition = methodDefinitions[i];

				if (methodDefinition.Name == name)
				{
					canidatesBasedUponName.Add(methodDefinition);
				}
			}

			if (canidatesBasedUponName.Count == 0)
			{
				throw new Exception($"Could not find a method matching the method name {name}.");
			}

			if (canidatesBasedUponName.Count == 1)
			{
				return canidatesBasedUponName;
			}

			throw new Exception($"Found more than one method matching the method name {name}.");
		}
	}
}
