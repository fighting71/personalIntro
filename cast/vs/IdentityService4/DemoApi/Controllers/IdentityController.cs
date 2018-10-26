using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        [Authorize(Roles = "superadmin")]
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in HttpContext.User.Claims select new {c.Type, c.Value});
        }

        [Authorize(Roles = "admin")]
        [Route("{id}")]
        [HttpGet]
        public string Get(int id)
        {
            return id.ToString();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(int id)
        {

            var list = User.Claims.Select(u => new {u.Type, u.Value}).ToList();

            return new JsonResult(list);
        }
    }
}