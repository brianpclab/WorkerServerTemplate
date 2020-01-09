using System;

using System.Runtime.Serialization;


namespace WorkerServerTemplate.KubernetesProbeListener
{

	/// <summary>
	/// Custom Exception class
	/// </summary>
	[Serializable]
	public class KubernetesProbeListenerException : Exception
	{
		/// <summary>
		/// Constructs a <see cref="KubernetesProbeListenerException"/>
		/// </summary>
		public KubernetesProbeListenerException()
		{
		}
		/// <summary>
		/// Constructs a <see cref="KubernetesProbeListenerException"/>
		/// </summary>
		/// <param name="message"></param>

		public KubernetesProbeListenerException(string message)
			: base(message)
		{
		}
		/// <summary>
		/// Constructs a <see cref="KubernetesProbeListenerException"/>
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>

		public KubernetesProbeListenerException(string message, Exception inner) : base(message, inner)
		{
		}
		/// <summary>
		/// Constructs a <see cref="KubernetesProbeListenerException"/>
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected KubernetesProbeListenerException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
