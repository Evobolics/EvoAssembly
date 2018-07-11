namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class GenericClassWithMembersThatTakeInGenericClassParameters<T>
    {
        public T Field1;

        public GenericClassWithMembersThatTakeInGenericClassParameters<T> Field2;

        public SimpleGenericClass<T> Field3;

        public GenericWithGenericMembersRecurisve<T> Field4;

        public GenericClassWithMembersThatTakeInGenericClassParameters()
        {
            int i = 0;
            i++;
        }

        public GenericClassWithMembersThatTakeInGenericClassParameters(int i)
        {
            int j = i + 1;
            j++;
        }

        public T Property { get; set; }

        public T Method(T parameter)
        {
            T howdy = parameter;

            if (howdy == null)
            {
                return default(T);
            }

            return howdy;
        }

        public T SetAndGetProperty(T parameter)
        {
            Property = parameter;

            parameter = Property;

            return parameter;
        }


    }
}
