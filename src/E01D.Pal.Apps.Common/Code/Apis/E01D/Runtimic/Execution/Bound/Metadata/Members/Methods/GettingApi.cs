using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public class GettingApi<TContainer> : BoundApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public SemanticMethodMask_I FindMethodByDefinition(InfrastructureRuntimicModelMask_I model, BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods, MethodDefinition methodDefinition)
		{
			if (!boundTypeWithMethods.Methods.ByName.TryGetValue(methodDefinition.Name, out List<SemanticMethodMask_I> list))
			{
				throw new Exception($"Could not find the method named {methodDefinition.Name}.");
			}

			for (int i = 0; i < list.Count; i++)
			{
				var method = list[i];

				if (Cecil.Metadata.Members.Methods.AreSame(model, methodDefinition, method.MethodReference, false))
				{
					return method;
				}
			}

			throw new Exception("Could not find the method.");
		}

	    public MethodInfo[] GetMethodInfos(BoundTypeDefinitionMask_I inputBlueprint)
	    {
		    var methodEntries = GetMethods(inputBlueprint);

		    var methods = new MethodInfo[methodEntries.Count];

		    for (int i = 0; i < methodEntries.Count; i++)
		    {
			    methods[i] = methodEntries[i].UnderlyingMethod;
		    }

		    return methods;
	    }

		public List<BoundMethodDefinitionMask_I> GetMethods(BoundTypeDefinitionMask_I inputBlueprint)
	    {
		    if (!(inputBlueprint is BoundTypeDefinitionWithMethodsMask_I withMethods))
		    {
			    throw new System.Exception("GenericClassDefinition should have methods if this type has methods.");
		    }

		    var collection = withMethods.Methods.ByName.Values.ToList();

		    List<BoundMethodDefinitionMask_I> methods = new List<BoundMethodDefinitionMask_I>();

		    for (int i = 0; i < collection.Count; i++)
		    {
			    var semanticList = collection[i];

			    for (int j = 0; j < semanticList.Count; j++)
			    {
				    var semantic = semanticList[j];

				    if (!(semantic is BoundMethodDefinitionMask_I bound))
				    {
					    throw new System.Exception("Semantic method should be a bound method to use it in conversion.");
				    }

				    methods.Add(bound);
			    }


		    }

		    return methods;
	    }
	}
}
