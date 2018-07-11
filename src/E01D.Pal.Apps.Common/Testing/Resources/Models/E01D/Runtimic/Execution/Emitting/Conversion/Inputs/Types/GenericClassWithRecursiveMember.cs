namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class GenericClassWithRecursiveMember<T>
	{
		public void Execute()
		{
			//var a = default(T);
			//var b = string.Empty;
			//var c = default(T);
			//Get(a, b, c);
			Get(default(T), string.Empty, default(T));
		}

		public GenericClassWithGenericFields<string, T> Get(T a, string b, T c)
		{
			return new GenericClassWithGenericFields<string, T>()
			{
				Field1 = b,
				Field2 = a
			};
		}


	}
}
