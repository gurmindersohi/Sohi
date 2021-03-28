using System;
using System.Threading.Tasks;

namespace Sohi.Web.Models.SocialMedia
{
    public interface ISocialMediaRepository
    {
        Task<string> GenerateFacebookTokenAsync(string code);

        Task<string>  GenerateInstagramTokenAsync(string code);

        string GetFacebookLoginUrl();

        string GetInstagramLoginUrl();


    }
}
