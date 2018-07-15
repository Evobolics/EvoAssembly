using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Apis.E01D.Activation
{
    public class CommonAppActivationDomainApi
    {
        public T CreateInstance<T>()
        {
            return System.Activator.CreateInstance<T>();
        }

        public object CreateInstance(System.Type type)
        {
            try
            {
                return System.Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
	            try
	            {
		            var constructors = type.GetConstructors();

		            if (constructors.Length != 1) throw;

		            var constructor = constructors[0];

		            var parameters = constructor.GetParameters();

		            try
		            {
			            return constructor.Invoke(BindingFlags.OptionalParamBinding |
			                                      BindingFlags.InvokeMethod |
			                                      BindingFlags.CreateInstance,
				            null,
				            GetTypeMissingArray(parameters.Length),
				            CultureInfo.InvariantCulture);

		            }
		            catch
		            {
			            throw e;
		            }
				}
	            catch (Exception exception)
	            {
		            var assembly1 = type.Assembly;
		            var assemblyBuilder = (AssemblyBuilder) assembly1;

		            var types = assemblyBuilder.DefinedTypes.ToArray();
		            //var typeBuilder = (TypeBuilder) types[0];
		            //var x = typeBuilder.IsCreated();

					Console.WriteLine(exception);
		            throw;
	            }
                
            }
            
        }

        public object[] GetTypeMissingArray(int count)
        {
            object[] array = new object[count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Type.Missing;
            }

            return array;
        }

        public object CreateInstance(Type_I type)
        {
            if (!type.IsBound())
            {
                throw new System.Exception("Expected bound type.");
            }

            return System.Activator.CreateInstance(((BoundTypeDefinition_I)type).UnderlyingType);
        }
    }
}
