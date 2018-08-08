using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{
	public class InitializationApi<TContainer> : ConversionApiNode<TContainer>, InitializationApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void ProcessInputs(ILConversion conversion)
		{
			if (conversion.Input.TypesToConvert != null && conversion.Input.TypesToConvert.Length > 0)
			{
				// If we have types to convert, they need to exist a bound model needs to exist for them first.  By using types,
				// there is no way to get them out of memory unless they are already collectible.  The appraoch that is going to be used
				// is to make a list of assemblies that each of the types belongs to, load those assemblies into the structural type system,
				// ready the assemblies, and load the types referenced.  Then for each type referene that is created, 

				for (int i = 0; i < conversion.Input.TypesToConvert.Length; i++)
				{
					//ProcessInput(conversion, conversion.Input.TypesToConvert[i]);
				}
			}
		}

		/// <summary>
		/// Converts the type input into a structural type node that can be used by the internal,
		/// formal, conversion process.
		/// </summary>
		/// <param name="conversion">The current active conversion.</param>
		/// <param name="type">The type that needs to be converted.</param>
		/// <notes>
		/// The goal of this method is to convert the System.Type node to a conversional type node that is 
		/// associated with a structural type node.   The structural type node will contain a type reference, 
		/// cecil or otherwise, that can be processed into a converted type.  I need a type reference for 
		/// this type so I can process it as part of the conversion.  To get the assembly, I just look at the
		/// type's assembly attribute.  Therefore I need an assembly of the type, so I can get the assembly definition
		/// </notes>
		public void ProcessInput(ILConversion conversion, System.Type type)
		{
			// Should at a minimum load the assembly and the modules within the assembly.
			//var conversionAssemblyNode = Conversion.Metadata.Assemblies.EnsureNode(conversion, type.Assembly);

			//var convertedModuleNode = Conversion.Metadata.Modules.Ensure(conversion, conversionAssemblyNode, type.Module.ModuleVersionId);

			//// Get the conversion node for this conversion.  
			//var conversionTypeNode = Conversion.Metadata.Members.Types.EnsureTypeNode(conversion, convertedModuleNode, type);

			//AddTypeNodeToConversionQueue(conversion, conversionTypeNode);

			
		}

		private void AddTypeNodeToConversionQueue(ILConversion conversion, ConversionTypeNode conversionTypeNode)
		{
			

			if (!conversion.Input.TypeNodesToConvert.TryGetValue(conversionTypeNode.Id,
				out ConversionTypeNode existingTypeNode))
			{
				conversion.Input.TypeNodesToConvert.Add(conversionTypeNode.Id, conversionTypeNode);
			}
		}
	}
}
