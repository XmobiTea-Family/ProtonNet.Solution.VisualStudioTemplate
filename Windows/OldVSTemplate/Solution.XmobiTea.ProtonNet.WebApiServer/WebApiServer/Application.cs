using XmobiTea.Bean.Attributes;
using XmobiTea.Logging;

namespace $safeprojectname$
{
    /// <summary>
    /// Make Application class is singleton 
    /// </summary>
    [Singleton]
    class Application
    {
        private ILogger logger { get; }

        public Application()
        {
            this.logger = LogManager.GetLogger(this);

            this.logger.Info("Application created successfully.");
            this.logger.Info("open browser at link http://127.0.0.1:22202/helloworld/hello");

        }

    }

}
