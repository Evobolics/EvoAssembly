using System;
using System.IO;
using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Configurational;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{
	public interface InternalApiMask_I
	{
		ConfigurationalApiMask_I Configurational { get; }

		InitializationApiMask_I Initialization { get; }

		ResultApiMask_I Results { get; }

		ILConversionResult Convert(ILConversion conversion, Assembly assembly);

		ILConversionResult Convert(ILConversion conversion, Assembly assembly, ILConversionOptions conversionOptions);

		ILConversionResult Convert(ILConversion conversion, Assembly[] assembly);

		ILConversionResult Convert(ILConversion conversion, System.Type type);

		ILConversionResult Convert(ILConversion conversion, System.Type type, ILConversionOptions conversionOptions);

		ILConversionResult Convert(ILConversion conversion, System.Type[] type);

		ILConversionResult Convert(ILConversion conversion, Type[] type, ILConversionOptions conversionOptions);

		ILConversionResult Convert(ILConversion conversion, TypeReference typeDefinition);

		ILConversionResult Convert(ILConversion conversion, TypeReference[] typeReferences);

		ILConversionResult Convert(ILConversion conversion, Stream assemblies);

		ILConversionResult Convert(ILConversion conversion, Stream[] assemblies);

		ILConversionOptions CreateDefaultConversionOptions();
	}
}
