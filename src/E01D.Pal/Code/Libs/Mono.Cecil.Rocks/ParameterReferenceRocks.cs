
namespace Root.Code.Libs.Mono.Cecil.Rocks {

	public static class ParameterReferenceRocks {

		public static int GetSequence (this ParameterReference self)
		{
			return self.Index + 1;
		}
	}
}
