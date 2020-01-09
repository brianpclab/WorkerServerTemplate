
using System.Threading;

namespace WorkerServerTemplate
{
    /// <summary>
    /// Interface for service to calculate Pi
    /// </summary>
    public interface ICalculatePiService
    {
        /// <summary>
        /// Method to calculate PI
        /// </summary>
        /// <param name="cancellationToken">To cancel calculation</param>
        /// <returns></returns>
        string CalculatePi(CancellationToken cancellationToken);
    }
}
