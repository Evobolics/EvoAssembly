using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Configurational
{
	public class ConfigurationalApi<TContainer> : ConversionApiNode<TContainer>, ConfigurationalApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void BuildConfiguration(ILConversion conversion, ILConversionOptions options)
		{
			if (conversion.Configuration == null)
			{
				conversion.Configuration = new ILConversionConfiguration();
			}

			conversion.Configuration.BuilderAccess = options.BuilderAccess;

			conversion.Configuration.UseILGenerator = options.UseILGenerator;
		}
	}
}
