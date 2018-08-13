using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Exts.Runtimic
{
	public static class RuntimicContainerExts
	{
		public static ILConversionResult Convert(this RuntimicContainer container, System.Type type)
		{
			return container.Api.Runtimic.Execution.Conversion.Convert(type);
		}

		public static ILConversionResult Convert(this RuntimicContainer container, System.Type type, AssemblyBuilderAccess access)
		{
			return container.Api.Runtimic.Execution.Conversion.Convert(type, new ILConversionOptions()
			{
				BuilderAccess = access
			});
		}

		public static ILConversionResult Convert(this RuntimicContainer container, System.Type type, ILConversionOptions conversionOptions)
		{
			return container.Api.Runtimic.Execution.Conversion.Convert(type, conversionOptions);
		}

		public static System.Reflection.Assembly Convert(this RuntimicContainer container, System.Reflection.Assembly assembly)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly);
		}

		public static System.Reflection.Assembly Convert(this RuntimicContainer container, System.Reflection.Assembly assembly, AssemblyBuilderAccess access)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly, access);
		}

		public static System.Reflection.Assembly Convert(this RuntimicContainer container, System.Reflection.Assembly assembly, ILConversionOptions conversionOptions)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly, conversionOptions);
		}

		public static Type QuickConvert(this RuntimicContainer container, Type type)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(type);
		}

		public static Type QuickConvert(this RuntimicContainer container, Type type, out ILConversionResult result)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(type, out result);
		}

		public static Type[] QuickConvert(this RuntimicContainer container, Type[] types)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(types);
		}


		public static Type[] QuickConvert(this RuntimicContainer container, Type[] types, out ILConversionResult result)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(types, out result);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public static Assembly QuickConvert(this RuntimicContainer container, Assembly assembly)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly);
		}


		/// <summary>
		/// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static Assembly QuickConvert(this RuntimicContainer container, Assembly assembly,
			out ILConversionResult result)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly, out result);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public static Assembly[] QuickConvert(this RuntimicContainer container, Assembly[] assemblies)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assemblies);
		}


		/// <summary>
		/// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static Assembly[] QuickConvert(this RuntimicContainer container, Assembly[] assemblies,
			out ILConversionResult result)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assemblies, out result);
		}
	}
}
