using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KApinet.Controllers
{
    public class GCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
