using Microsoft.Extensions.Logging;

namespace code_challenge.Tests.Fakes.Logging
{
    class FakeLoggerFactory
    {
        public ILogger<T> CreateLogger<T>()
        {
            return new FakeLogger<T>();
        }
    }
}
