using Root.Code.Attributes.E01D;
using Root.Code.Domains.E01D;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion
{
    public class ILConversionApiTests
    {
        public void CheckTypes()
        {
            
        }

        [Test]
        public void ConvertType()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>();

            // Convert the type. The test api code will check to make sure the type is not null.
            var result = test.Api.ConvertSingleType(typeof(SimpleClass));

            
        }
    }
}
