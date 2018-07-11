namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	/// <summary>
	/// Used to verify that generic fields can be read and written; used to verify that the insturctions to read them and write them are working.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ClassWithGenericFieldAndMethodReference<T>
	{
		public T GenericField;

		public void Execute()
		{
			//IL_0001: ldarg.0
			//IL_0002: ldarg.0
			//IL_0003: ldfld !0 class Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.ClassWithGenericFieldAndMethodReference`1<!T>::GenericField
			//IL_0008: stfld !0 class Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.ClassWithGenericFieldAndMethodReference`1<!T>::GenericField
#pragma warning disable 1717
			GenericField = GenericField;
#pragma warning restore 1717
		}
	}
}
