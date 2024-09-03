using System;
using System.Reflection;
using XmobiTea.ProtonNet.Server.Socket;

namespace $safeprojectname$
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly.Load("$ext_safeprojectname$");

            var tcpSessionConfig = SessionConfigSettings.NewBuilder()
                .SetAcceptorBacklog(1024)
                .SetDualMode(false)
                .SetKeepAlive(true)
                .SetTcpKeepAliveInterval(0)
                .SetTcpKeepAliveRetryCount(0)
                .SetTcpKeepAliveTime(5)
                .SetNoDelay(true)
                .SetReuseAddress(false)
                .SetExclusiveAddressUse(false)
                .SetReceiveBufferLimit(0)
                .SetReceiveBufferCapacity(8192)
                .SetSendBufferLimit(0)
                .SetSendBufferCapacity(8192)
                .Build();

            var webSocketSessionConfig = SessionConfigSettings.NewBuilder()
                .SetAcceptorBacklog(1024)
                .SetDualMode(false)
                .SetKeepAlive(true)
                .SetTcpKeepAliveInterval(0)
                .SetTcpKeepAliveRetryCount(0)
                .SetTcpKeepAliveTime(5)
                .SetNoDelay(true)
                .SetReuseAddress(false)
                .SetExclusiveAddressUse(false)
                .SetReceiveBufferLimit(0)
                .SetReceiveBufferCapacity(8192)
                .SetSendBufferLimit(0)
                .SetSendBufferCapacity(8192)
                .Build();

            var udpSessionConfig = UdpSessionConfigSettings.NewBuilder()
                .SetDualMode(false)
                .SetReuseAddress(false)
                .SetExclusiveAddressUse(false)
                .SetReceiveBufferLimit(0)
                .SetReceiveBufferCapacity(8192)
                .SetSendBufferLimit(0)
                .Build();

            var sslConfig = SslConfigSettings.NewBuilder()
                .SetEnable(false)
                .SetPort(22203)
                .SetCerFilePath(string.Empty)
                .SetCerPassword(null)
                .Build();

            var tcpServer = TcpServerSettings.NewBuilder()
                .SetAddress("0.0.0.0")
                .SetPort(32202)
                .SetEnable(true)
                .SetSessionConfig(tcpSessionConfig)
                .SetSslConfig(sslConfig)
                .Build();

            var udpServer = UdpServerSettings.NewBuilder()
                .SetAddress("0.0.0.0")
                .SetPort(42202)
                .SetEnable(true)
                .SetSessionConfig(udpSessionConfig)
                .Build();

            var wsSslConfig = SslConfigSettings.NewBuilder()
                .SetEnable(false)
                .SetPort(52203)
                .SetCerFilePath(string.Empty)
                .SetCerPassword(null)
                .Build();

            var webSocketServer = WebSocketServerSettings.NewBuilder()
                .SetAddress("0.0.0.0")
                .SetEnable(true)
                .SetPort(52202)
                .SetMaxFrameSize(8192)
                .SetSessionConfig(webSocketSessionConfig)
                .SetSslConfig(wsSslConfig)
                .Build();

            var threadPoolSize = ThreadPoolSizeSettings.NewBuilder()
                .SetOtherFiber(2)
                .SetReceivedFiber(12)
                .Build();

            var startupSettings = StartupSettings.NewBuilder()
                .SetName("XmobiTea.SocketServer")
                .SetMaxSession(10000)
                .SetMaxPendingRequest(10000)
                .SetMaxSessionPendingRequest(100)
                .SetMaxSessionRequestPerSecond(50)
                .SetMaxUdpSessionRequestPerUser(1)
                .SetMaxTcpSessionRequestPerUser(1)
                .SetMaxWsSessionRequestPerUser(1)
                .SetHandshakeTimeoutInSeconds(30)
                .SetIdleTimeoutInSeconds(60)
                .SetTcpServer(tcpServer)
                .SetUdpServer(udpServer)
                .SetWebSocketServer(webSocketServer)
                .SetThreadPoolSize(threadPoolSize)
                .Build();

            var serverEntry = DebugSocketServerEntry.NewBuilder()
                .SetStartupSettings(startupSettings)
                .Build();

            var server = serverEntry.GetServer();
            server.Start();

            Console.ReadLine();

        }

    }

}
