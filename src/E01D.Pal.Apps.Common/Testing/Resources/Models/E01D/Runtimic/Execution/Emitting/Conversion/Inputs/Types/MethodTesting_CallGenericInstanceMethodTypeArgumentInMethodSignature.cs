using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_CallGenericInstanceMethodTypeArgumentInMethodSignature<TContainer>
	{
		public void Execute()
		{
			TestField(default(TContainer), "FieldName", new object());
		}

		public void TestField<T>(TContainer result, string fieldName, T howdy)
		{

		}
	}
}
