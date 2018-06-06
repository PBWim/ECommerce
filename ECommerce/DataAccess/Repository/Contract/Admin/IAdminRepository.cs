// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IAdminRepository.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.Repository.Contract.Admin
{
    using System.Collections.Generic;
    using DataAccess.Models.Admin;

    public interface IAdminRepository
    {
        IEnumerable<AdminUser> GetAdminUsers();
        AdminUser GetAdminUser(int id);
        bool CreateAdminUser(AdminUser adminUser);
        bool UpdateAdminUser(AdminUser adminUser);
        bool DeleteAdminUser(int id);
    }
}