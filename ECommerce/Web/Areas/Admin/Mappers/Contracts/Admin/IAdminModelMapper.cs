// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IAdminModelMapper.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web.Areas.Admin.Mappers.Contracts.Admin
{
    using BO = BusinessService.Model;
    using FO = Models;

    public interface IAdminModelMapper
    {
        BO.AdminUser Map(FO.AdminUser adminUser);
    }
}