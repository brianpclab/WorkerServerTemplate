

namespace WorkerServerTemplate.KubernetesProbeListener
{
    class ProbePorts
    {
        public const string SECTIONNAME = "ProbePortsSection";

        public int ReadinessProbePort{ get; set; }
        public int LivenessProbePort { get; set; }
    }
}
