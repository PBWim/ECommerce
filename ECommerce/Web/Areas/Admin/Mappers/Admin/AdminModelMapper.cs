// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "AdminModelMapper.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web.Areas.Admin.Mappers.Admin
{
    using Web.Areas.Admin.Mappers.Contracts.Admin;
    using BO = BusinessService.Model;
    using FO = Models;

    public class AdminModelMapper : IAdminModelMapper
    {
        public BO.AdminUser Map(FO.AdminUser adminUser)
        {
            return new BO.AdminUser
            {
                UserName = adminUser.UserName,
                Email = adminUser.Email,
                Password = adminUser.Password,
                Telephone = adminUser.Password
            };
        }
    }
}