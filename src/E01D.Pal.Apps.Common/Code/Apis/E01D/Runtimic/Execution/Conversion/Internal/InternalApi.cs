using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Configurational;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Domains.E01D;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{

	public class InternalApi<TContainer> : ConversionApiNode<TContainer>, InternalApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public new ConfigurationalApi_I<TContainer> Configurational { get; set; }

		ConfigurationalApiMask_I InternalApiMask_I.Configurational
		{
			get { return Configurational; }
		}

		public InitializationApi_I<TContainer> Initialization { get; set; }

		InitializationApiMask_I InternalApiMask_I.Initialization => Initialization;

		public ResultApi_I<TContainer> Results { get; set; }

		ResultApiMask_I InternalApiMask_I.Results => Results;


		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Type type)
		{
			conversion.Input.TypesToConvert = new []{type};
			conversion.Input.Options = CreateDefaultConversionOptions();

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Type type, ILConversionOptions conversionOptions)
		{
			conversion.Input.TypesToConvert = new[] { type };
			conversion.Input.Options = conversionOptions;

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Type[] types)
		{
			conversion.Input.TypesToConvert = types;
			conversion.Input.Options = CreateDefaultConversionOptions();

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Type[] types, ILConversionOptions conversionOptions)
		{


			conversion.Input.TypesToConvert = types;
			conversion.Input.Options = conversionOptions;

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, TypeReference typeReference)
		{
			conversion.Input.TypeReferencesToConvert = new []{ typeReference };
			conversion.Input.Options = CreateDefaultConversionOptions();

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, TypeReference typeReference, ILConversionOptions conversionOptions)
		{


			conversion.Input.TypeReferencesToConvert = new[] { typeReference }; ;
			conversion.Input.Options = conversionOptions;

			return Convert(conversion);
		}

		/// <summary>
		/// Converts the specified types to a collectible assembly.  All dependent types should be included.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="typeReferences"></param>
		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, TypeReference[] typeReferences)
		{
			conversion.Input.TypeReferencesToConvert = typeReferences;
			conversion.Input.Options = CreateDefaultConversionOptions();

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, TypeReference[] typeReferences, ILConversionOptions conversionOptions)
		{
			conversion.Input.TypeReferencesToConvert = typeReferences;
			conversion.Input.Options = conversionOptions;

			return Convert(conversion);
		}



		/// <summary>
		/// Converts the specified assembly to a collectible assembly. 
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assembly">The current assembly to be converted.</param>
		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Assembly assembly)
		{
			conversion.Input.AssembliesToConvert = new Assembly[] { assembly };
			conversion.Input.Options = CreateDefaultConversionOptions();

			return Convert(conversion);
		}

		/// <summary>
		/// Converts the specified assembly to a dynamic assembly.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assembly"></param>
		/// <param name="conversionOptions">The IL Conversion options to use for this conversion</param>
		/// <returns></returns>
		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Assembly assembly, ILConversionOptions conversionOptions)
		{
			conversion.Input.AssembliesToConvert = new Assembly[]{ assembly };
			conversion.Input.Options = conversionOptions;

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Assembly[] assemblies)
		{
			conversion.Input.AssembliesToConvert = assemblies;
			conversion.Input.Options = CreateDefaultConversionOptions();

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Assembly[] assemblies, ILConversionOptions conversionOptions)
		{
			conversion.Input.AssembliesToConvert = assemblies;
			conversion.Input.Options = conversionOptions;

			return Convert(conversion);
		}

		/// <summary>
		/// Converts the specified assembly to a collectible assembly. 
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assemblyDefinition">The current assembly to be converted.</param>
		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Stream stream)
		{
			conversion.Input.AssemblyStreamsToConvert = new []{ stream };
			conversion.Input.Options = CreateDefaultConversionOptions();

			return Convert(conversion);
		}



		/// <summary>
		/// Converts the specified assembly to a dynamic assembly.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assemblyDefinition"></param>
		/// <param name="conversionOptions">The IL Conversion options to use for this conversion</param>
		/// <returns></returns>
		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Stream stream, ILConversionOptions conversionOptions)
		{
			conversion.Input.AssemblyStreamsToConvert = new []{ stream };
			conversion.Input.Options = conversionOptions;

			return Convert(conversion);
		}

		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Stream[] streams)
		{
			conversion.Input.AssemblyStreamsToConvert = streams;
			conversion.Input.Options = CreateDefaultConversionOptions();

			return Convert(conversion);
		}


		[PublicApi]
		public ILConversionResult Convert(ILConversion conversion, Stream[] streams, ILConversionOptions conversionOptions)
		{
			conversion.Input.AssemblyStreamsToConvert = streams;
			conversion.Input.Options = conversionOptions;

			// Now that all inputs have been provided, proceed with the conversion.
			return Convert(conversion);
		}


		public ILConversionResult Convert(ILConversion conversion)
		{
			// Build the configuration before doing anything else, as the configuration can affect anything else that happens.
			Configurational.BuildConfiguration(conversion, conversion.Input.Options);

			// If there is no runtimic system associated with the conversion, create one.  
			if (conversion.RuntimicSystem == null)
			{
				conversion.RuntimicSystem = new RuntimicSystemModel();
			}

			// Make sure the runatmic system whether created or passed in is adequetly built out.
			Runtimic.Models.EnsureMinimumRuntimicSystem(conversion.RuntimicSystem);

			// Ensure all the types, assemblies, and assembly definitions are turned into a list of type references that need to be converted.
			Initialization.ProcessInputs(conversion);




			try
			{
				ConvertedAssemblyNode[] completeAssembliesToConvert = new ConvertedAssemblyNode[(conversion.Input.AssembliesToConvert?.Length ?? 0) +
					(conversion.Input.AssemblyStreamsToConvert?.Length ?? 0)];

				// need to make a list of all assemblies that are being converted, so if they come up in the process of being converted,
				// they are resolved.

				var assembliesToConvertLength = conversion.Input.AssembliesToConvert?.Length ?? 0;

				for (int i = 0; i < assembliesToConvertLength; i++)
				{
					// ReSharper disable once PossibleNullReferenceException
					var currentAssembly = conversion.Input.AssembliesToConvert[i];

					completeAssembliesToConvert[i] = Conversion.Metadata.Assemblies.EnsureNode(conversion, currentAssembly);
				}

				int offset = assembliesToConvertLength;

				for (int i = 0; i < conversion.Input.AssemblyStreamsToConvert?.Length; i++)
				{
					var currentAssemblyStream = conversion.Input.AssemblyStreamsToConvert[i];

					completeAssembliesToConvert[i + offset] = Conversion.Metadata.Assemblies.EnsureNode(conversion, currentAssemblyStream);
				}

				Dictionary<string, ConvertedAssemblyNode> nodes = null;

				if (conversion.Input.TypesToConvert?.Length > 0)
				{
					nodes = new Dictionary<string, ConvertedAssemblyNode>();

					for (int i = 0; i < completeAssembliesToConvert.Length; i++)
					{
						nodes.Add(completeAssembliesToConvert[i].InputFullName, completeAssembliesToConvert[i]);
					}

					for (int i = 0; i < conversion.Input.TypesToConvert.Length; i++)
					{
						var currentAssembly = conversion.Input.TypesToConvert[i].Assembly;

						if (!nodes.ContainsKey(currentAssembly.FullName))
						{
							var conversionAssemblyNode = Conversion.Metadata.Assemblies.EnsureNode(conversion, currentAssembly);

							nodes.Add(conversionAssemblyNode.InputFullName, conversionAssemblyNode);
						}
					}
				}

				
				for (int i = 0; i < completeAssembliesToConvert.Length; i++)
				{
					var currentAssemblyNode = completeAssembliesToConvert[i];

					if (currentAssemblyNode.IsEntireAssemblyConverted) continue;

					currentAssemblyNode.IsEntireAssemblyConverted = true;

					var assemblyDefinition = currentAssemblyNode.InputStructuralNode.CecilAssemblyDefinition;

					for (int j = 0; j < assemblyDefinition.Modules.Count; j++)
					{
						var currentModule = assemblyDefinition.Modules[j];

						var types = currentModule.Types;

						for (int k = 0; k< types.Count; k++)
						{
							if (types[k].MetadataToken.ToInt32() == 0x02000001)
							{
								continue;
							}

							Execution.Types.Ensuring.Ensure(new ExecutionEnsureContext()
							{
								AssemblyNode = currentAssemblyNode,
								ModuleDefinition = currentModule,
								TypeReference = types[k],
								IsConverted = true,
								Conversion = conversion,
								RuntimicSystem = conversion.RuntimicSystem
							});
						}
					}
				}

				Type[] outputTypes = null;

				if (conversion.Input.TypesToConvert != null && conversion.Input.TypesToConvert.Length > 0)
				{
					var typesToConvertLength = conversion.Input.TypesToConvert.Length;
				
					var inputList = new Dictionary<string, Type>(typesToConvertLength);

					for (var i = 0; i < conversion.Input.TypesToConvert.Length; i++)
					{
						var type = conversion.Input.TypesToConvert[i];

						DecomposeGenericInstances(nodes, inputList, type);
					}

					outputTypes = inputList.Values.ToArray();

					for (var i = 0; i < outputTypes.Length; i++)
					{
						var underlyingType = outputTypes[i];

						var executionTypeNode = Execution.Types.Ensuring.Ensure(new ExecutionEnsureContext()
						{
							UnderlyingType = underlyingType,
							IsConverted = true,
							Conversion = conversion,
							RuntimicSystem = conversion.RuntimicSystem
						});

						// ReSharper disable once PossibleNullReferenceException
						outputTypes[i] = executionTypeNode.Type.UnderlyingType;
					}
				}

				

				var assemblies = GetAssemblies(conversion.MetadataModel.Assemblies.ById.Values.ToList());

				

				if (conversion.Input.TypesToConvert != null && conversion.Input.TypesToConvert.Length > 0)
				{
					var typeDictionary = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.GetTypes(assemblies);

					for (int i = 0; i < conversion.Input.TypesToConvert.Length; i++)
					{
						try
						{
							var inputType = conversion.Input.TypesToConvert[i];

							outputTypes[i] = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.GetType(typeDictionary, inputType);
						}
						catch (Exception e)
						{
							conversion.Result.Exceptions.Add(e);

							throw;
						}
					}
				}


				CreateDesiredOutput(conversion, outputTypes, assemblies);

				return conversion.Result;
			}
			finally
			{
				CloseStreams(conversion);
			}
		}

		private void DecomposeGenericInstances(Dictionary<string, ConvertedAssemblyNode> nodes, Dictionary<string, Type> outputList, Type type)
		{
			if (type.IsGenericType && !type.IsGenericTypeDefinition)
			{
				DecomposeGenericInstances(nodes, outputList, type.GetGenericTypeDefinition());

				var arguments = type.GenericTypeArguments;

				for (int i = 0; i < arguments.Length; i++)
				{
					DecomposeGenericInstances(nodes, outputList, arguments[i]);
				}
			}
			else
			{
				if (nodes.ContainsKey(type.Assembly.FullName) && !outputList.ContainsKey(type.AssemblyQualifiedName))
				{

					outputList.Add(type.AssemblyQualifiedName, type);
				}
			}
		}

		private void EnsureInputsAreInTypeSystem(ILConversion conversion)
		{
			

			

			//// Load the assembly definition associated with the assembly into the model.
			//var set = Cecil.Assemblies.Ensuring.Ensure(conversion.Model, assemblies);

			//// Load all the types in the provide assemblies, and 
			//var set = Cecil.Assemblies.Ensuring.Ensure(conversion.Model, assemblyDefinitions);

			//conversion.Input.AssemblyDefinitionsToConvert = assemblies;



			//// Load all the types in the provide assemblies, and 
			//conversion.Input.TypeReferencesToConvert = nodesToConvert;

			//// The conversion process.  The conversion process needs to know what assemblies are slated for conversion and which ones are not.  
			//for (int i = 0; i < assemblies.Count; i++)
			//{
			//	assemblies[i].IsConverted = true;
			//}
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

		private Assembly[] GetAssemblies(List<ConvertedAssemblyNode> inputAssemlyNodesToConvert)
		{
			Assembly[] assemblies = new Assembly[inputAssemlyNodesToConvert.Count];

			for (int i = 0; i < inputAssemlyNodesToConvert.Count; i++)
			{
				var node = inputAssemlyNodesToConvert[i];

				var convetedAssembly = node.ConvertedAssembly;

				assemblies[i] = convetedAssembly.AssemblyBuilder;
			}

			return assemblies;
		}


		private void CloseStreams(ILConversion conversion)
		{
            

			if (conversion.RuntimicSystem.Io.OpenStreams != null)
			{
				for (int i = 0; i < conversion.RuntimicSystem.Io.OpenStreams.Count; i++)
				{
					var stream = conversion.RuntimicSystem.Io.OpenStreams[i];

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
