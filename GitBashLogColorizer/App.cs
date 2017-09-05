using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                fs.Seek(-4*4096, SeekOrigin.End);

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
