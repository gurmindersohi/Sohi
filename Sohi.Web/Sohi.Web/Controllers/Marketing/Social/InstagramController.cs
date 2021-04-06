using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers.Marketing.Social
{
    [Route("Marketing/Social/[controller]")]
    public class InstagramController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("Queue")]
        public IActionResult Queue()
        {
            return View("~/Views/Marketing/Social/Instagram/Queue.cshtml");
        }


        [Route("Posts")]
        public IActionResult Posts() {

            return PartialView("~/Views/Marketing/Social/Instagram/Posts.cshtml");
        }

    }
}
