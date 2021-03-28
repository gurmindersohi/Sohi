using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sohi.Web.Models.SocialMedia;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers
{
    public class MarketingController : Controller
    {

        private readonly ISocialMediaRepository _socialMediaRepository;

        public MarketingController(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }


        public IActionResult Index()
        {

            return View();
        }

        public void FacebookLogin()
        {
            string url = _socialMediaRepository.GetFacebookLoginUrl();

            Response.Redirect(url);
        }

        public async Task<IActionResult> FacebookTokenAsync(string code)
        {
            string token = await _socialMediaRepository.GenerateFacebookTokenAsync(code);
           
            return View("Index");
        }

        public void InstagramLogin()
        {
            string url = _socialMediaRepository.GetInstagramLoginUrl();

            Response.Redirect(url);

        }

        public async Task<IActionResult> InstagramTokenAsync(string code)
        {
            string token = await _socialMediaRepository.GenerateInstagramTokenAsync(code);

            return View("Index");
        }

    }
}
