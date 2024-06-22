using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Check the operating system
        if (OperatingSystem.IsWindows())
        {
            ExecuteCommand("cmd.exe", "/c dir");
            
        }
        else
        {
            ExecuteCommand("ls", "-l");            
        }
    }

    static void ExecuteCommand(string command, string arguments)
    {
        try
        {
            ProcessStartInfo processInfo = new ProcessStartInfo(command, arguments);
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
