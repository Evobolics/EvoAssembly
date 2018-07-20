using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_CallGenericInstanceMethod<TContainer>
	{
		public void Execute()
		{
			TestField(null, "FieldName", new object());
		}

		public void TestField<T>(object result, string fieldName, T howdy)
		{
			
		}
	}
}
