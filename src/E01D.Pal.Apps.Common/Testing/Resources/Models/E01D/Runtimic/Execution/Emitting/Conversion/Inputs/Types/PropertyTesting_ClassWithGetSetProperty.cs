namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class PropertyTesting_ClassWithGetSetProperty
	{
		public object Execute()
		{
			var message = Message;

			if (message == "Hi")
			{
				Message = "Howdy";

				return Message;
			}

			return message;
		}

		public string Message { get; set; } = "Hi";
	}
}
