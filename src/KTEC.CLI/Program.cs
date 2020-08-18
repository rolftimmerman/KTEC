using System;
using System.Collections.Generic;
using CommandLine;
using KTEC.Core.Persistence;

namespace KTEC.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        static void RunOptions(Options opts)
        {
            var name = opts.Name;
            var repository = new CameraRepository(); //TODO: Dependency Injection

            foreach (var camera in repository.FindByPartOfName(name))
            {
                Console.WriteLine(camera.ToString());
            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Errors: {0}", errs.ToString());
        }
    }
}
