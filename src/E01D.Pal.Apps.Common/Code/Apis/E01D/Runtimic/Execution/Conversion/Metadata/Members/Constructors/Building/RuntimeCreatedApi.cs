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

			ConstructorBuildInfo[] constructors;

			var bindingFlags = BindingFlags.Instance | BindingFlags.Static |
			            BindingFlags.Public | BindingFlags.NonPublic |
			            BindingFlags.DeclaredOnly;


			if (input.Blueprint.UnderlyingType is TypeBuilder blueprintTypeBuilder)
			{
				// The closed generic is based upon a constructed type


				// This MUST use typebuilder.GetConstructor and not
				// input.Blueprint.UnderlyingType, as different ConstructorInfo objects are returned.
				constructors = GetConstructorsFromCollection(conversion, input, input.Blueprint);
			}
			else // The closed generic is based upon a bound type
			{
				var constructorInfos = input.UnderlyingType.GetConstructors(bindingFlags);

				constructors = new ConstructorBuildInfo[constructorInfos.Length];

				for (int i = 0; i < constructorInfos.Length; i++)
				{
					MethodReference genericTypeInstanceMethodReference = Cecil.Metadata.Members.Constructors.Getting.
						FromConstructorInfos.References.GetMethodReference(conversion.Model, input.SourceTypeReference, constructorInfos[i]);

					constructors[i] = new ConstructorBuildInfo()
					{
						GenericTypeInstanceConstructorInfo = constructorInfos[i],
						GenericTypeInstanceMethodReference = genericTypeInstanceMethodReference
					};

				}
			}

			for (int i = 0; i < constructors.Length; i++)
			{
				var constructor = constructors[i];

				var consturctorEntry = BuildConstructor(conversion, input, constructor.GenericTypeInstanceConstructorInfo, constructor.GenericTypeInstanceMethodReference);

				withConstructors.Constructors.All.Add(consturctorEntry);
			}
			
		}

		private ConstructorBuildInfo[] GetConstructorsFromCollection(ILConversion conversion, ConvertedGenericTypeDefinitionMask_I input, BoundGenericTypeDefinitionMask_I inputBlueprint)
		{
			if (!(inputBlueprint is ConvertedTypeDefinitionWithConstructors_I withConstructors))
			{
				throw new System.Exception("GenericClassDefinition should have constructors if this type has constructors.");
			}

			ConstructorBuildInfo[] constructors = new ConstructorBuildInfo[withConstructors.Constructors.All.Count];

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
