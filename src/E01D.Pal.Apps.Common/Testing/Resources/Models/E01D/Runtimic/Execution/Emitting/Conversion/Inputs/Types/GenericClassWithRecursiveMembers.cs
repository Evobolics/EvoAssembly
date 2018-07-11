namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class GenericClassWithRecursiveMembers<T>
	{
		public void Execute()
		{
			var x = default(T);

			Get(x, x, x);

			Get(x, x);

			Get<T>(x, x, x);

			Get<T, T>(x, x);
		}
		

		public GenericClassWithGenericField<T> Get(T a, T b, T c)
		{
			
			return new GenericClassWithGenericField<T>()
			{
				GenericField = a
			};
		}

		public GenericClassWithRecursiveMembers<T> Get(T a, T b)
		{
			
			return new GenericClassWithRecursiveMembers<T>()
			{

			};
		}

		public GenericClassWithGenericField<T> Get<S>(T a, T b, T c)
		{
			return new GenericClassWithGenericField<T>()
			{
				GenericField = a
			};
		}

		public GenericClassWithRecursiveMembers<T> Get<S0, S1>(T a, T b)
		{
			return new GenericClassWithRecursiveMembers<T>()
			{

			};
		}
	}
}
