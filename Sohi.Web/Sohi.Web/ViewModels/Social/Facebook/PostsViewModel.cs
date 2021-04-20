using System;
using System.Collections.Generic;
using Sohi.Web.Models.SocialMedia;

namespace Sohi.Web.ViewModels.Social.Facebook
{
    public class PostsViewModel
    {
        public List<Post> posts { get; set; }

        public List<Profile> profiles { get; set; }
    }
}
