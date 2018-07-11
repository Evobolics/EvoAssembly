namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ClassWithPrimitiveTypeMethods
	{
		public bool Execute()
		{
			bool result = true;


			result &= Sbyte() == -1;
			result &= Short() == -1;
			result &= Int32() == -1;
			result &= Int64() == -1;
			result &= Byte() == 1;
			result &= UShort() == 1;
			result &= UInt32() == 1;
			result &= UInt64() == 1;
			result &= Bool() ;
			result &= Decimal() == decimal.MaxValue;
			result &= Float() == float.MaxValue;
			result &= Double() == double.MaxValue;
			result &= String() == "Howdy";
			result &= Char() == 'a';


			return result;
		}

		public char Char()
		{
			return 'a';
		}

		public string String()
		{
			return "Howdy";
		}

		public decimal Decimal()
		{
			return decimal.MaxValue;
		}

		public float Float()
		{
			return float.MaxValue;
		}

		public double Double()
		{
			return double.MaxValue;
		}

		public bool Bool()
		{
			return true;
		}

		public sbyte Sbyte()
		{
			return -1;
		}

		public short Short()
		{
			return -1;
		}

		public int Int32()
		{
			return -1;
		}

		public long Int64()
		{
			return -1;
		}

		public byte Byte()
		{
			return 1;
		}

		public ushort UShort()
		{
			return 1;
		}

		public uint UInt32()
		{
			return 1;
		}

		public ulong UInt64()
		{
			return 1;
		}
	}
}
