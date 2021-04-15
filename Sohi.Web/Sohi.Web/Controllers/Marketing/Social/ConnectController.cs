using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models;
using Sohi.Web.Models.SocialMedia;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers.Marketing.Social
{
    public class ConnectController : Controller
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly UserManager<User> userManager;

        public ConnectController(ISocialMediaRepository socialMediaRepository, UserManager<User> userManager)
        {

            this.userManager = userManager;
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<SocialMedia> socialMedia = await GetTokenAsync();

            if (socialMedia != null)
            {
                foreach (var account in socialMedia)
                {
                    if (account.Type == "Facebook")
                    {
                        //Response.Redirect();

                        return View("~/Views/Marketing/Social/Facebook/Queue.cshtml");
                    }

                    if (account.Type == "Instagram")
                    {
                        return View("~/Views/Marketing/Social/Instagram/Queue.cshtml");
                    }

                }

            }
            else
            {
                string abc = "error";
            }


            return View("~/Views/Marketing/Social/Connect.cshtml");
        }


       //----------------------------------------------------------------------------


        public void FacebookLogin()
        {
            string url = _socialMediaRepository.GetFacebookLoginUrl();

            Response.Redirect(url);
        }

        public async Task<IActionResult> FacebookTokenAsync(string code)
        {
            string token = await _socialMediaRepository.GenerateFacebookTokenAsync(code);

            var result = await SaveTokenAsync(token, "Facebook");

            return View("~/Views/Marketing/Social/Facebook/Queue.cshtml");
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

            return View("~/Views/Marketing/Social/Instagram/Queue.cshtml");
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

        [HttpGet]
        public async Task<List<SocialMedia>> GetTokenAsync()
        {
            List<SocialMedia> acc = new List<SocialMedia>();

            var user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                acc = _socialMediaRepository.GetTokenAsync(user.AccountId);
            }

            return acc;

        }


        public async Task<Profile> GetInstagramAccountAsync(string accesstoken)
        {
            Profile profile = await _socialMediaRepository.GetInstagramAccountAsync(accesstoken);

            return profile;
        }

        public async Task<Profile> GetFacebookAccountAsync(string accesstoken)
        {
            Profile profile = await _socialMediaRepository.GetFacebookAccountAsync(accesstoken);

            return profile;
        }


    }
}
