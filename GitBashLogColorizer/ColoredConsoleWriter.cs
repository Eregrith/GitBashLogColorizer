using Colorful;

namespace GitBashLogColorizer
{
    internal class ColoredConsoleWriter : IConsoleWriter
    {
        private StyleSheet StyleSheet { get; set; }

        public ColoredConsoleWriter()
        {
            StyleSheet = new StyleSheet(System.Drawing.Color.White);
            StyleSheet.AddStyle("-----  Query  -----", System.Drawing.Color.Gold);
            StyleSheet.AddStyle("----- / Query -----", System.Drawing.Color.Gold);
            StyleSheet.AddStyle("[A-HJ-Z]+[a-zA-Z]*Query", System.Drawing.Color.OrangeRed);

            StyleSheet.AddStyle("-----  Response  --", System.Drawing.Color.Chocolate);
            StyleSheet.AddStyle("----- / Response --", System.Drawing.Color.Chocolate);
            StyleSheet.AddStyle("[a-zA-Z]+Response", System.Drawing.Color.OliveDrab);

            StyleSheet.AddStyle("----- / Command ---", System.Drawing.Color.Fuchsia);
            StyleSheet.AddStyle("-----  Command  ---", System.Drawing.Color.Fuchsia);
            StyleSheet.AddStyle("[a-zA-Z]+Command", System.Drawing.Color.HotPink);

            StyleSheet.AddStyle("-----  Exception  -", System.Drawing.Color.Red);
            StyleSheet.AddStyle("----- / Exception -", System.Drawing.Color.Red);
            StyleSheet.AddStyle("Exception: *$", System.Drawing.Color.Red);

            StyleSheet.AddStyle("ApiClient[a-zA-Z]*Exception", System.Drawing.Color.Red);
            StyleSheet.AddStyle("HerculeDbContext", System.Drawing.Color.Red);
            StyleSheet.AddStyle("Could not resolve parameter", System.Drawing.Color.Red);

            StyleSheet.AddStyle("I[A-Za-z]+Handler", System.Drawing.Color.Khaki);

            StyleSheet.AddStyle("\"[^\"]*\"(,$|$)", System.Drawing.Color.Tomato);

            StyleSheet.AddStyle("[{}]", System.Drawing.Color.Red);
            StyleSheet.AddStyle(@"[\[\]]", System.Drawing.Color.Green);

            StyleSheet.AddStyle("null", System.Drawing.Color.Crimson);
            StyleSheet.AddStyle("[0-9.]+(,$|$)", System.Drawing.Color.Tan);
            StyleSheet.AddStyle("true|false", System.Drawing.Color.DeepSkyBlue);
            StyleSheet.AddStyle("(\"[^\"]*\"):", System.Drawing.Color.Magenta);
        }

        public void WriteColoredLine(string line)
        {
            Console.WriteLineStyled(line, StyleSheet);
        }
    }
}