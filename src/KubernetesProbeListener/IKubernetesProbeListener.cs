
using System.Threading;

namespace WorkerServerTemplate.KubernetesProbeListener
{
    public interface IKubernetesProbeListener
    {
        void StartProbeListener(CancellationToken cancellationToken);
        void StopProbeListener();
    }
}
