

namespace WorkerServerTemplate.Services
{
    static class Validation
    {
        public static void Validate(this PiConfiguration configuration)
        {
            if (configuration.NumberOfDigits <= 0)
            {
                throw new CalculatePiServiceException($"The NumberOfDigits value in appsettings section {PiConfiguration.SECTIONNAME} is not a positive integer.");
            }

            if (configuration.NumberOfDigits > 50000)
            {
                throw new CalculatePiServiceException($"The number of digits value in section {PiConfiguration.SECTIONNAME} must not be greater than 50000.");
            }
        }
    }
}
