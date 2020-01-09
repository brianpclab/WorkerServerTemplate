using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace WorkerServerTemplate
{
	/// <summary>
	/// Extension class to add services into the <see cref="IServiceCollection"/>
	/// </summary>
	public static class Extensions
	{

		/// <summary>
		/// Extension method to add services into the <see cref="IServiceCollection"/>
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddCalculatePiServices(this IServiceCollection services, IConfiguration configuration)
		{
			IConfigurationSection configurationSection = configuration.GetSection(PiConfiguration.SECTIONNAME);
			PiConfiguration settings = configurationSection.Get<PiConfiguration>();
			if (settings is null)
			{
				throw new CalculatePiServiceException($"Configuration section named {PiConfiguration.SECTIONNAME} could not be serialized into type {typeof(PiConfiguration)}.  Please check the spelling of the configuration section name.");
			}
			services.AddSingleton(resolver => settings);
			services.AddTransient<ICalculatePiService, CalculatePiService>();

			return services;

		}
	}
}
