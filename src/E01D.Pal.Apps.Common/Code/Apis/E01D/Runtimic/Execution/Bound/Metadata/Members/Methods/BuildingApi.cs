using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public class BuildingApi<TContainer> : BoundApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {



	    public void BuildMethods(RuntimicSystemModel model, BoundTypeDefinition_I input)
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

			    var boundMethod = BuildMethod(model, input, method, null);

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



			    // Search the specified declaring type for a method that has the provided metadata token.
			    boundMethod.MethodReference = Cecil.Metadata.Members.Methods.Getting.GetMethodReference(model,
				    declaringTypeDefinition.Methods,
				    boundMethod.UnderlyingMethod.DeclaringType,
				    boundMethod.UnderlyingMethod.MetadataToken);

			    if (boundMethod.MethodReference?.FullName == "System.Boolean TryGetValue(System.Int32,System.Collections.Generic.List`1&)")
			    {

			    }
			}
	    }



	    public BoundMethod BuildMethod(RuntimicSystemModel model, BoundTypeDefinition_I input, MethodInfo method, MethodReference methodReference)
	    {
		    BoundMethod boundMethod;

		    if (method.GetGenericArguments().Length > 0)
		    {
			    boundMethod = new BoundGenericInstanceMethod
			    {
				    DeclaringType = input,
				    MethodAttributes = method.Attributes,
				    Name = method.Name,
				    UnderlyingMethod = method,
				    MethodReference = methodReference,
				};
		    }
		    else
		    {
			    


				boundMethod = new BoundNonGenericInstanceMethod
			    {
				    DeclaringType = input,
				    MethodAttributes = method.Attributes,
				    Name = method.Name,
				    UnderlyingMethod = method,
				    MethodReference = methodReference,
				};
		    }

		    return boundMethod;
	    }

	    public void BuildMethodsForGenericInstance(RuntimicSystemModel model, BoundGenericTypeDefinition_I input)
	    {
		    if (!(input is BoundTypeDefinitionWithMethodsMask_I convertedTypeWithMethods))
		    {
			    return;
		    }

		    if (input.UnderlyingType.IsGenericTypeDefinition)
		    {
			    throw new System.Exception("You cannot get a method that is part of a generic type definition.  Using this method info will cause a method invocation exception. ");
			    
		    }

		    var blueprintMethods =  Methods.Getting.GetMethods(input.Blueprint);

		    for (int i = 0; i < blueprintMethods.Count; i++)
		    {
			    var blueprintMethod = blueprintMethods[i];

			    var blueprintUnderlyingMethodInfo = blueprintMethod.UnderlyingMethod;

			    // This MUST use typebuilder.GetMethod and not
			    // input.Blueprint.UnderlyingType, as different MethodInfo objects are returned.
			    var genericInstanceMethodInfo = TypeBuilder.GetMethod(input.UnderlyingType, blueprintUnderlyingMethodInfo);

			    var methodDefinition = (MethodDefinition)blueprintMethod.MethodReference;

			    var methodReference = Cecil.Methods.Building.MethodDefinitions.
				    MakeGenericInstanceTypeMethodReference(model, (GenericInstanceType)input.SourceTypeReference, methodDefinition);

			    var methodEntry = BuildMethod(model, input, genericInstanceMethodInfo, methodReference);

			    AddMethodToBound(convertedTypeWithMethods, methodEntry);
		    }
	    }

	    private void AddMethodToBound(BoundTypeDefinitionWithMethodsMask_I convertedTypeWithMethods, BoundMethod methodEntry)
	    {
		    if (!convertedTypeWithMethods.Methods.ByName.TryGetValue(methodEntry.Name, out List<SemanticMethodMask_I> methodList))
		    {
			    methodList = new List<SemanticMethodMask_I>();

			    convertedTypeWithMethods.Methods.ByName.Add(methodEntry.Name, methodList);
		    }

		    methodList.Add(methodEntry);
	    }


	    ///// <summary>
	    ///// The goal here is to get the method definition that corresponds to the method
	    ///// </summary>
	    ///// <param name="conversion"></param>
	    ///// <param name="declaringType"></param>
	    ///// <param name="declaringTypeReference"></param>
	    ///// <param name="declaringTypeDefinition"></param>
	    ///// <param name="method"></param>
	    //private ConvertedMethod BuildMethod(ILConversion conversion, BoundGenericTypeDefinition_I declaringType, MethodInfo method, MethodReference methodReference)
	    //{
		   // ConvertedMethod methodEntry;

		   // var genericArguments = method.GetGenericArguments();

		   // // ReSharper disable once ConstantConditionalAccessQualifier - IT CAN BE NULL.
		   // if (genericArguments?.Length > 0)
		   // {
			  //  methodEntry = new ConvertedGenericMethod
			  //  {
				 //   MethodReference = methodReference,
				 //   DeclaringType = declaringType,
				 //   Conversion = conversion,
				 //   MethodAttributes = method.Attributes,
				 //   Name = method.Name,
				 //   UnderlyingMethod = method
			  //  };
		   // }
		   // else
		   // {
			  //  methodEntry = new ConvertedBoundMethod
			  //  {
				 //   MethodReference = methodReference,
				 //   DeclaringType = declaringType,
				 //   Conversion = conversion,
				 //   MethodAttributes = method.Attributes,
				 //   Name = method.Name,
				 //   UnderlyingMethod = method
			  //  };
		   // }

		   // return methodEntry;

	    //}

















	}
}
