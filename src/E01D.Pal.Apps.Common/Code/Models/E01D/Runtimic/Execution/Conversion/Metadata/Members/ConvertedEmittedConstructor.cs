﻿using System.Reflection;
using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedEmittedConstructor: ConvertedConstructor
	{
		public ConvertedEmittedConstructor()
		{
				
		}

        public ConstructorBuilder ConstructorBuilder { get; set; }

        public bool IsInstanceConstructor { get; set; }

        

        protected override ConstructorInfo Get_UnderlyingConstructor() => ConstructorBuilder;

        public override MemberInfo UnderlyingMember => ConstructorBuilder;
	    
	}
}
