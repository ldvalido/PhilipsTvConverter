using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using CommandLine;

namespace PhilipsTvConverter.CmdCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).
                WithParsed(opts => HandleOptions(opts)).
                WithNotParsed(errs => HandleError(errs));
        }

        public static void HandleOptions(Options opts)
        {
            var ffpmegPath = ConfigurationManager.AppSettings["ffmpegPath"];
            var ffpmegArgs = ConfigurationManager.AppSettings["ffmpegArgs"];
            var src = opts.SourcePattern;
            var target = Path.ChangeExtension(src,opts.Extension);

            var p = new Process();
            p.StartInfo.FileName = ffpmegPath;
            p.StartInfo.Arguments = string.Format(ffpmegArgs, src, target);
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.WaitForExit();
        }

        public static void HandleError(IEnumerable<Error> err)
        {
            
        }
    }
}
