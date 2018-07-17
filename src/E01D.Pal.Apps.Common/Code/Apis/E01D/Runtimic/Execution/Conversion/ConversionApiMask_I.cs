using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion
{
    public interface ConversionApiMask_I
    {
	    InternalApiMask_I Internal { get; }

		MetadataApiMask_I Metadata { get; }

        ModelApiMask_I Models { get; }

	    ILConversionResult Convert(Type type);

	    ILConversionResult Convert(Type type, AssemblyBuilderAccess builder);

		Type QuickConvert(Type type);

	    Type QuickConvert(Type type, out ILConversionResult result);

	    Type[] QuickConvert(Type[] types);


	    Type[] QuickConvert(Type[] types, out ILConversionResult result);

	    
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="assembly"></param>
	    /// <returns></returns>
	    Assembly QuickConvert(Assembly assembly);

	    
	    /// <summary>
	    /// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
	    /// </summary>
	    /// <param name="assembly"></param>
	    /// <param name="result"></param>
	    /// <returns></returns>
	    Assembly QuickConvert(Assembly assembly, out ILConversionResult result);

	    
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="assembly"></param>
	    /// <returns></returns>
	    Assembly[] QuickConvert(Assembly[] assemblies);

	    
	    /// <summary>
	    /// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
	    /// </summary>
	    /// <param name="assembly"></param>
	    /// <param name="result"></param>
	    /// <returns></returns>
	    Assembly[] QuickConvert(Assembly[] assemblies, out ILConversionResult result);



    }
}
