using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types
{
	public class TypeApi<TContainer> : ExecutionApiNode<TContainer>, TypeApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {

		public EnsuringApi_I<TContainer> Ensuring { get; set; }


	    EnsuringApiMask_I TypeApiMask_I.Ensuring
	    {
		    get { return Ensuring; }
	    } 


		public bool IsConverted(RuntimicSystemModel boundModel, TypeReference typeReference)
		{
			if (typeReference.IsGenericParameter) // If you do not have this, you will get generic instance types 
												  // that are thought to be bound because their generic type definition
												  // is from a bound assembly, but they are really not becuase their 
												  // generic parameters are from a converted type.  The result is that
												  // the system will try to get a constructor using normal methods
												  // and will not find one to be fetched.
			{
				GenericParameter parameter = (GenericParameter)typeReference;

				// Is it a generic parameter from a open generic type?
				if (parameter.Type == GenericParameterType.Type)
				{
					return IsConverted(boundModel, parameter.DeclaringType);
				}
				else
				{
					return IsConverted(boundModel, parameter.DeclaringMethod.DeclaringType);
				}
				
				
				//if (parameter.DeclaringMethod.FullName ==
				//	"System.Collections.Generic.List`1<TOutput> ConvertAll(System.Converter`2<T,TOutput>)")
				//{

				//}

				//var declaredMethodDefinition = Cecil.Metadata.Members.Methods.ResolveReferenceToNonSignatureDefinition(boundModel, parameter.DeclaringMethod);

				//return IsConverted(boundModel, declaredMethodDefinition.DeclaringType);
			}

			string assemlbyName = Cecil.Metadata.Assemblies.Naming.GetAssemblyName(typeReference);

			var assemblyNode = Unified.Assemblies.Get(boundModel, assemlbyName);

			

			if (assemblyNode.IsConverted) return true;

			if (typeReference.IsGenericInstance) // The generic instance needs to be a converted one, if it has a parameter that is converted.
			{
				var instanceType = (GenericInstanceType) typeReference;

				for (int i = 0; i < instanceType.GenericArguments.Count; i++)
				{
					if (IsConverted(boundModel, instanceType.GenericArguments[i])) return true;
				}
			}

			return false;

			
		}

	    public bool ContainsGenericMethodParameters(RuntimicSystemModel boundModel, GenericInstanceType genericInstance)
	    {
		    throw new System.NotImplementedException();
	    }

	    public int GetToken(BoundTypeDefinitionMask_I boundType)
	    {
		    throw new System.NotImplementedException();
	    }
    }
}
