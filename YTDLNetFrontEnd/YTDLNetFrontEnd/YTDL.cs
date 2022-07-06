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
            var pipProSet = new ProcessStartInfo(findExecutableInPath("python"), "-m pip install " + packageName + ((update) ? " --upgrade" : "")) { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true };
            using (var pipPro = Process.Start(pipProSet))
            {
                using (var errTSR = new ThreadedStreamReader(pipPro.StandardError.BaseStream))
                {
                    using (var outTSR = new ThreadedStreamReader(pipPro.StandardOutput.BaseStream))
                    {
                        pipPro.WaitForExit();
                        try
                        {
                            var terr = System.Text.Encoding.UTF8.GetString(errTSR.getData());
                            var tout = System.Text.Encoding.UTF8.GetString(outTSR.getData());
                            if (terr != "") return terr; else return tout;
                        }
                        catch (Exception e)
                        {
                            return "Exception:" + e.GetType().FullName + ":" + e.Message;
                        }
                    }
                }
            }
        }

        private static ApplicationType installed;
        public static ApplicationType getInstalled()
        {
            if (installed == ApplicationType.Unavailable)
            {
                try
                {
                    var pipProSet = new ProcessStartInfo(findExecutableInPath("python"), "-m pip freeze") {UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true};
                    using (var pipPro = Process.Start(pipProSet))
                    {
                        var theList = pipPro.StandardOutput.ReadToEnd();
                        pipPro.WaitForExit();
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

    class ThreadedStreamReader : IDisposable
    {
        Thread theThread;
        MemoryStream msToRet;
        Stream theStream;
        public ThreadedStreamReader(Stream streamIn)
        {
            theStream = streamIn;
            msToRet = new MemoryStream();
            theThread = new Thread(thread_execute);
            theThread.IsBackground = true;
            theThread.Start();
        }

        void thread_execute()
        {
            try
            {
                int b;
                while ((b = theStream.ReadByte()) != -1) msToRet.WriteByte((byte)b);
            }
            catch (Exception e)
            {
                var msg = System.Text.Encoding.UTF8.GetBytes("Exception:" + e.GetType().FullName + ":" + e.Message);
                msToRet.Write(msg, 0, msg.Length);
            }
        }

        public byte[] getData()
        {
            theThread.Join();
            return msToRet.ToArray();
        }

        public void Dispose()
        {
            theThread.Join();
            msToRet.Close();
        }
    }
}
