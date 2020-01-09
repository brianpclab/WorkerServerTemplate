using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace WorkerServerTemplate
{
	/// <summary>
	/// https://stackoverflow.com/questions/11677369/how-to-calculate-pi-to-n-number-of-places-in-c-sharp-using-loops/11679007
	/// </summary>
	class CalculatePiService : ICalculatePiService
	{
		readonly PiConfiguration _piConfiguration;
		readonly ILogger _logger;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="piConfiguration"></param>
		public CalculatePiService(ILogger<CalculatePiService> logger, PiConfiguration piConfiguration)
		{
			_logger = logger;
			_logger.LogInformation("CalculatePiService - Ctor Called");
			_piConfiguration = piConfiguration;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public string CalculatePi(CancellationToken cancellationToken)
		{
			Int32 digits = _piConfiguration.NumberOfDigits;

			_logger.LogInformation($"Calculating Pi to {digits} digits - Ctor Called");
			digits++;

			uint[] x = new uint[digits * 10 / 3 + 2];
			uint[] r = new uint[digits * 10 / 3 + 2];

			uint[] pi = new uint[digits];

			for (int j = 0; j < x.Length; j++)
				x[j] = 20;

			for (int i = 0; i < digits; i++)
			{
				uint carry = 0;
				for (int j = 0; j < x.Length; j++)
				{
					uint num = (uint)(x.Length - j - 1);
					uint dem = num * 2 + 1;

					x[j] += carry;

					uint q = x[j] / dem;
					r[j] = x[j] % dem;

					carry = q * num;
				}
				cancellationToken.ThrowIfCancellationRequested();

				pi[i] = (x[x.Length - 1] / 10);


				r[x.Length - 1] = x[x.Length - 1] % 10; 

				for (int j = 0; j < x.Length; j++)
					x[j] = r[j] * 10;
			}

			var result = "";

			uint c = 0;

			for (int i = pi.Length - 1; i >= 0; i--)
			{
				cancellationToken.ThrowIfCancellationRequested();
				pi[i] += c;
				c = pi[i] / 10;

				result = (pi[i] % 10).ToString() + result;
			}

			return result;
		}
	}
}

