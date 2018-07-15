using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface QueryApiMask_I
	{
		bool IsCorlib(IMetadataScope scope);

		bool IsCorlib(string name);



		bool IsConverted(ILConversion conversion, IMetadataScope scope);

		bool IsConverted(ILConversion conversion, string name);
	}
}
