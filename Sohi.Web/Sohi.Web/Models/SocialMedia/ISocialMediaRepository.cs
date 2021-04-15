using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sohi.Web.ViewModels.Social.Facebook;

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


        Task<Profile> GetInstagramAccountAsync(string accesstoken);

        Task<string> GetInstagramAccountImageAsync(string username);


        Task<Profile> GetFacebookAccountAsync(string accesstoken);

        //Task<Profile> Post(string accesstoken)

        Task<string> GenerateFacebookPageTokenAsync(string pageid, string pagetoken);

        Task<List<PostsViewModel>> GetFacebookPosts(string PageId, string PageToken);

        Task<List<Profile>> GetFacebookPages(string accesstoken);

    }
}
