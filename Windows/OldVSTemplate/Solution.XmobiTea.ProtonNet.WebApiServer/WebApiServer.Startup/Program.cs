using $safeprojectname$.Utils;
using System;
using System.Reflection;
using XmobiTea.Logging;
using XmobiTea.ProtonNet.Control.Helper;
using XmobiTea.ProtonNet.Server.WebApi;

namespace $safeprojectname$
{
    class Program
    {
        private const string AssemblyName = "$ext_safeprojectname$";
        private const string StartupSettingsFilePath = "./StartupSettings.json";

        private static void Main(string[] args)
        {
            var assembly = Assembly.Load(AssemblyName);

            var startupSettingsReader = new StartupSettingsReader();
            var webApiStartupSettings = startupSettingsReader.LoadWebApiStartupSettings(StartupSettingsFilePath);

            var startupSettings = GenerateStartupSettingsFrom(webApiStartupSettings);
            var serverEntry = DebugWebApiServerEntry.NewBuilder()
                .SetStartupSettings(startupSettings)
                .Build();

            var server = serverEntry.GetServer();
            server.Start();

            LogManager.GetLogger<Program>().Info($"open browser at link http://127.0.0.1:{startupSettings.HttpServer.Port}");
            BrowserSupport.Open($"http://127.0.0.1:{startupSettings.HttpServer.Port}");

            Console.ReadLine();

        }

        /// <summary>
        /// Generates Web API server startup settings from the provided configuration.
        /// </summary>
        /// <param name="webApiStartupSettings">Configuration for the Web API server.</param>
        /// <returns>The generated startup settings for the Web API server.</returns>
        private static StartupSettings GenerateStartupSettingsFrom(XmobiTea.ProtonNet.Control.Helper.Models.WebApiStartupSettings webApiStartupSettings)
        {
            var sessionConfig = SessionConfigSettings.NewBuilder()
                .SetAcceptorBacklog(webApiStartupSettings.HttpServer.SessionConfig.AcceptorBacklog)
                .SetDualMode(webApiStartupSettings.HttpServer.SessionConfig.DualMode)
                .SetKeepAlive(webApiStartupSettings.HttpServer.SessionConfig.KeepAlive)
                .SetTcpKeepAliveTime(webApiStartupSettings.HttpServer.SessionConfig.TcpKeepAliveTime)
                .SetTcpKeepAliveInterval(webApiStartupSettings.HttpServer.SessionConfig.TcpKeepAliveInterval)
                .SetTcpKeepAliveRetryCount(webApiStartupSettings.HttpServer.SessionConfig.TcpKeepAliveRetryCount)
                .SetNoDelay(webApiStartupSettings.HttpServer.SessionConfig.NoDelay)
                .SetReuseAddress(webApiStartupSettings.HttpServer.SessionConfig.ReuseAddress)
                .SetExclusiveAddressUse(webApiStartupSettings.HttpServer.SessionConfig.ExclusiveAddressUse)
                .SetReceiveBufferLimit(webApiStartupSettings.HttpServer.SessionConfig.ReceiveBufferLimit)
                .SetReceiveBufferCapacity(webApiStartupSettings.HttpServer.SessionConfig.ReceiveBufferCapacity)
                .SetSendBufferLimit(webApiStartupSettings.HttpServer.SessionConfig.SendBufferLimit)
                .SetSendBufferCapacity(webApiStartupSettings.HttpServer.SessionConfig.SendBufferCapacity)
                .Build();

            var sslConfig = SslConfigSettings.NewBuilder()
                .SetEnable(webApiStartupSettings.HttpServer.SslConfig.Enable)
                .SetPort(webApiStartupSettings.HttpServer.SslConfig.Port)
                .SetCertFilePath(webApiStartupSettings.HttpServer.SslConfig.CertFilePath)
                .SetCertPassword(webApiStartupSettings.HttpServer.SslConfig.CertPassword)
                .Build();

            var httpServer = HttpServerSettings.NewBuilder()
                .SetAddress(webApiStartupSettings.HttpServer.Address)
                .SetPort(webApiStartupSettings.HttpServer.Port)
                .SetEnable(webApiStartupSettings.HttpServer.Enable)
                .SetSessionConfig(sessionConfig)
                .SetSslConfig(sslConfig)
                .Build();

            var threadPoolSize = ThreadPoolSizeSettings.NewBuilder()
                .SetOtherFiber(webApiStartupSettings.ThreadPoolSize.OtherFiber)
                .SetReceivedFiber(webApiStartupSettings.ThreadPoolSize.ReceivedFiber)
                .Build();

            var authToken = AuthTokenSettings.NewBuilder()
                .SetPassword(webApiStartupSettings.AuthToken.Password)
                .Build();

            var startupSettings = StartupSettings.NewBuilder()
                .SetName(webApiStartupSettings.Name)
                .SetMaxPendingRequest(webApiStartupSettings.MaxPendingRequest)
                .SetMaxSessionPendingRequest(webApiStartupSettings.MaxSessionPendingRequest)
                .SetMaxSessionRequestPerSecond(webApiStartupSettings.MaxSessionRequestPerSecond)
                .SetHttpServer(httpServer)
                .SetThreadPoolSize(threadPoolSize)
                .SetAuthToken(authToken)
                .Build();

            return startupSettings;
        }

    }

}
