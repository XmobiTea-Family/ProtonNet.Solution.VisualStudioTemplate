using System;
using System.Reflection;
using XmobiTea.ProtonNet.Control.Helper;
using XmobiTea.ProtonNet.Server.Socket;

namespace __Server__.Startup
{
    class Program
    {
        private const string AssemblyName = "__Server__";
        private const string StartupSettingsFilePath = "./StartupSettings.json";

        private static void Main(string[] args)
        {
            var assembly = Assembly.Load(AssemblyName);

            var startupSettingsReader = new StartupSettingsReader();
            var socketStartupSettings = startupSettingsReader.LoadSocketStartupSettings(StartupSettingsFilePath);

            var startupSettings = GenerateStartupSettingsFrom(socketStartupSettings);
            var serverEntry = DebugSocketServerEntry.NewBuilder()
                .SetStartupSettings(startupSettings)
                .Build();

            var server = serverEntry.GetServer();
            server.Start();

            Console.ReadLine();

        }

        /// <summary>
        /// Generates Socket server startup settings from the provided configuration.
        /// </summary>
        /// <param name="socketStartupSettings">Configuration for the Socket server.</param>
        /// <returns>The generated startup settings for the Socket server.</returns>
        private static StartupSettings GenerateStartupSettingsFrom(XmobiTea.ProtonNet.Control.Helper.Models.SocketStartupSettings socketStartupSettings)
        {
            var tcpSessionConfig = SessionConfigSettings.NewBuilder()
                .SetAcceptorBacklog(socketStartupSettings.TcpServer.SessionConfig.AcceptorBacklog)
                .SetDualMode(socketStartupSettings.TcpServer.SessionConfig.DualMode)
                .SetKeepAlive(socketStartupSettings.TcpServer.SessionConfig.KeepAlive)
                .SetTcpKeepAliveTime(socketStartupSettings.TcpServer.SessionConfig.TcpKeepAliveTime)
                .SetTcpKeepAliveInterval(socketStartupSettings.TcpServer.SessionConfig.TcpKeepAliveInterval)
                .SetTcpKeepAliveRetryCount(socketStartupSettings.TcpServer.SessionConfig.TcpKeepAliveRetryCount)
                .SetNoDelay(socketStartupSettings.TcpServer.SessionConfig.NoDelay)
                .SetReuseAddress(socketStartupSettings.TcpServer.SessionConfig.ReuseAddress)
                .SetExclusiveAddressUse(socketStartupSettings.TcpServer.SessionConfig.ExclusiveAddressUse)
                .SetReceiveBufferLimit(socketStartupSettings.TcpServer.SessionConfig.ReceiveBufferLimit)
                .SetReceiveBufferCapacity(socketStartupSettings.TcpServer.SessionConfig.ReceiveBufferCapacity)
                .SetSendBufferLimit(socketStartupSettings.TcpServer.SessionConfig.SendBufferLimit)
                .SetSendBufferCapacity(socketStartupSettings.TcpServer.SessionConfig.SendBufferCapacity)
                .Build();

            var tcpSslConfig = SslConfigSettings.NewBuilder()
                .SetEnable(socketStartupSettings.TcpServer.SslConfig.Enable)
                .SetPort(socketStartupSettings.TcpServer.SslConfig.Port)
                .SetCertFilePath(socketStartupSettings.TcpServer.SslConfig.CertFilePath)
                .SetCertPassword(socketStartupSettings.TcpServer.SslConfig.CertPassword)
                .Build();

            var tcpServer = TcpServerSettings.NewBuilder()
                .SetAddress(socketStartupSettings.TcpServer.Address)
                .SetPort(socketStartupSettings.TcpServer.Port)
                .SetEnable(socketStartupSettings.TcpServer.Enable)
                .SetSessionConfig(tcpSessionConfig)
                .SetSslConfig(tcpSslConfig)
                .Build();

            var udpSessionConfig = UdpSessionConfigSettings.NewBuilder()
                .SetDualMode(socketStartupSettings.UdpServer.SessionConfig.DualMode)
                .SetReuseAddress(socketStartupSettings.UdpServer.SessionConfig.ReuseAddress)
                .SetExclusiveAddressUse(socketStartupSettings.UdpServer.SessionConfig.ExclusiveAddressUse)
                .SetReceiveBufferLimit(socketStartupSettings.UdpServer.SessionConfig.ReceiveBufferLimit)
                .SetReceiveBufferCapacity(socketStartupSettings.UdpServer.SessionConfig.ReceiveBufferCapacity)
                .SetSendBufferLimit(socketStartupSettings.UdpServer.SessionConfig.SendBufferLimit)
                .Build();

            var udpServer = UdpServerSettings.NewBuilder()
                .SetEnable(socketStartupSettings.UdpServer.Enable)
                .SetAddress(socketStartupSettings.UdpServer.Address)
                .SetPort(socketStartupSettings.UdpServer.Port)
                .SetSessionConfig(udpSessionConfig)
                .Build();

            var webSocketSessionConfig = SessionConfigSettings.NewBuilder()
                .SetAcceptorBacklog(socketStartupSettings.WebSocketServer.SessionConfig.AcceptorBacklog)
                .SetDualMode(socketStartupSettings.WebSocketServer.SessionConfig.DualMode)
                .SetKeepAlive(socketStartupSettings.WebSocketServer.SessionConfig.KeepAlive)
                .SetTcpKeepAliveTime(socketStartupSettings.WebSocketServer.SessionConfig.TcpKeepAliveTime)
                .SetTcpKeepAliveInterval(socketStartupSettings.WebSocketServer.SessionConfig.TcpKeepAliveInterval)
                .SetTcpKeepAliveRetryCount(socketStartupSettings.WebSocketServer.SessionConfig.TcpKeepAliveRetryCount)
                .SetNoDelay(socketStartupSettings.WebSocketServer.SessionConfig.NoDelay)
                .SetReuseAddress(socketStartupSettings.WebSocketServer.SessionConfig.ReuseAddress)
                .SetExclusiveAddressUse(socketStartupSettings.WebSocketServer.SessionConfig.ExclusiveAddressUse)
                .SetReceiveBufferLimit(socketStartupSettings.WebSocketServer.SessionConfig.ReceiveBufferLimit)
                .SetReceiveBufferCapacity(socketStartupSettings.WebSocketServer.SessionConfig.ReceiveBufferCapacity)
                .SetSendBufferLimit(socketStartupSettings.WebSocketServer.SessionConfig.SendBufferLimit)
                .SetSendBufferCapacity(socketStartupSettings.WebSocketServer.SessionConfig.SendBufferCapacity)
                .Build();

            var webSocketSslConfig = SslConfigSettings.NewBuilder()
                .SetEnable(socketStartupSettings.WebSocketServer.SslConfig.Enable)
                .SetPort(socketStartupSettings.WebSocketServer.SslConfig.Port)
                .SetCertFilePath(socketStartupSettings.WebSocketServer.SslConfig.CertFilePath)
                .SetCertPassword(socketStartupSettings.WebSocketServer.SslConfig.CertPassword)
                .Build();

            var webSocketServer = WebSocketServerSettings.NewBuilder()
                .SetEnable(socketStartupSettings.WebSocketServer.Enable)
                .SetAddress(socketStartupSettings.WebSocketServer.Address)
                .SetPort(socketStartupSettings.WebSocketServer.Port)
                .SetMaxFrameSize(socketStartupSettings.WebSocketServer.MaxFrameSize)
                .SetSessionConfig(webSocketSessionConfig)
                .SetSslConfig(webSocketSslConfig)
                .Build();

            var threadPoolSize = ThreadPoolSizeSettings.NewBuilder()
                .SetOtherFiber(socketStartupSettings.ThreadPoolSize.OtherFiber)
                .SetReceivedFiber(socketStartupSettings.ThreadPoolSize.ReceivedFiber)
                .Build();

            var authToken = AuthTokenSettings.NewBuilder()
                .SetPassword(socketStartupSettings.AuthToken.Password)
                .Build();

            var startupSettings = StartupSettings.NewBuilder()
                .SetName(socketStartupSettings.Name)
                .SetMaxSession(socketStartupSettings.MaxSession)
                .SetMaxPendingRequest(socketStartupSettings.MaxPendingRequest)
                .SetMaxSessionPendingRequest(socketStartupSettings.MaxSessionPendingRequest)
                .SetMaxSessionRequestPerSecond(socketStartupSettings.MaxSessionRequestPerSecond)
                .SetMaxUdpSessionRequestPerUser(socketStartupSettings.MaxUdpSessionRequestPerUser)
                .SetMaxTcpSessionRequestPerUser(socketStartupSettings.MaxTcpSessionRequestPerUser)
                .SetMaxWsSessionRequestPerUser(socketStartupSettings.MaxWsSessionRequestPerUser)
                .SetHandshakeTimeoutInSeconds(socketStartupSettings.HandshakeTimeoutInSeconds)
                .SetIdleTimeoutInSeconds(socketStartupSettings.IdleTimeoutInSeconds)
                .SetTcpServer(tcpServer)
                .SetUdpServer(udpServer)
                .SetWebSocketServer(webSocketServer)
                .SetThreadPoolSize(threadPoolSize)
                .SetAuthToken(authToken)
                .Build();

            return startupSettings;
        }

    }

}
