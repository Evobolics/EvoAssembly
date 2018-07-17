using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.GenericInstances
{
	public class Phase2DependencyBuildApi<TContainer> : ConversionApiNode<TContainer>, Phase2DependencyBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Build(ILConversion conversion, ConvertedGenericTypeDefinition_I convertedGeneric)
		{			
			#region Example Code Case - ClassWithGenericField<string>
				// An example of a type that does not have generics: ClassWithGenericField<string>
				//  public class ClassWithGenericField<T>
				//  {
				//	  public T GenericField;

				//	  public void Execute()
				//	  {

				//	  }
				//  }

			#endregion

			Fields.Building.Generic.BuildFields(conversion, convertedGeneric);

			//if (convertedGeneric.SourceTypeReference.FullName ==
			//	"Root.Testing.Code.Apis.E01D.Runtimic.Emitting.Conversion.TestApi`1<TContainer>")
			//{
				
			//}

			// Example : "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.GenericClassWithMethods`1<System.Object>"
			Routines.Building.BuildRoutines(conversion, convertedGeneric);



		}
	}
}
