using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface LoadingApiMask_I
	{
		AssemblyDefinition LoadAssemblyDefinition(ILConversion conversion, Assembly assembly);
		List<AssemblyDefinition> LoadAssemblyDefinitions(ILConversion conversion, Assembly[] assemblies);
	}
}
