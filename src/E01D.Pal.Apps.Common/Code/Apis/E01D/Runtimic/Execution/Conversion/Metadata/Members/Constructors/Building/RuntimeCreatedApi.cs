using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building
{
	public class RuntimeCreatedApi<TContainer> : ConversionApiNode<TContainer>, RuntimeCreatedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void BuildConstructors(ILConversion conversion, ConvertedArrayTypeDefinitionMask_I input)
		{
			//ModuleBuilder a;
			//var xyz1 = input.Module.ModuleBuilder.GetArrayMethod(input.UnderlyingType, ".ctor", CallingConventions.Standard, input.UnderlyingType, new Type[2] { typeof(int), typeof(int) });
			//var xyz2 = input.Module.ModuleBuilder.GetArrayMethod(input.UnderlyingType, ".ctor", CallingConventions.Standard, typeof(void), new Type[2] { typeof(int), typeof(int) });
			//if (!(input is ConvertedTypeDefinitionWithConstructors_I withConstructors))
			//{
			//	return;
			//}

			//var y = input.UnderlyingType;
			//var z = (Type)input.UnderlyingType;

			//try
			//{
			//	var x1 = y.GetConstructors();
			//}
			//catch (Exception e)
			//{
				
			//}

			//try
			//{
			//	var x2 = z.GetConstructors();
			//}
			//catch (Exception e)
			//{

			//}
		}

		public void BuildConstructors(ILConversion conversion, ConvertedGenericTypeDefinitionMask_I input)
		{

			if (!(input is ConvertedTypeDefinitionWithConstructors_I withConstructors))
			{
				return;
			}

			ConstructorBuildInfo[] constructors = GetConstructorsFromCollection(conversion, input, input.Blueprint);

			for (int i = 0; i < constructors.Length; i++)
			{
				var constructor = constructors[i];

				var consturctorEntry = BuildConstructor(conversion, input, constructor.GenericTypeInstanceConstructorInfo, constructor.GenericTypeInstanceMethodReference);

				withConstructors.Constructors.All.Add(consturctorEntry);
			}
			
		}

		private ConstructorBuildInfo[] GetConstructorsFromCollection(ILConversion conversion, ConvertedGenericTypeDefinitionMask_I input, BoundGenericTypeDefinitionMask_I inputBlueprint)
		{
			if (!(inputBlueprint is BoundTypeDefinitionWithConstructorsMask_I withConstructors))
			{
				throw new System.Exception($"The generic type definition should have constructors if the instance has constructors.  Could not cast the " +
				                           $"argument {nameof(inputBlueprint)} to {typeof(BoundTypeDefinitionWithConstructorsMask_I)}.");
			}

			var constructors = new ConstructorBuildInfo[withConstructors.Constructors.All.Count];

			for (int i = 0; i < withConstructors.Constructors.All.Count; i++)
			{
				var semantic = withConstructors.Constructors.All[i];

				if (!(semantic is BoundConstructorDefinitionMask_I bound))
				{
					throw new System.Exception("Semantic constructor should be a bound constructor to use it in conversion.");
				}
				
				var newTypeCreated = input.UnderlyingType;

				var genericTypeInstanceConstructorInfo = TypeBuilder.GetConstructor(newTypeCreated, bound.UnderlyingConstructor);
				

				constructors[i] = new ConstructorBuildInfo()
				{
					GenericTypeInstanceConstructorInfo = genericTypeInstanceConstructorInfo,
					GenericTypeDefinitionConstructorInfo = bound.UnderlyingConstructor,
					GenericTypeDefinitionBoundConstructor = bound,
					GenericTypeInstanceMethodReference = Cecil.Metadata.Members.Methods.Building.MethodDefinitions.MakeGenericInstanceTypeMethodReference(conversion.Model, 
					(GenericInstanceType)input.SourceTypeReference, (MethodDefinition)bound.MethodReference)
				};
			}

			return constructors;
		}

		public ConvertedGenericInstanceConstructor BuildConstructor(ILConversion conversion, ConvertedGenericTypeDefinitionMask_I input, ConstructorInfo constructorInfo, MethodReference methodReference)
		{
			var constructor = new ConvertedGenericInstanceConstructor()
			{
				MethodReference = methodReference,
				IsInstanceConstructor = true,
				UnderlyingConstructor = constructorInfo
			};

			return constructor;
		}
	}
}
