using System.Threading.Tasks;
using KApinet.Model;
using Microsoft.AspNetCore.Mvc;

namespace KApinet.Controllers
{
    [ApiController]
    public class KlippyController : ControllerBase
    {

        [HttpGet]
        [Route("printer/info")]
        public async Task<IActionResult> Info([FromServices] KlippyMessager klippyMessager)
        {
            //return Ok(await klippyMessager.Send(new KInfo(1)) );
            return Ok(await klippyMessager.CallMethod(EnumKMessage.Info));
        }
        [HttpPost]
        [Route("printer/print/pause")]
        public async Task<IActionResult> PrintPause([FromServices] KlippyMessager klippyMessager)
        {
            return Ok(await klippyMessager.Send(new KApinet.Model.GPause(0)));
        }
        [HttpPost]
        [Route("printer/print/resume")]
        public async Task<IActionResult> PrintResume([FromServices] KlippyMessager klippyMessager)
        {
            return Ok(await klippyMessager.Send(new KApinet.Model.GResume(222)));
        }

        [HttpPost]
        [Route("printer/gcode")]
        public async Task<IActionResult> PrintCancel([FromServices] KlippyMessager klippyMessager, [FromBody] string gcode)
        {
            return Ok(await klippyMessager.Send(
                new Model.KMessage(1, "gcode/script",
                new
                {
                    script = gcode
                })));
        }

        [HttpPost]
        [Route("printer/emergency_stop")]
        public async Task<IActionResult> EmergencyStop([FromServices] KlippyMessager klippyMessager)
        {
            return Ok(await klippyMessager.CallMethod(EnumKMessage.EmergencyStop));
        }
    }
}
