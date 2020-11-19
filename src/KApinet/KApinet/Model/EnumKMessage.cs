using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KApinet.Model
{
    public static class EnumKMessage
    {        
        public static string Info => "info";
        public static string PrinterObjectList => "objects/list";
        public static string EmergencyStop => "emergency_stop";
        public static string ListEpsEndpoint => "list_endpoints";
        public static string GcSubscribeOutput => "gcode/subscribe_output";
        public static string GcodeScript => "gcode/script";
        public static string Subscribe => "objects/subscribe";
        public static string ObjectsQuery => "objects/query";
        public static string RegMethodEndpoint => "register_remote_method";
        public static string PauseResume => "pause_resume/resume";
        public static string Pause => "pause_resume/pause";

    }
}
