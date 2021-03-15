using System;
using System.Diagnostics;

using VNC;

namespace VNCCodeCommandConsole.Helpers
{
    public class Command
    {
        public static int Execute(string Command, int Timeout)
        {
            Int64 startTicks = Log.APPLICATION($"Enter ({Command}) TimeOut:({Timeout})", Common.LOG_APPNAME);

            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            Process = Process.Start(ProcessInfo);
            Process.WaitForExit(Timeout);
            ExitCode = Process.ExitCode;
            Process.Close();

            Log.APPLICATION($"Exit ({ExitCode})", Common.LOG_APPNAME, startTicks);

            return ExitCode;
        }
    }
}
