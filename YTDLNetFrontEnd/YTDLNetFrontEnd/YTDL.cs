using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace com.captainalm.YTDLNetFrontEnd
{
    static class YTDL
    {
        private static string[] pathLocs = Environment.GetEnvironmentVariable("PATH").Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        public static Process executeApplication(string target)
        {
            var packageName = "";
            switch (getInstalled())
            {
                case ApplicationType.YoutubeDL:
                    packageName = "youtube_dl";
                    break;
                case ApplicationType.YT_DLP:
                    packageName = "yt_dlp";
                    break;
                default:
                    return null;
            }
            var pyProSet = new ProcessStartInfo(findExecutableInPath("python"), "-m " + packageName + " --hls-prefer-native " +
                ((getInstalled() == ApplicationType.YT_DLP) ? "-N 16 " : "") + "\"" + target + "\"")
                { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true, StandardOutputEncoding = Encoding.UTF8, StandardErrorEncoding = Encoding.UTF8 };
            return Process.Start(pyProSet);
        }

        public static string executeInstall(ApplicationType package, bool update)
        {
            var packageName = "";
            switch (package)
            {
                case ApplicationType.YoutubeDL:
                    packageName = "youtube-dl";
                    break;
                case ApplicationType.YT_DLP:
                    packageName = "yt-dlp";
                    break;
                default:
                    return "Invalid Package Name";
            }
            var pipProSet = new ProcessStartInfo(findExecutableInPath("python"), "-m pip install " + packageName + ((update) ? " --upgrade" : ""))
            { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true, StandardOutputEncoding = Encoding.UTF8, StandardErrorEncoding = Encoding.UTF8 };
            using (var pipPro = Process.Start(pipProSet))
            {
                var rpote = new ReadProcessOutputToEnd(pipPro);
                pipPro.WaitForExit();
                if (!rpote.getError().Equals("")) return rpote.getError();
                return rpote.getOutput();
            }
        }

        private static ApplicationType installed;
        public static ApplicationType getInstalled()
        {
            if (installed == ApplicationType.Unavailable)
            {
                try
                {
                    var pipProSet = new ProcessStartInfo(findExecutableInPath("python"), "-m pip freeze")
                    { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true, StandardOutputEncoding = Encoding.UTF8, StandardErrorEncoding = Encoding.UTF8 };
                    using (var pipPro = Process.Start(pipProSet))
                    {
                        var rpote = new ReadProcessOutputToEnd(pipPro);
                        pipPro.WaitForExit();
                        var theList = rpote.getOutput();
                        if (theList.Contains("yt-dlp")) installed = ApplicationType.YT_DLP;
                        else if (theList.Contains("youtube-dl")) installed = ApplicationType.YoutubeDL;
                        else installed = ApplicationType.Unavailable;
                    }
                }
                catch (Exception)
                {
                    installed = ApplicationType.Unavailable;
                }
            }
            return installed;
        }

        private static String findExecutableInPath(string target)
        {
            if (target.Equals("")) return null;
            target = Path.GetFileNameWithoutExtension(target) + ".exe";
            foreach (var c in pathLocs)
            {
                if (Path.GetFileNameWithoutExtension(c).Equals(target) && File.Exists(c)) return c;
                if (File.Exists(Path.Combine(c, target))) return Path.Combine(c, target);
            }
            return null;
        }
    }

    enum ApplicationType : int
    {
        Unavailable = 0,
        YoutubeDL = 1,
        YT_DLP = 2
    }

    class ReadProcessOutputToEnd : IDisposable
    {
        Process theProcess;
        string tout = "";
        string terr = "";


        public ReadProcessOutputToEnd(Process processIn)
        {
            theProcess = processIn;
            theProcess.BeginOutputReadLine();
            theProcess.BeginErrorReadLine();
            theProcess.OutputDataReceived += theProcess_OutputDataReceived;
            theProcess.ErrorDataReceived += theProcess_ErrorDataReceived;
            theProcess.Exited += theProcess_Exited;
            theProcess.EnableRaisingEvents = true;
        }

        void theProcess_Exited(object sender, EventArgs e)
        {
            try
            {
                theProcess.CancelOutputRead();
            }
            catch (InvalidOperationException ex)
            {
            }
            try
            {
                theProcess.CancelErrorRead();
            }
            catch (InvalidOperationException ex)
            {
            }
        }

        void theProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null || e.Data.Equals("")) return;
            terr += e.Data + Environment.NewLine;
        }

        void theProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null || e.Data.Equals("")) return;
            tout += e.Data + Environment.NewLine;
        }

        public string getOutput()
        {
            return tout;
        }

        public string getError()
        {
            return terr;
        }

        public void Dispose()
        {
            theProcess.Close();
        }
    }
}
