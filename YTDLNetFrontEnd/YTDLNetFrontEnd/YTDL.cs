using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using com.captainalm.YTDLNetFrontEnd.util;

namespace com.captainalm.YTDLNetFrontEnd
{
    static class YTDL
    {
        private static string[] pathLocs = Environment.GetEnvironmentVariable("PATH").Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        public static MonitorableProcess executeApplication(string target, string extra)
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
                ((getInstalled() == ApplicationType.YT_DLP) ? "-N 16 " : "") + "\"" + target + "\"" + (extra.Equals("") ? "" : " " + extra))
                { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true, StandardOutputEncoding = Encoding.UTF8, StandardErrorEncoding = Encoding.UTF8 };
            return new MonitorableProcess(pyProSet);
        }

        public static MonitorableProcess executeInstall(ApplicationType package, bool update)
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
                    return null;
            }
            var pipProSet = new ProcessStartInfo(findExecutableInPath("python"), "-m pip install " + packageName + ((update) ? " --upgrade" : ""))
            { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true, StandardOutputEncoding = Encoding.UTF8, StandardErrorEncoding = Encoding.UTF8 };
            return new MonitorableProcess(pipProSet);
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
                    using (var pipPro = new MonitorableProcess(pipProSet))
                    {
                        var outputReader = new OutputReceiverReader();
                        pipPro.addOuputReceiver(outputReader);
                        pipPro.start();
                        pipPro.waitForExit();
                        var theList = outputReader.getData();
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
}
