using CommandLine;

namespace PhilipsTvConverter.CmdCli
{
    public class Options
    {
        [Option('s', "source", Required = true, HelpText = "Input files to be processed.")]
        public string SourcePattern { get; set; }

        [Option('e',"extension",Required = false,HelpText = "Extension for the output file", Default = "mp4")]
        public string Extension { get; set; }
    }
}
