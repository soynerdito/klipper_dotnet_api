using System;
using System.Collections.Generic;
using System.Text;

namespace KApinet.Model
{
    /*
     * INFO_ENDPOINT = "info"
    ESTOP_ENDPOINT = "emergency_stop"
    LIST_EPS_ENDPOINT = "list_endpoints"
    GC_OUTPUT_ENDPOINT = "gcode/subscribe_output"
    GCODE_ENDPOINT = "gcode/script"
    SUBSCRIPTION_ENDPOINT = "objects/subscribe"
    STATUS_ENDPOINT = "objects/query"
    OBJ_LIST_ENDPOINT = "objects/list"
    REG_METHOD_ENDPOINT = "register_remote_method"
     */
    public interface IKlippyCommand { }
    public interface IPostAction : IKlippyCommand { }
    public interface IGetAction : IKlippyCommand { }
    public record KMessage( int id, string method, object @params) : IKlippyCommand;
    //public record KInfo(int id ) : KMessage(id: id, method: "info", @params: new object()) , IGetAction;
    //public record GCodeScript(int id ) : KMessage(id: id, method: "gcode/script", @params: new object()) , IGetAction;
    //public record Status(int id) : KMessage(id: id, method: "gcode/status", @params: new object())  , IGetAction;
    //public record GCodeHelp(int id) : KMessage(id: id, method: "gcode/help", @params: new object()) ,  IGetAction;
    //public record GCodeRestart(int id) : KMessage(id: id, method: "gcode/restart", @params: new object()) , IPostAction;
    //public record GPause(int id) : KMessage(id: id, method: "pause_resume/pause", @params: new object()), IPostAction;
    //public record GResume(int id) : KMessage(id: id, method: "pause_resume/resume", @params: new object()), IPostAction;
    //public record GQEndstops(int id) : KMessage(id: id, method: "query_endstops/status", @params: new object()), IPostAction;


}
