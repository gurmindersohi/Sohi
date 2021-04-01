using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Sohi.Web.Models.SocialMedia
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        private readonly AppDbContext context;

        private IConfiguration _config;
        private static readonly HttpClient client = new HttpClient();

        public SocialMediaRepository(IConfiguration configuration, AppDbContext context)
        {
            _config = configuration;
            this.context = context;
        }
       
        public async Task<string> GenerateInstagramTokenAsync(string code)
        {
                string client_id = _config.GetSection("InstagramApp").GetSection("ClientId").Value;
                string client_secret = _config.GetSection("InstagramApp").GetSection("ClientSecret").Value;
                string grant_type = _config.GetSection("InstagramApp").GetSection("grant_type").Value;
                string redirect_uri = _config.GetSection("InstagramApp").GetSection("RedirectURL").Value;

                string url = string.Format("https://api.instagram.com/oauth/access_token?");

                var values = new Dictionary<string, string>{
                  { "client_id", client_id },
                  { "client_secret", client_secret },
                  { "grant_type", grant_type },
                  { "redirect_uri", redirect_uri },
                  { "code", code },
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {

                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var parsedobj = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                string token = parsedobj["access_token"].ToString();
                return token;

            }
            else {
                return response.StatusCode.ToString();
            }


        }

        public async Task<string> GenerateFacebookTokenAsync(string code)
        {
            string client_id = _config.GetSection("FacebookApp").GetSection("ClientId").Value;
            string client_secret = _config.GetSection("FacebookApp").GetSection("ClientSecret").Value;
            string redirect_uri = _config.GetSection("FacebookApp").GetSection("RedirectURL").Value;

            string version = _config.GetSection("FacebookApp").GetSection("version").Value;

            string url = string.Format("https://graph.facebook.com/v" + version + "/oauth/access_token?");

            var values = new Dictionary<string, string>{
                  { "client_id", client_id },
                  { "client_secret", client_secret },
                  { "redirect_uri", redirect_uri },
                  { "code", code },
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {

                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var parsedobj = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                string token = parsedobj["access_token"].ToString();
                return token;

            }
            else
            {
                return response.ReasonPhrase;
            }
        }

        public string GetFacebookLoginUrl()
        {
            string client_id = _config.GetSection("FacebookApp").GetSection("ClientId").Value;
            string redirect_uri = _config.GetSection("FacebookApp").GetSection("RedirectURL").Value;
            string scopes = _config.GetSection("FacebookApp").GetSection("scopes").Value;

            string version = _config.GetSection("FacebookApp").GetSection("version").Value;

            string url = string.Format("https://www.facebook.com/v" + version + "/dialog/oauth?client_id={0}&redirect_uri={1}&scope={2}", client_id, redirect_uri, scopes);

            return url;
        }

        public string GetInstagramLoginUrl()
        {
            string client_id = _config.GetSection("InstagramApp").GetSection("ClientId").Value;
            string redirect_uri = _config.GetSection("InstagramApp").GetSection("RedirectURL").Value;
            string scopes = _config.GetSection("InstagramApp").GetSection("scopes").Value;
            string response_type = _config.GetSection("InstagramApp").GetSection("ResponseType").Value;

            string url = string.Format("https://api.instagram.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}&response_type={3}", client_id, redirect_uri, scopes, response_type);

            return url;

        }

        public SocialMedia Add(SocialMedia account)
        {
            context.SocialMediaAccounts.Add(account);
            context.SaveChanges();

            return account;
        }

        public List<SocialMedia> GetTokenAsync(string accountid)
        {
            Guid id = new Guid(accountid);

            List<SocialMedia> accounts = new List<SocialMedia>();

                accounts = context.SocialMediaAccounts.Where(a => a.AccountId == accountid).ToList();
                return accounts;


        }

        public async Task<Profile> GetFacebookAccountAsync(string accesstoken)
        {
            Profile profile = new Profile();

            string version = _config.GetSection("FacebookApp").GetSection("version").Value;

            string url = string.Format("https://graph.facebook.com/v" + version + "/me?fields=id,name,picture&access_token={0}", accesstoken);

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var parsedobj = (JObject)JsonConvert.DeserializeObject(jsonResponse);

                profile.Id = parsedobj["id"].ToString();
                profile.Name = parsedobj["name"].ToString();
                profile.Image = parsedobj["picture"]["data"]["url"].ToString();

                return profile;

            }
            else
            {
                return null;
                //return response.ReasonPhrase;
            }
        }


        public async Task<Profile> GetInstagramAccountAsync(string accesstoken)
        {
            Profile profile = new Profile();
            string url = string.Format("https://graph.instagram.com/me?fields=id,username&access_token={0}", accesstoken);
           
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var parsedobj = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                profile.Id = parsedobj["id"].ToString();
                profile.Name = parsedobj["username"].ToString();

                return profile;

            }
            else
            {
                return null;
            }
        }

        public async Task<string> GetInstagramAccountImageAsync(string username)
        {
            string url = string.Format("https://www.instagram.com/{0}/?__a=1", username);

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    var parsedobj = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                    string img = parsedobj["graphql"]["user"]["profile_pic_url"].ToString();

                    return img;

                }
                catch (JsonReaderException ex) {
                    return ex.Message;

                }


            }
            else
            {
                return null;
            }
        }
    }
}
