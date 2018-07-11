using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class EventTesting_BasicEvent
	{
		
		private string _Message;

		public event EventHandler MessageSet;

		private string _Result;

		public object Execute()
		{
			MessageSet += EventTesting_BasicEvent_MessageSet;

			Message = "Howdy";

			return _Result;
		}

		private void EventTesting_BasicEvent_MessageSet(object sender, EventArgs e)
		{
			_Result = this.Message;
		}

		public string Message
		{
			get { return _Message; }
			set
			{
				_Message = value;

				MessageSet?.Invoke(this, EventArgs.Empty);
			}
		}
	}
}
