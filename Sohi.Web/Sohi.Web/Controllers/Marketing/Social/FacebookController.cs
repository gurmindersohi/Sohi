using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models;
using Sohi.Web.Models.SocialMedia;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers.Marketing.Social
{
    [Route("Marketing/Social/[controller]")]
    public class FacebookController : Controller
    {

        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly UserManager<User> userManager;


        //public IActionResult Index()
        //{
        //    return View();
        //}
        public FacebookController(ISocialMediaRepository socialMediaRepository, UserManager<User> userManager)
        {
            this.userManager = userManager;
            _socialMediaRepository = socialMediaRepository;
        }

        [Route("Queue")]
        public IActionResult Queue()
        {
            return View("~/Views/Marketing/Social/Facebook/Queue.cshtml");
        }


        [Route("Posts")]
        public async Task<IActionResult> PostsAsync()
        {

            List<SocialMedia> socialMedia = await GetTokenAsync();

            if (socialMedia != null)
            {
                foreach (var account in socialMedia)
                {
                    if (account.Type == "Facebook")
                    {
                        string pageid = "102420827994118";
                        var pagetoken = await _socialMediaRepository.GenerateFacebookPageTokenAsync(pageid, account.AccessToken);

                        var posts = GetFacebookPosts(pageid, pagetoken);

                    }
                }

            }
            else
            {
                string abc = "error";
            }


            return PartialView("~/Views/Marketing/Social/Facebook/Posts.cshtml");
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

        [HttpGet]
        public async Task<List<Post>> GetFacebookPosts(string pageid, string pagetoken)
        {

            List<Post> posts = posts = await _socialMediaRepository.GetFacebookPosts(pageid, pagetoken);

            return posts;

        }

    }
}
