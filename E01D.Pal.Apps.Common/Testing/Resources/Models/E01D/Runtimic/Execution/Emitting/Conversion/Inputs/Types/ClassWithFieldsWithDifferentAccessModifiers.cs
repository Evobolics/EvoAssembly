namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ClassWithFieldsWithDifferentAccessModifiers
	{
		public string Public;

		internal string Internal;

		protected string Protected;

		// ReSharper disable once InconsistentNaming
		private string Private;

		public object Execute()
		{
			Public = "Howdy";

			Internal = Public;

			Protected = Internal;

			Private = Protected;

			Public = Private;

			return Public;
		}
	}
}
