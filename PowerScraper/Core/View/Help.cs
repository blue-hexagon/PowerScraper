using System;
using System.Text;
using PowerScraper.Core.Scraping;

namespace PowerScraper.Core.View
{
    public static class HelpView
    {
        public static void VerboseDisplay()
        {
            foreach (var catDes in DescriptorController.CategoryDescriptorList)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{catDes.Name,-38} {catDes.CmdArg,-24} {catDes.Description}");
                foreach (var colDes in catDes.Collectors)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"- {colDes.Name,-36} {colDes.CmdArg,-24} {colDes.Description}");
                }

                Console.WriteLine();
            }
        }

        public static void BriefDisplay()
        {
            var stringBuilder = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Use --help for a more verbose display");
            Console.ForegroundColor = ConsoleColor.White;
            stringBuilder.Append("./PowerScraper.exe  [--help] [formatting=yaml|json|toml|xml|ini|csv] [");
            foreach (var catDes in DescriptorController.CategoryDescriptorList)
            {
                stringBuilder.Append($"{catDes.CmdArg}] [");
                foreach (var colDes in catDes.Collectors)
                {
                    if (catDes.CmdArg == "--all")
                        continue;
                    stringBuilder.Append($"{colDes.CmdArg}] [");
                }
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            Console.WriteLine(stringBuilder);
        }
    }
}