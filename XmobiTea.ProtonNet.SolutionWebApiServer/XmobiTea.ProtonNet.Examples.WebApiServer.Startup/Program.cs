using System;
using System.Reflection;
using $safeprojectname$.Utils;
using XmobiTea.ProtonNet.Server.WebApi;

namespace $safeprojectname$
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly.Load("$ext_safeprojectname$");

            var sessionConfig = SessionConfigSettings.NewBuilder()
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

            var sslConfig = SslConfigSettings.NewBuilder()
                .SetEnable(false)
                .SetPort(22203)
                .SetCerFilePath(string.Empty)
                .SetCerPassword(null)
                .Build();

            var httpServer = HttpServerSettings.NewBuilder()
                .SetAddress("0.0.0.0")
                .SetPort(22202)
                .SetEnable(true)
                .SetSessionConfig(sessionConfig)
                .SetSslConfig(sslConfig)
                .Build();

            var threadPoolSize = ThreadPoolSizeSettings.NewBuilder()
                .SetOtherFiber(2)
                .SetReceivedFiber(12)
                .Build();

            var startupSettings = StartupSettings.NewBuilder()
                .SetName("XmobiTea.WebApiServer")
                .SetMaxPendingRequest(10000)
                .SetMaxSessionPendingRequest(100)
                .SetMaxSessionRequestPerSecond(50)
                .SetHttpServer(httpServer)
                .SetThreadPoolSize(threadPoolSize)
                .Build();

            var serverEntry = DebugWebApiServerEntry.NewBuilder()
                .SetStartupSettings(startupSettings)
                .Build();

            var server = serverEntry.GetServer();
            server.Start();

            BrowserSupport.Open($"http://127.0.0.1:{httpServer.Port}/helloworld/hello");

            Console.ReadLine();

        }
    }

}
