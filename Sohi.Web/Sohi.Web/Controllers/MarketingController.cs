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

        public async Task<IActionResult> GetUserAccessTokenAsync()
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


            }
            catch (Exception ex)
            {
            }

            return View("Index");

        }

        public async Task<IActionResult> FacebookLoginAsync()
        {

           await GetUserAccessTokenAsync();

           




            //try
            //{

            //    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //    request.Method = "GET";
            //    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //    {
            //        StreamReader reader = new StreamReader(response.GetResponseStream());

            //        string values = reader.ReadToEnd();

            //        JObject jObject = JObject.Parse(values);
            //        var response2 = (string)jObject.SelectToken("code");
            //    }
            //}
            //catch (Exception ex)
            //{

            //}




            //try
            //{
            //    string url = string.Format("https://graph.facebook.com/v6.0/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", appID, redirectURL, appSecret, code);

            //    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //    request.Method = "GET";
            //    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //    {
            //        StreamReader reader = new StreamReader(response.GetResponseStream());

            //        string values = reader.ReadToEnd();

            //        JObject jObject = JObject.Parse(values);
            //        user_access_token = (string)jObject.SelectToken("access_token");
            //    }
            //}
            //catch
            //{
            //    user_access_token = null;
            //}


            //string url = "https://www.facebook.com/v10.0/dialog/oauth?client_id=1133254180447928&redirect_uri=https://localhost:5001/Marketing&scope=email";
            //Response.Redirect(url);

            //if (Request["code"] != null)
            //{
            //    string code = Request.QueryString["code"];
            //    Session["accessToken"] = GetUserAccessToken(appID, appSecret, redirectUrl, code);
            //    Session.Timeout = 1;

            //    String x = "<script type='text/javascript'>window.opener.location.href='AdCampaigns.aspx?rdk=" + "&admin=" + Session["admin"].ToString() + "#Intro';self.close();</script>";
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", x, false);




            //}

            return View();
        }
    }
}
