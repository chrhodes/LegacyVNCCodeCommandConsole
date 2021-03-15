using System;
using System.Collections.Generic;
using System.Linq;

using VNC;

namespace VNCCodeCommandConsole.User_Interface
{
    public class ViewModeItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ViewMode.Mode Mode { get; set; }

        public ViewModeItem()
        {

        }

        public ViewModeItem(string name, string value, ViewMode.Mode mode)
        {
            long startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            Name = name;
            Value = value;
            Mode = mode;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
