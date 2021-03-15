using System;
using System.Windows;

using VNC;

namespace VNCCodeCommandConsole.Helpers
{
    public class Help
    {
        public static void GetHelpOnTopic(string helpTopic)
        {
            Int64 startTicks = Log.APPLICATION($"Enter ()", Common.LOG_APPNAME);

            switch (helpTopic)
            {
                case "DatabaseExpandTemplate":
                    MessageBox.Show("Display Help On " + helpTopic);
                    break;

                case "InstanceExpandTemplate":
                    MessageBox.Show("Display Help On " + helpTopic);
                    break;

                case "Servers":
                    MessageBox.Show("Display Help On " + helpTopic);
                    break;

                case "SnapShotControlsTemplate":
                    MessageBox.Show("Display Help On " + helpTopic);
                    break;

                default:
                    MessageBox.Show("Default Display Help On " + helpTopic);
                    break;
            }

            Log.APPLICATION("Exit", Common.LOG_APPNAME, startTicks);
        }

    }
}
