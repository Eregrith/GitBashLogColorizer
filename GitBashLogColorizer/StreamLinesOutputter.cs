using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitBashLogColorizer
{
    public class StreamLinesOutputter
    {
        private IConsoleWriter ConsoleWriter;

        public StreamLinesOutputter(IConsoleWriter consoleWriter)
        {
            ConsoleWriter = consoleWriter;
        }

        public void WriteStreamLines(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    ConsoleWriter.WriteColoredLine(line);
                }
            }
        }
    }
}
