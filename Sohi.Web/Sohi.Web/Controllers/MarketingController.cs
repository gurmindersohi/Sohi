using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models;
using Sohi.Web.Models.SocialMedia;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers
{
    public class MarketingController : Controller
    {

        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly UserManager<User> userManager;

        public MarketingController(ISocialMediaRepository socialMediaRepository, UserManager<User> userManager)
        {
            _socialMediaRepository = socialMediaRepository;
            this.userManager = userManager;
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

            var result = SaveTokenAsync(token, "Facebook");
           
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


            var result = await SaveTokenAsync(token, "Instagram");

            return View("Index");
        }

        [HttpPost]
        public async Task<string> SaveTokenAsync(string AccessToken, string type)
        {
            try
            {
                var id = "";
                var user = await userManager.GetUserAsync(User);

                if (user != null)
                {
                    var account = new SocialMedia
                    {
                        Id = Guid.NewGuid(),
                        Type = type,
                        AccessToken = AccessToken,
                        CreatedOn = DateTime.Now,
                        Email = user.Email,
                        UserId = user.Id,
                        AccountId = user.AccountId
                    };

                    SocialMedia acc = _socialMediaRepository.Add(account);

                    id = acc.AccountId;

                }

                return id;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
