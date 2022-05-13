using System;
using System.IO;
using System.Text;

namespace XoToken
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Expected <InputFile> <old_token> <columnIndexToExtract> <OutputFile>");
                Console.WriteLine("XolTrax by Thierry Bremard t.bremard@gmail.com");
                Console.WriteLine("    1 - Process each line of <InputFile>");
                Console.WriteLine("    2 - Extrax columns seperated by <old_token> ");
                Console.WriteLine("    3 - Isolate the columb <columnIndexToExtract> (0 based)");
                Console.WriteLine("    4 - Dumps result in <OutputFile> with one entry per line");
                return;
            }
            string inputFileName = args[0];
            string oldToken = args[1];
            int columnIndexToExtract = int.Parse(args[2]);
            string outputFileName = args[3];
            var lines = File.ReadAllLines(inputFileName);
            var sb = new StringBuilder();
            int processed = 0;
            foreach (var line in lines)
            {
                var tokens = line.Split(oldToken);
                if (columnIndexToExtract < tokens.Length )
                {
                    string extracted = tokens[columnIndexToExtract];
                    sb.AppendLine(extracted);
                    processed++;
                }
            }
            File.WriteAllText(outputFileName, sb.ToString());
            Console.WriteLine($"{processed} lines processed");
            Console.WriteLine("File created: " + outputFileName);
        }
    }
}
