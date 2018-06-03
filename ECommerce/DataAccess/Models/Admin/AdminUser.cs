// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "AdminUser.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.Models.Admin
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class AdminUser : IdentityUser<int>
    { 
        public bool IsSuperAdmin { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}