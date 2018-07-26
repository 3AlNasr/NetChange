using System;

namespace NetChange
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            String output = execute("netsh interface show interface | grep Wi-Fi ");
            if (output.StartsWith("Habilitado"))
            {
                execute("netsh interface set interface Ethernet enabled & netsh interface set interface Wi-Fi disabled ");
            }
            else
            {
                execute("netsh interface set interface Ethernet disabled & netsh interface set interface Wi-Fi enabled ");
            }
        }

        private static String execute(String command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = @"C:\Windows\System32\cmd.exe";
            startInfo.Arguments = "/c " + command;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            return process.StandardOutput.ReadToEnd();
        }
    }
}