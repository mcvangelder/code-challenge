using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace code_challenge.Tests.Fakes.Logging
{
    class FakeLogger<T> : ILogger<T>
    {
        private class MockDisposable : IDisposable
        {
            public void Dispose()
            {
                
            }
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new MockDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
        }
    }
}
