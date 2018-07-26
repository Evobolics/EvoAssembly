using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Domains.E01D;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{

	public class InternalApi<TContainer> : ConversionApiNode<TContainer>, InternalApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

		public ResultApi_I<TContainer> Results { get; set; }

		ResultApiMask_I InternalApiMask_I.Results => Results;


		public ILConversionResult Convert(ILConversion conversion, Type type)
		{
			return Convert(conversion, type, CreateDefaultConversionOptions());
		}

		public ILConversionResult Convert(ILConversion conversion, Type type, ILConversionOptions conversionOptions)
		{
			var typeDefinition = Cecil.Types.Ensuring.EnsureReference(conversion.Model, type);

			return Convert(conversion, typeDefinition, conversionOptions);
		}

		public ILConversionResult Convert(ILConversion conversion, Type[] types)
		{
			return Convert(conversion, types, CreateDefaultConversionOptions());
		}

		public ILConversionResult Convert(ILConversion conversion, Type[] types, ILConversionOptions conversionOptions)
		{
			var typeSet = Cecil.Types.Ensuring.EnsureReferences(conversion.Model, types);

			return Convert(conversion, typeSet.Assemblies, conversionOptions, typeSet.Types); // Make work
		}

		public ILConversionResult Convert(ILConversion conversion, TypeReference typeReference)
		{
			return Convert(conversion, typeReference, CreateDefaultConversionOptions());
		}

		public ILConversionResult Convert(ILConversion conversion, TypeReference typeReference, ILConversionOptions conversionOptions)
		{
			var typeReferences = new List<TypeReference> {typeReference};

			return Convert(conversion, typeReferences, conversionOptions);
		}

		/// <summary>
		/// Converts the specified types to a collectible assembly.  All dependent types should be included.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="typeReferences"></param>
		public ILConversionResult Convert(ILConversion conversion, List<TypeReference> typeReferences)
		{
			return Convert(conversion, typeReferences, CreateDefaultConversionOptions());
		}

		public ILConversionResult Convert(ILConversion conversion, List<TypeReference> typeReferences, ILConversionOptions conversionOptions)
		{
			var typeSet = Cecil.Types.Ensuring.EnsureReferences(conversion.Model, typeReferences);

			return Convert(conversion, typeSet.Assemblies, conversionOptions, typeSet.Types);
		}

		

		/// <summary>
		/// Converts the specified assembly to a collectible assembly. 
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assembly">The current assembly to be converted.</param>
		public ILConversionResult Convert(ILConversion conversion, Assembly assembly)
		{
			// Convert the assembly using the default AssemblyBuilderAccess.RunAndCollect.
			return Convert(conversion, assembly, CreateDefaultConversionOptions());
		}

		/// <summary>
		/// Converts the specified assembly to a dynamic assembly.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assembly"></param>
		/// <param name="conversionOptions">The IL Conversion options to use for this conversion</param>
		/// <returns></returns>
		public ILConversionResult Convert(ILConversion conversion, Assembly assembly, ILConversionOptions conversionOptions)
		{
			var result = Convert(conversion, new []{ assembly }, conversionOptions);

			return result;
		}

		public ILConversionResult Convert(ILConversion conversion, Assembly[] assemblies)
		{
			return Convert(conversion, assemblies, CreateDefaultConversionOptions());
		}

		public ILConversionResult Convert(ILConversion conversion, Assembly[] assemblies, ILConversionOptions conversionOptions)
		{
			// Load the assembly definition associated with the assembly into the model.
			var set = Cecil.Assemblies.Ensuring.Ensure(conversion.Model, assemblies);

			return Convert(conversion, set.Assemblies, conversionOptions, set.Types);
		}

		/// <summary>
		/// Converts the specified assembly to a collectible assembly. 
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assemblyDefinition">The current assembly to be converted.</param>
		public ILConversionResult Convert(ILConversion conversion, AssemblyDefinition assemblyDefinition)
		{
			// Convert the assembly using the default AssemblyBuilderAccess.RunAndCollect.
			return Convert(conversion, assemblyDefinition, CreateDefaultConversionOptions());
		}



		/// <summary>
		/// Converts the specified assembly to a dynamic assembly.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assemblyDefinition"></param>
		/// <param name="conversionOptions">The IL Conversion options to use for this conversion</param>
		/// <returns></returns>
		public ILConversionResult Convert(ILConversion conversion, AssemblyDefinition assemblyDefinition, ILConversionOptions conversionOptions)
		{
			return Convert(conversion, new[] { assemblyDefinition}, conversionOptions);
		}

		public ILConversionResult Convert(ILConversion conversion, AssemblyDefinition[] assemblyDefinitions)
		{
			// Convert the assembly using the default AssemblyBuilderAccess.RunAndCollect.
			return Convert(conversion, assemblyDefinitions, CreateDefaultConversionOptions());
		}

		

		public ILConversionResult Convert(ILConversion conversion, AssemblyDefinition[] assemblyDefinitions, ILConversionOptions conversionOptions)
		{
			// Load all the types in the provide assemblies, and 
			var set = Cecil.Assemblies.Ensuring.Ensure(conversion.Model, assemblyDefinitions);

			// Now that all inputs have been provided, proceed with the conversion.
			return Convert(conversion, set.Assemblies, conversionOptions, set.Types);
		}

		public ILConversionResult Convert(ILConversion conversion, 
			List<UnifiedAssemblyNode> assemblies, 
			ILConversionOptions options, 
			List<UnifiedTypeNode> nodesToConvert)
		{
			conversion.Configuration.BuilderAccess = options.BuilderAccess;
			conversion.Configuration.UseILGenerator = options.UseILGenerator;

			conversion.Input.AssemlyNodesToConvert = assemblies;

			for (int i = 0; i < assemblies.Count; i++)
			{
				assemblies[i].IsConverted = true;
			}

			// Load all the types in the provide assemblies, and 
			conversion.Input.NodesToConvert = nodesToConvert;

			// Now that all inputs have been provided, proceed with the conversion.
			return Convert(conversion);
		}

		public ILConversionResult Convert(ILConversion conversion)
		{
			try
			{
				Conversion.Metadata.Assemblies.Building.Build(conversion);

				conversion.ReferencedAssemblies = Cecil.Assemblies.Ensuring.EnsureAssemblyReferences(conversion.Model, conversion.Input.AssemlyNodesToConvert);

				var referencedList = conversion.ReferencedAssemblies.Values.ToList();

				Bound.Metadata.Assemblies.Building.Build(conversion.Model, referencedList);

				var inputTypes = conversion.Input.NodesToConvert;

				Type[] convertedList = null;

				if (conversion.Input.Kind == InputOutputKind.Types)
				{
					convertedList = new Type[inputTypes.Count];
				}

				for (int i = 0; i < inputTypes.Count; i++)
				{
					var inputType = inputTypes[i];

					ConvertedTypeDefinitionMask_I converted;

					if (inputType.SourceTypeReference.Name == "<Module>")
					{
						converted = null;
					}
					else
					{
						var semanticType = Execution.Types.Ensuring.Ensure(conversion.Model, inputType.SourceTypeReference, null, null);

						converted = (ConvertedTypeDefinitionMask_I)semanticType;

						
					}

					if (convertedList != null)
					{
						convertedList[i] = converted?.UnderlyingType;
					}
				}

				Type[] outputList = null;



				if (convertedList != null)
				{
					outputList = new Type[convertedList.Length];

					for (int i = 0; i < inputTypes.Count; i++)
					{
						var converted = convertedList[i];

						try
						{
							outputList[i] = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.GetTypeInAssembly(converted.Assembly, converted);
						}
						catch (Exception e)
						{
							conversion.Result.Exceptions.Add(e);

							throw;
						}
					}
				}

				var assemblies = GetAssemblies(conversion.Input.AssemlyNodesToConvert);

				CreateDesiredOutput(conversion, outputList, assemblies);

				

				return conversion.Result;
			}
			finally
			{
				CloseStreams(conversion);
			}
		}

		

		private void CreateDesiredOutput(ILConversion conversion, Type[] convertedList, Assembly[] assemblies)
		{
			switch (conversion.Input.Kind)
			{
				case InputOutputKind.Unknown:
				{
					throw new Exception("Input output kind unknown not a supported input.");
				}
				case InputOutputKind.Types:
				{
					conversion.Result.Output = new ILConversionTypesOutput()
					{
						Assemblies = assemblies,
						Types = convertedList,
						
					};

					break;
				}
				case InputOutputKind.AssemblyDefinitions:
				case InputOutputKind.Assemblies:
				{
					conversion.Result.Output = new ILConversionAssembliesOutput()
					{
						Assemblies = assemblies
					};

					break;
				}
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private Assembly[] GetAssemblies(List<UnifiedAssemblyNode> inputAssemlyNodesToConvert)
		{
			Assembly[] assemblies = new Assembly[inputAssemlyNodesToConvert.Count];

			for (int i = 0; i < inputAssemlyNodesToConvert.Count; i++)
			{
				var node = inputAssemlyNodesToConvert[i];

				var convetedAssembly = (ConvertedAssembly_I)node.Semantic;

				assemblies[i] = convetedAssembly.AssemblyBuilder;
			}

			return assemblies;
		}


		private void CloseStreams(ILConversion conversion)
		{
			if (conversion?.Model?.Structural.Streams != null)
			{
				for (int i = 0; i < conversion.Model.Structural.Streams.Count; i++)
				{
					var stream = conversion.Model.Structural.Streams[i];

					try
					{
						stream.Dispose();
					}
					catch
					{
						// ignore
					}
				}
			}
		}

		public ILConversionOptions CreateDefaultConversionOptions()
		{
			return new ILConversionOptions()
			{
				BuilderAccess = AssemblyBuilderAccess.RunAndCollect
			};
		}

	}
}
