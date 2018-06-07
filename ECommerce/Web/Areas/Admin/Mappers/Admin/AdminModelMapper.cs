// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "AdminModelMapper.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web.Areas.Admin.Mappers.Admin
{
    using System.Collections.Generic;
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
                Telephone = adminUser.Telephone
            };
        }

        public FO.AdminUser Map(BO.AdminUser adminUser)
        {
            return new FO.AdminUser
            {
                UserName = adminUser.UserName,
                Email = adminUser.Email,
                Password = adminUser.Password,
                Telephone = adminUser.Telephone
            };
        }

        public IEnumerable<BO.AdminUser> Map(IEnumerable<FO.AdminUser> adminUser)
        {
            List<BO.AdminUser> adminUserList = new List<BO.AdminUser>();
            foreach (var item in adminUser)
            {
                adminUserList.Add(Map(item));
            }
            return adminUserList;
        }

        public IEnumerable<FO.AdminUser> Map(IEnumerable<BO.AdminUser> adminUser)
        {
            List<FO.AdminUser> adminUserList = new List<FO.AdminUser>();
            foreach (var item in adminUser)
            {
                adminUserList.Add(Map(item));
            }
            return adminUserList;
        }
    }
}