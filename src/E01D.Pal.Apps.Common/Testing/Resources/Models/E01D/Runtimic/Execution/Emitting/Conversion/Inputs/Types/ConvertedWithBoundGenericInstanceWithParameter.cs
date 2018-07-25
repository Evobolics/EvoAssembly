using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ConvertedWithBoundGenericInstanceWithParameter<T>
	{
		public Dictionary<string, T> GetDictionary()
		{
			return null;
		}

		//public Dictionary<string, T1> GetDictionary<T1>()
		//{
		//	return null;
		//}

		public object Execute<T1>()
		{
			// The issue is not creating the type, the issue is creating the methods.   What I am asking for 
			// is a list of runtime methods that has open type parameters.  
			return new Dictionary<string, T1>();
		}
	}
}
