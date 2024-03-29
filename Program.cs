﻿using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace PALCCrashHandler;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 6)
        {
            string wawa = "V2hpbGUgcGxheWluZyBhIFBBIGxldmVsLCBob2xkIGVudGVyL3NwYWNlIGFmdGVyIHVucGF1c2luZyBmb3IgaXQgdG8gZ28gZmFzdGVyLiAoRnJvbSBNb3Rpb25JSUkpCkluIGxlZ2FjeSwgeW91IGNhbiBob2xkIGVudGVyIGFmdGVyIG9wZW5pbmcgdGhlIGdhbWUgdG8gZXNzZW50aWFsbHkgc2tpcCB0aGUgaW50cm8gc2VxdWVuY2UuIChGcm9tIFJlaW1ub3Ap";
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

        string program = args[0];
        string programVersion = args[1];
        string logFilesPath = args[2];
        string githubIssuesLink = args[3];
        string errorMessage = args[4];
        string stackTrace = args[5];

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            $"------------------------------------------------------------\n" +
            $"A fatal error has occurred.\n" +
            $"\n" +
            $"\n" +
            $"Here are some resources to report this error:\n" +
            $"\n" +
            $"REPORT THIS ISSUE HERE: {githubIssuesLink}\n" +
            $"Log files are stored in: {logFilesPath}\n" +
            $"\n" +
            $"Program: {program}\n" +
            $"Current program version: {programVersion}\n" +
            $"\n" +
            $"\n" +
            $"Scroll down for more options, such as opening the bug reporting page.\n" +
            $"------------------------------------------------------------"
        );

        Console.ResetColor();
        Console.WriteLine(
            $"\n" +
            $"\n" +
            $"\n" +
            $"An error occurred during runtime that the program never handled correctly:\n" +
            $"{errorMessage}\n\n" +
            $"{stackTrace}"
        );


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(
            "\n\n\n" +
            "--- A PALC program crashed. Please scroll up to view more important information. ---" +
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
