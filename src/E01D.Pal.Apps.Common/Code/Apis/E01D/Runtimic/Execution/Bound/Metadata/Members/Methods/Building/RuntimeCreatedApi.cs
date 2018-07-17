using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods.Building
{
	public class RuntimeCreatedApi<TContainer> : BoundApiNode<TContainer>, RuntimeCreatedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void BuildMethods(InfrastructureRuntimicModelMask_I model, BoundTypeDefinition_I input)
		{
			if (!(input is BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods))
			{
				return;
			}

			if (input.FullName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.GenericClassWithMembersThatTakeInGenericClassParameters`1<T>")
			{
				
			}

			// Done on purpose to find errors
			var methods = input.UnderlyingType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

			List<BoundMethod> boundMethods = new List<BoundMethod>(methods.Length);

			for (int i = 0; i < methods.Length; i++)
			{
				var method = methods[i];

				var boundMethod = BuildMethod(model, input, method);

				if (!boundTypeWithMethods.Methods.ByName.TryGetValue(boundMethod.Name, out List<SemanticMethodMask_I> methodList))
				{
					methodList = new List<SemanticMethodMask_I>();

					boundTypeWithMethods.Methods.ByName.Add(boundMethod.Name, methodList);
				}

				methodList.Add(boundMethod);

				boundMethods.Add(boundMethod);

				// NULL CHECK: Possibly null if a generic instance
				input.Module?.MethodsByMetadataToken.Add(method.MetadataToken, boundMethod);
			}

			// Get the type definition that corresponds to the type reference.  This will store all the methods that are available.
			var declaringTypeDefinition = Cecil.Metadata.Members.Types.Getting.GetDefinition(model, input.SourceTypeReference);

			// Ensure all the methods are added to prevent this problem:
			#region

			#endregion
			for (int i = 0; i < boundMethods.Count; i++)
			{
				var boundMethod = boundMethods[i];

				// Search the declaring type definition for the method definition that matches the method info.
				boundMethod.MethodReference = Cecil.Metadata.Members.Methods.Getting.FromMethodInfos.References.GetMethodReference(model, declaringTypeDefinition.Methods, boundMethod.UnderlyingMethod);
			}
		}

		

		public BoundMethod BuildMethod(InfrastructureRuntimicModelMask_I model, BoundTypeDefinition_I input, MethodInfo method)
		{
			BoundMethod boundMethod;

			if (method.GetGenericArguments().Length > 0)
			{
				boundMethod = new BoundGenericInstanceMethod
				{	
					DeclaringType = input,
					MethodAttributes = method.Attributes,
					Name = method.Name,
					UnderlyingMethod = method
				};
			}
			else
			{
				boundMethod = new BoundNonGenericInstanceMethod
				{
					DeclaringType = input,
					MethodAttributes = method.Attributes,
					Name = method.Name,
					UnderlyingMethod = method
				};
			}

			return boundMethod;
		}
	}
}
