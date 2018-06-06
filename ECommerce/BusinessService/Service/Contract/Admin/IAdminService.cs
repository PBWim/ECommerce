// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IAdminService.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace BusinessService.Service.Contract.Admin
{
    using System.Collections.Generic;
    using BusinessService.Model;

    public interface IAdminService
    {
        IEnumerable<AdminUser> GetAdminUsers();
        AdminUser GetAdminUser(int id);
        bool CreateAdminUser(AdminUser adminUser);
        bool UpdateAdminUser(AdminUser adminUser);
        bool DeleteAdminUser(int id);
    }
}