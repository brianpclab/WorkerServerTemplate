using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace WorkerServerTemplate.KubernetesProbeListener
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
		public static IServiceCollection AddKubernetesProbeListener(this IServiceCollection services, IConfiguration configuration)
		{
			IConfigurationSection configurationSection = configuration.GetSection(ProbePorts.SECTIONNAME);
			ProbePorts settings = configurationSection.Get<ProbePorts>();
			if (settings is null)
			{
				throw new KubernetesProbeListenerException($"Configuration section named {ProbePorts.SECTIONNAME} could not be serialized into type {typeof(PiConfiguration)}.  Please check the spelling of the configuration section name.");
			}
			services.AddSingleton(resolver => settings);
			services.AddSingleton<IKubernetesProbeListener,KubernetesProbeListenerService>();

			return services;

		}
	}
}
