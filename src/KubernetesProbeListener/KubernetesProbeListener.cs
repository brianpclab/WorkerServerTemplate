

using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;

namespace WorkerServerTemplate.KubernetesProbeListener
{
    class KubernetesProbeListenerService : IKubernetesProbeListener
    {
        readonly ILogger _logger;
        readonly ProbePorts _probePorts;

        CancellationTokenSource _cancellationTokenSource;
        Task _readinessTask = null;
        Task _livenessTask = null;
        TcpListener _server = null;
        public KubernetesProbeListenerService(ILogger<KubernetesProbeListenerService> logger, ProbePorts probePorts)
        {
            _logger = logger;
            _probePorts = probePorts;
        }
        public void StartProbeListener(CancellationToken cancellationToken)
        {
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _readinessTask = Task.Run(() => InternalStartProbeListener(_probePorts.ReadinessProbePort, "ReadynessProbe"));
            if (_probePorts.ReadinessProbePort != _probePorts.LivenessProbePort)
            {
                _livenessTask = Task.Run(() => InternalStartProbeListener(_probePorts.LivenessProbePort, "LivenessProbe"));
            }

        }
        public void StopProbeListener()
        {            
            _cancellationTokenSource.Cancel();
        }
        void InternalStartProbeListener(Int32 port,String probeType)
        {
            try
            {
                _logger.LogInformation($"Starting TcpListener on localhost:{port} probeType {probeType}");
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                _server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                _server.Start();
                // Enter the listening loop.
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    //blocks waiting on connection to this port
                    TcpClient client = _server.AcceptTcpClient();
                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                _logger.LogError(e, $"Exception occurred while accepting TCP connections for port {port} probeType {probeType}");
            }
            finally
            {
                // Stop listening for new clients.
                _server.Stop();
            }
        }
    }
}
