// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IAdminModelMapper.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web.Areas.Admin.Mappers.Contracts.Admin
{
    using System.Collections.Generic;
    using BO = BusinessService.Model;
    using FO = Models;

    public interface IAdminModelMapper
    {
        BO.AdminUser Map(FO.AdminUser adminUser);
        FO.AdminUser Map(BO.AdminUser adminUser);
        IEnumerable<BO.AdminUser> Map(IEnumerable<FO.AdminUser> adminUser);
        IEnumerable<FO.AdminUser> Map(IEnumerable<BO.AdminUser> adminUser);
    }
}