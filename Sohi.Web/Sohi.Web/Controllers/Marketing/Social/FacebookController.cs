using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models;
using Sohi.Web.Models.Azure;
using Sohi.Web.Models.SocialMedia;
using Sohi.Web.ViewModels.Social.Facebook;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers.Marketing.Social
{
    [Route("Marketing/Social/[controller]")]
    public class FacebookController : Controller
    {

        //CloudStorageAccount

        //private string token { set; get; }

        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly UserManager<User> userManager;
        private readonly IBlobRepository _blobRepository;


        public IActionResult Index()
        {
            return View();
        }



        public FacebookController(ISocialMediaRepository socialMediaRepository, UserManager<User> userManager, IBlobRepository BlobRepository)
        {
            this.userManager = userManager;
            _socialMediaRepository = socialMediaRepository;
            _blobRepository = BlobRepository;

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


            List<PostsViewModel> posts = new List<PostsViewModel>();

            if (socialMedia != null)
            {
                foreach (var account in socialMedia)
                {
                    if (account.Type == "Facebook")
                    {
                        await GetFacebookPages(account.AccessToken);
                        string pageid = "102420827994118";
                        var pagetoken = await _socialMediaRepository.GenerateFacebookPageTokenAsync(pageid, account.AccessToken);

                        posts = await GetFacebookPosts(pageid, pagetoken);

                    }
                }

            }
            else
            {
                string abc = "error";
            }


            return View("~/Views/Marketing/Social/Facebook/Posts.cshtml", posts);
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
        public async Task<List<PostsViewModel>> GetFacebookPosts(string pageid, string pagetoken)
        {

            List<PostsViewModel> posts = posts = await _socialMediaRepository.GetFacebookPosts(pageid, pagetoken);

            return posts;

        }


        [HttpGet]
        public async Task<List<Profile>> GetFacebookPages(string accesstoken)
        {

            List<Profile> pages = await _socialMediaRepository.GetFacebookPages(accesstoken);

            return pages;

        }


        [HttpGet]
        [Route("ListBlobs")]
        public async Task<IActionResult> ListBlobs()
        {

            return Ok(await _blobRepository.ListBlobsAsync());

        }



        //[Route("Share")]
        //[HttpPost]
        //public async Task<IActionResult> ShareAsync(PostCreateViewModel postCreateViewModel)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        postCreateViewModel.File.

        //    }


        //    return View("~/Views/Marketing/Social/Facebook/Posts.cshtml");
        //}

    }
}
