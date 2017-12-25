using System.Reflection;

namespace Colliebot
{
    public class CollieConfig
    {
        public const int APIVersion = 1;
        public static string Version { get; } =
            typeof(CollieConfig).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(CollieConfig).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";
        
        public static readonly string APIUrl = "https://api.colliebot.com";
        public static readonly string Encoding = "ISO-8859-1";

        public const int DefaultRequestTimeout = 15000;

        /// <summary> Gets or sets how a request should act in the case of an error, by default. </summary>
        public RetryMode DefaultRetryMode { get; set; } = RetryMode.AlwaysRetry;

        /// <summary> Gets or sets the minimum log level severity that will be sent to the Log event. </summary>
        public CollieLogSeverity LogLevel { get; set; } = CollieLogSeverity.Info;

        /// <summary> Gets or sets whether the initial log entry should be printed. </summary>
        internal bool DisplayInitialLog { get; set; } = true;
    }
}
