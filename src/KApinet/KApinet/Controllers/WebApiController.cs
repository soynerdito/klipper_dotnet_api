using KApinet.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KApinet.Controllers
{
    /// <summary>
    /// Trying to replicate moonraker apis
    /// </summary>

    public record WebApiController(KlippyMessager klippy)
    {
        [HttpGet("printer/info")]
        public async Task<IActionResult> Info() => new OkObjectResult(await klippy.CallMethod(EnumKMessage.Info));

        [HttpPost("printer/print/pause")]
        public async Task<IActionResult> PrintPause() => new OkObjectResult(await klippy.Send(new KApinet.Model.GPause(0)));

        [HttpPost("printer/print/resume")]
        public async Task<IActionResult> PrintResume()
            => new OkObjectResult(await klippy.Send(new KApinet.Model.GResume(222)));

        [HttpPost("printer/gcode")]
        public async Task<IActionResult> PrintCancel([FromBody] string gcode)
         => new OkObjectResult(await klippy.Send(
                new Model.KMessage(1, "gcode/script",
                new
                {
                    script = gcode
                })));

        [HttpPost("printer/emergency_stop")]
        public async Task<IActionResult> EmergencyStop()
            => new OkObjectResult(await klippy.CallMethod(EnumKMessage.EmergencyStop));

        public record ObjectList(List<string> objects);
        [HttpGet("/printer/objects/list")]
        [ProducesResponseType(typeof(ObjectList), 200)]
        public async Task<IActionResult> GetObjectList()
            => new OkObjectResult(await klippy.CallMethod(EnumKMessage.PrinterObjectList));

        //[HttpGet("/printer/objects/query")]        
        //[HttpGet("/printer/query_endstops/status")]
        //[HttpGet("/server/info")]
        //[HttpGet("/server/temperature_store")]
    }
}
