using System;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using WorkerServerTemplate.KubernetesProbeListener;

namespace WorkerServerTemplate
{
    public class Worker : BackgroundService
    {

        readonly ILogger<Worker> _logger;
        readonly ICalculatePiService _calculatePiService;
        readonly IKubernetesProbeListener _tcpListenerService;
        public Worker(ILogger<Worker> logger, IKubernetesProbeListener tcpListenerService, ICalculatePiService calculatePiService)
        {
            _logger = logger;
            _tcpListenerService = tcpListenerService;
            _calculatePiService = calculatePiService;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Worker.{nameof(StartAsync)}");
            _tcpListenerService.StartProbeListener(cancellationToken);
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            String result = _calculatePiService.CalculatePi(stoppingToken);
            _logger.LogInformation($"Calculation of Pi complete {result}");
            await Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _tcpListenerService.StopProbeListener();
            return base.StopAsync(cancellationToken);
        }
    }
}
