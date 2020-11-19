using KApinet.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KApinet.Controllers
{
    /// <summary>
    /// Trying to replicate moonraker apis
    /// </summary>

    public record WebApiController(KlippyMessager klippy)
    {
        [HttpGet("printer/info")]
        public async Task<IActionResult> Info() 
            => new OkObjectResult(await klippy.CallMethod(EnumKMessage.Info));

        [HttpPost("printer/print/pause")]
        public async Task<IActionResult> PrintPause()
            => new OkObjectResult(await klippy.CallMethod(EnumKMessage.Pause));

        [HttpPost("printer/print/resume")]
        public async Task<IActionResult> PrintResume()
            => new OkObjectResult(await klippy.CallMethod(EnumKMessage.PauseResume));

        [HttpPost("printer/gcode")]
        public async Task<IActionResult> PrintCancel([FromBody] string gcode)
         => new OkObjectResult(await klippy.Send(
                new Model.KMessage(1, EnumKMessage.GcodeScript,
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

        [HttpGet("/printer/objects/query")]
        [ProducesResponseType(typeof(ObjectList), 200)]
        public async Task<IActionResult> ObjectQuery()
            => new OkObjectResult(await klippy.CallMethod(EnumKMessage.ObjectsQuery));

        //[HttpGet("/printer/objects/query")]        
        //[HttpGet("/printer/query_endstops/status")]
        //[HttpGet("/server/info")]
        //[HttpGet("/server/temperature_store")]
    }
}
