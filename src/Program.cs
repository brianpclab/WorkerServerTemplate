
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerServerTemplate.KubernetesProbeListener;

//https://docs.microsoft.com/en-us/azure/azure-monitor/app/worker-service

namespace WorkerServerTemplate
{
    /// <summary>
    /// 
    /// </summary>
    static class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static async Task Main(string[] args)
        {
            // prevents Hangs due to #1363
            var host = CreateHostBuilder(args).Build();
            using (var newHost = host.Services.GetService<IHost>())
            {
                await newHost.StartAsync();
                await newHost.StopAsync();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddKubernetesProbeListener(hostContext.Configuration);
                    ////services.AddApplicationInsightsTelemetryWorkerService();
                    services.AddHostedService<Worker>();
                    services.AddCalculatePiServices(hostContext.Configuration);
                });
    }
}
