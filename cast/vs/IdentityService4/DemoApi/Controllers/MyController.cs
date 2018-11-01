using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("[controller]/[action]")]
    public class MyController : Controller
    {
        [HttpPost]
        public IActionResult Index(int id)
        {
            switch (id)
            {
                case 0:
                    return Test();
                    break;
                case 1:
                    return Test1();
                    break;
            }

            return View();
        }

        public IActionResult Test()
        {
            return Content("success");
        }

        [Authorize]
        public IActionResult Test1()
        {
            return Content("success");
        }
    }
}