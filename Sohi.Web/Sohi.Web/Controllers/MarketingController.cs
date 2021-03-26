using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers
{
    public class MarketingController : Controller
    {


        public IActionResult Index(string? token)
        {

            string t = token;

            return View();
        }

        public async Task<string> GetUserAccessTokenAsync()
        {

            string appID = "1133254180447928";
            string appSecret = "89698c449ef21f306c26f2435f046ec6";
            string redirectUrl = "https://localhost:5001/Marketing/Index";


            HttpClient client = new HttpClient();


            string url1 = "https://www.facebook.com/v10.0/dialog/oauth?client_id=1133254180447928&redirect_uri=https://localhost:5001/Marketing/Index&scope=email";

            Response.Redirect(url1);

            var code = Request.Form["code"].ToString();


           

            try
            {
                //create the constructor with post type and few data
                string url = string.Format("https://graph.facebook.com/v10.0/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", appID, redirectUrl, appSecret, code);



                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public async Task<IActionResult> FacebookLoginAsync()
        {

           string token = await GetUserAccessTokenAsync();

            return View("Index");
        }

    }
}
