using System.Collections.Generic;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors.Building
{
	public class RuntimeCreatedApi<TContainer> : BindingApiNode<TContainer>, RuntimeCreatedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void BuildConstructors(InfrastructureModelMask_I model, BoundTypeDefinition_I input)
		{
			if (!(input is BoundTypeDefinitionWithConstructorsMask_I boundTypeWithConstructors))
			{
				return;
			}

			if (input.FullName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.GenericClassWithMembersThatTakeInGenericClassParameters`1<T>")
			{
				
			}

			// Done on purpose to find errors
			var constructors = input.UnderlyingType.GetConstructors(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

			List<BoundConstructorDefinition> boundConstructors = new List<BoundConstructorDefinition>(constructors.Length);

			for (int i = 0; i < constructors.Length; i++)
			{
				var constructor = constructors[i];

				var boundConstructor = BuildConstructor(model, input, constructor);

				boundTypeWithConstructors.Constructors.All.Add(boundConstructor);

				boundConstructors.Add(boundConstructor);

				input.Module.ConstructorsByMetadataToken.Add(constructor.MetadataToken, boundConstructor);
			}

			// Get the type definition that corresponds to the type reference.  This will store all the constructors that are available.
			var declaringTypeDefinition = Cecil.Metadata.Members.Types.Getting.GetDefinition(model, input.SourceTypeReference);

			// Ensure all the constructors are added to prevent this problem:
			#region

			#endregion
			for (int i = 0; i < boundConstructors.Count; i++)
			{
				var boundConstructor = boundConstructors[i];

				// Search the declaring type definition for the constructor definition that matches the constructor info.
				boundConstructor.MethodReference = Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfos.References.GetMethodReference(model, declaringTypeDefinition, boundConstructor.UnderlyingConstructor);
			}
		}

		

		public BoundConstructorDefinition BuildConstructor(InfrastructureModelMask_I model, BoundTypeDefinition_I input, ConstructorInfo constructor)
		{
			

			
			return new BoundConstructorDefinition
			{
				DeclaringType = input,
				ConstructorAttributes = constructor.Attributes,
				Name = constructor.Name,
				UnderlyingConstructor = constructor
			};
			

			
		}
	}
}
