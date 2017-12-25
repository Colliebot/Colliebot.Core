using System;
using System.Threading.Tasks;

namespace Colliebot
{
    internal class LogManager
    {
        public CollieLogSeverity Level { get; }
        private Logger _logger { get; }

        public event Func<LogMessage, Task> Message { add { _messageEvent.Add(value); } remove { _messageEvent.Remove(value); } }
        private readonly AsyncEvent<Func<LogMessage, Task>> _messageEvent = new AsyncEvent<Func<LogMessage, Task>>();

        public LogManager(CollieLogSeverity minSeverity)
        {
            Level = minSeverity;
            _logger = new Logger(this, "Github");
        }

        public async Task LogAsync(CollieLogSeverity severity, string source, Exception ex)
        {
            try
            {
                if (severity <= Level)
                    await _messageEvent.InvokeAsync(new LogMessage(severity, source, null, ex)).ConfigureAwait(false);
            }
            catch { }
        }
        public async Task LogAsync(CollieLogSeverity severity, string source, string message, Exception ex = null)
        {
            try
            {
                if (severity <= Level)
                    await _messageEvent.InvokeAsync(new LogMessage(severity, source, message, ex)).ConfigureAwait(false);
            }
            catch { }
        }

        public Task ErrorAsync(string source, Exception ex)
            => LogAsync(CollieLogSeverity.Error, source, ex);
        public Task ErrorAsync(string source, string message, Exception ex = null)
            => LogAsync(CollieLogSeverity.Error, source, message, ex);

        public Task WarningAsync(string source, Exception ex)
            => LogAsync(CollieLogSeverity.Warning, source, ex);
        public Task WarningAsync(string source, string message, Exception ex = null)
            => LogAsync(CollieLogSeverity.Warning, source, message, ex);

        public Task InfoAsync(string source, Exception ex)
            => LogAsync(CollieLogSeverity.Info, source, ex);
        public Task InfoAsync(string source, string message, Exception ex = null)
            => LogAsync(CollieLogSeverity.Info, source, message, ex);

        public Task VerboseAsync(string source, Exception ex)
            => LogAsync(CollieLogSeverity.Verbose, source, ex);
        public Task VerboseAsync(string source, string message, Exception ex = null)
            => LogAsync(CollieLogSeverity.Verbose, source, message, ex);

        public Task DebugAsync(string source, Exception ex)
            => LogAsync(CollieLogSeverity.Debug, source, ex);
        public Task DebugAsync(string source, string message, Exception ex = null)
            => LogAsync(CollieLogSeverity.Debug, source, message, ex);

        public Logger CreateLogger(string name) => new Logger(this, name);

        public async Task WriteInitialLog()
        {
            await _logger.InfoAsync($"Colliebot {_logger.Name} v{CollieConfig.Version} (API v{CollieConfig.APIVersion})").ConfigureAwait(false);
        }
    }
}
