using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace PALCCrashHandler;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 5)
        {
            string wawa = "V2hpbGUgcGxheWluZyBhIFBBIGxldmVsLCBob2xkIGVudGVyL3NwYWNlIGFmdGVyIHVucGF1c2luZyBmb3IgaXQgdG8gZ28gZmFzdGVyLiAoRnJvbSBNb3Rpb25JSUkp";
            Console.WriteLine(
                "Heeeyyyyy, did you just try to open the crash handler? Without crashing the program? Damn...\n" +
                "Well, while you're here, I'd like to tell you a secret.\n\n" +
                Encoding.UTF8.GetString(Convert.FromBase64String(wawa)) + "\n\n" +
                "Make of that as you will, this message may change sometimes... :3\n\n\n" +
                "Press any key to exit." 
            );

            Console.ReadKey();
            return;
        }

        string palcVersion = args[0];
        string logFilesPath = args[1];
        string githubIssuesLink = args[2];
        string errorMessage = args[3];
        string stackTrace = args[4];

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            $"------------------------------------------------------------\n" +
            $"A fatal error has occurred.\n" +
            $"\n" +
            $"\n" +
            $"Here are some resources to report this error:\n" +
            $"\n" +
            $"REPORT YOUR ISSUES HERE: {githubIssuesLink}\n" +
            $"Log files are stored in: {logFilesPath}\n" +
            $"\n" +
            $"Current PALC version: {palcVersion}\n" +
            $"\n" +
            $"\n" +
            $"Scroll down for more options, such as opening the issues page.\n" +
            $"------------------------------------------------------------"
        );

        Console.ResetColor();
        Console.WriteLine(
            $"\n" +
            $"\n" +
            $"\n" +
            $"{errorMessage}\n" +
            $"{stackTrace}"
        );


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(
            "\n\n\n" +
            "--- PALC crashed. Please scroll up to view more important information. ---" +
            "\n\n"
        );

        Console.ResetColor();

        while (true)
        {
            Console.WriteLine(
                "Please choose an action (repeatable until exit):\n" +
                "[O] Open Github Link for reporting\n" +
                "[L] Open logs folder\n" +
                "[any other key] Exit\n"
            );

            Console.Write("> ");
            ConsoleKeyInfo input = Console.ReadKey(true);

            Console.WriteLine("\n\n");

            try
            {
                if (input.Key == ConsoleKey.O)
                    Process.Start(new ProcessStartInfo(githubIssuesLink) { UseShellExecute = true });
                else if (input.Key == ConsoleKey.L)
                {
                    Process.Start("explorer.exe", logFilesPath);
                }
                else break;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };
        }
    }
}
