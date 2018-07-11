using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedLabel
    {
        public int Offset { get; set; }
        public Label Label { get; set; }

		public Label[] Labels { get; set; }
    }
}
