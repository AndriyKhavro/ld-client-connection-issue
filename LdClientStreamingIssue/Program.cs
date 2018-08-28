using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Common.Logging;
using Common.Logging.Simple;
using LaunchDarkly.Client;

namespace LdClientStreamingIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            string sdkKey = args[0];
            string userKey = args[1];
            var user = new User(userKey);
            LogManager.Adapter = new DebugLoggerFactoryAdapter();
            var ldClient = new LdClient(sdkKey);

            while (true)
            {
                Console.WriteLine($"Current features: {string.Join(", ", ldClient.AllFlags(user).Select(pair => $"{pair.Key}: {pair.Value}"))}");
                Thread.Sleep(10000);
            }
        }
    }
}
