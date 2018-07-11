namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ClassWithDifferentKindsOfFields
	{
		public string Public;

		internal string Internal;

		protected string Protected;

		// ReSharper disable once InconsistentNaming
		private string Private;

		public static string StaticPublic;

		internal static string StaticInternal;

		protected static string StaticProtected;

		// ReSharper disable once InconsistentNaming
		private static string StaticPrivate;

		private static string Initialized = "Howdy";

		public object Execute()
		{
			Public = Initialized;

			Internal = Public;

			Protected = Internal;

			Private = Protected;

			StaticPublic = Private;

			StaticInternal = StaticPublic;

			StaticProtected = StaticInternal;

			StaticPrivate = StaticProtected;

			

			return StaticPrivate;
		}
	}
}
