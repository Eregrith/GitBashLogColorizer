using System;
using System.IO;
using System.Threading;

namespace GitBashLogColorizer
{
    public static class App
    {
        public static void Main(string[] args)
        {
            string logPath = args[0];

            try
            {
                var fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                try
                {
                    fs.Seek(-4 * 4096, SeekOrigin.End);
                }
                catch (Exception)
                {
                    //can't seek ? No problem
                }

                var wh = new AutoResetEvent(false);
                var fsw = new FileSystemWatcher(Path.GetDirectoryName(logPath));
                fsw.EnableRaisingEvents = true;
                fsw.Changed += (s, e) => wh.Set();
                using (var sr = new StreamReader(fs))
                {
                    var ccw = new ColoredConsoleWriter();
                    var s = "";
                    while (true)
                    {
                        s = sr.ReadLine();
                        if (s != null)
                            ccw.WriteColoredLine(s);
                        else
                            wh.WaitOne(1000);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
