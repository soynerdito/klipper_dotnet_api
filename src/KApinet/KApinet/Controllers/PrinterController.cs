using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KApiSharp;
using KApiSharp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KApinet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {

        [HttpGet]
        [Route("info")]
        public async Task<IActionResult> Info([FromServices] KlippyMessager klippyMessager)
        {
            return Ok(await klippyMessager.Send(new KlippyMessage<object>()
            {
                Id = 123,
                Method = "info"
            }));
        }
    }
}
