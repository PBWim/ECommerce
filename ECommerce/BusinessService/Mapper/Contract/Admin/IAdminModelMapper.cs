// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IAdminModelMapper.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace BusinessService.Mapper.Contract.Admin
{
    using System.Collections.Generic;
    using BO = Model;
    using RO = DataAccess.Models.Admin;

    public interface IAdminModelMapper
    {
        BO.AdminUser Map(RO.AdminUser adminUser);
        RO.AdminUser Map(BO.AdminUser adminUser);
        IEnumerable<BO.AdminUser> Map(IEnumerable<RO.AdminUser> adminUser);
        IEnumerable<RO.AdminUser> Map(IEnumerable<BO.AdminUser> adminUser);
    }
}