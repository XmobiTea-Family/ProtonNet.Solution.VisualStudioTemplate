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

            this.logger.Info("Constructor Application called");

        }

    }

}
