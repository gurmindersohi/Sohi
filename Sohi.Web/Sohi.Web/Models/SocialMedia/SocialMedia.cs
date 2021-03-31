﻿using System;
using System.Collections.Generic;

namespace Sohi.Web.Models.SocialMedia
{
    public class SocialMedia
    {

		public Guid Id { get; set; }

		public string Type { get; set; }

		public string AccessToken { get; set; }

		public string Secret { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime TokenExpiryDate { get; set; }

		public string Email { get; set; }

		public string UserId { get; set; }

		public string AccountId { get; set; }

    }
}
