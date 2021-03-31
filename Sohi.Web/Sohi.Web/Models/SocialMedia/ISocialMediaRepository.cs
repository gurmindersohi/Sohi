using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sohi.Web.Models.SocialMedia
{
    public interface ISocialMediaRepository
    {
        Task<string> GenerateFacebookTokenAsync(string code);

        Task<string> GenerateInstagramTokenAsync(string code);

        string GetFacebookLoginUrl();

        string GetInstagramLoginUrl();


        SocialMedia Add(SocialMedia account);

        List<SocialMedia> GetTokenAsync(string accountid);


        Task<string> GetInstagramAccountAsync(string accesstoken);

        Task<Profile> GetFacebookAccountAsync(string accesstoken);

    }
}
