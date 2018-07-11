using System;

namespace Root.Code.Attributes.E01D
{
	[AttributeUsage(AttributeTargets.Method| AttributeTargets.Class, AllowMultiple = true)]
	public class TaskAttribute:System.Attribute
    {
        public TaskAttribute(string description)
        {
            Description = description;
        }

	    public TaskAttribute(string id, string description)
	    {
		    Description = description;
	    }

		public string Description { get; set; }
    }
}
