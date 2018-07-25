using System.Collections.Generic;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Constructors
{
    public class BuildingApi<TContainer> : BoundApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {



	    public void BuildConstructors(InfrastructureRuntimicModelMask_I model, BoundTypeDefinition_I input)
	    {
		    if (!(input is BoundTypeDefinitionWithConstructorsMask_I boundTypeWithConstructors))
		    {
			    return;
		    }

		    if (input.FullName == "System.Collections.Generic.Dictionary`2+ValueCollection+Enumerator")
		    {

		    }

		    // Done on purpose to find errors
		    var constructors = input.UnderlyingType.GetConstructors(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

		    List<BoundConstructorDefinition> boundConstructors = new List<BoundConstructorDefinition>(constructors.Length);

		    for (int i = 0; i < constructors.Length; i++)
		    {
			    var constructor = constructors[i];

			    var boundConstructor = new BoundConstructorDefinition
			    {
				    DeclaringType = input,
				    ConstructorAttributes = constructor.Attributes,
				    Name = constructor.Name,
				    UnderlyingConstructor = constructor
			    };

			    boundTypeWithConstructors.Constructors.All.Add(boundConstructor);

			    boundConstructors.Add(boundConstructor);

			    
				    input?.Module?.ConstructorsByMetadataToken.Add(constructor.MetadataToken, boundConstructor);
			    
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
			    boundConstructor.MethodReference = Cecil.Metadata.Members.Methods.Getting.GetMethodReference(model, declaringTypeDefinition.Methods, boundConstructor.UnderlyingConstructor.DeclaringType, boundConstructor.UnderlyingConstructor.MetadataToken);
		    }
	    }

















	}
}
