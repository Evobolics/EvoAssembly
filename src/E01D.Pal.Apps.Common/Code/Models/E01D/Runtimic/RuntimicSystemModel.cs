namespace Root.Code.Models.E01D.Runtimic
{
	public class RuntimicSystemModel
	{
		/// <summary>
		/// Gets or sets the type systems associated with the runtimic system model.
		/// </summary>
		public RuntimicTypeSystemModel TypeSystems { get; set; }

		public RuntimicIdentificationModel Identification { get; set; }

		public RuntimicIoModel Io { get; set; }
		
	}
}
