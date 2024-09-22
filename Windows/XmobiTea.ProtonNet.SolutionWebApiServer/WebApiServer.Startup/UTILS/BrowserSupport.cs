using System.Diagnostics;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// Provides functionality to open a web browser and navigate to a specified URL.
    /// </summary>
    class BrowserSupport
    {
        /// <summary>
        /// Opens the default web browser and navigates to the specified URL.
        /// </summary>
        /// <param name="link">The URL to open in the web browser.</param>
        public static void Open(string link)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = link,
                UseShellExecute = true
            });
        }

    }

}
