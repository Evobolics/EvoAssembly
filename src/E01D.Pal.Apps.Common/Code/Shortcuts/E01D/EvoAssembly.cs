using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Domains.E01D;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Shortcuts.E01D
{
	public static class EvoAssembly
	{
		public static RuntimicContainer CreateContainer()
		{
			return XCommonAppPal.Api.Containment.CreateContainer<RuntimicContainer>(false);
		}

		public static ILConversionResult Convert(System.Type type)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.Convert(type);
		}

		public static ILConversionResult Convert( System.Type type, AssemblyBuilderAccess access)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.Convert(type, access);
		}

		public static System.Reflection.Assembly Convert( System.Reflection.Assembly assembly)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly);
		}

		public static Type QuickConvert( Type type)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(type);
		}

		public static Type QuickConvert( Type type, out ILConversionResult result)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(type, out result);
		}

		public static Type[] QuickConvert( Type[] types)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(types);
		}


		public static Type[] QuickConvert( Type[] types, out ILConversionResult result)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(types, out result);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public static Assembly QuickConvert( Assembly assembly)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly);
		}


		/// <summary>
		/// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static Assembly QuickConvert( Assembly assembly,
			out ILConversionResult result)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly, out result);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public static Assembly[] QuickConvert( Assembly[] assemblies)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assemblies);
		}


		/// <summary>
		/// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static Assembly[] QuickConvert( Assembly[] assemblies,
			out ILConversionResult result)
		{
			var container = CreateContainer();

			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assemblies, out result);
		}
	}
}
