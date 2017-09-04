using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitBashLogColorizer
{
    public interface IConsoleWriter
    {
        void WriteColoredLine(string line);
    }
}
