using System;

using System.Runtime.Serialization;


namespace WorkerServerTemplate
{

	/// <summary>
	/// Custom Exception class
	/// </summary>
	[Serializable]
	public class CalculatePiServiceException : Exception
	{
		/// <summary>
		/// Constructs a <see cref="CalculatePiServiceException"/>
		/// </summary>
		public CalculatePiServiceException()
		{
		}
		/// <summary>
		/// Constructs a <see cref="CalculatePiServiceException"/>
		/// </summary>
		/// <param name="message"></param>

		public CalculatePiServiceException(string message)
			: base(message)
		{
		}
		/// <summary>
		/// Constructs a <see cref="CalculatePiServiceException"/>
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>

		public CalculatePiServiceException(string message, Exception inner) : base(message, inner)
		{
		}
		/// <summary>
		/// Constructs a <see cref="CalculatePiServiceException"/>
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CalculatePiServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
