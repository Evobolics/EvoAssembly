using Root.Code.Attributes.E01D;
using Root.Code.Domains.E01D;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
    public class ValueTypeTests
    {
        [Test]
        public void CanCreateBareBonesValueType()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>();

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(SimpleValueType));
        }
    }
}
