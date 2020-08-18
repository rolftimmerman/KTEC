using CommandLine;

namespace KTEC.CLI
{
    public class Options
    {
        [Option('n', "name", Required = true, HelpText = "Zoek camera op basis van de (gedeelte van) naam.")]
        public string Name { get; set; }
    }
}
