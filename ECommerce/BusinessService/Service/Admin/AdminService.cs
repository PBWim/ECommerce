// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "AdminService.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace BusinessService.Service.Admin
{
    using System.Collections.Generic;
    using BusinessService.Mapper.Contract.Admin;
    using BusinessService.Model;
    using BusinessService.Service.Contract.Admin;
    using DataAccess.Repository.Contract.Admin;
    using Microsoft.Extensions.Logging;

    public class AdminService : IService<IAdminRepository>, IAdminService
    {
        IAdminModelMapper adminModelMapper;

        public AdminService(IAdminRepository adminRepository, IAdminModelMapper adminModelMapper, ILogger<AdminService> logger)
        {
            repository = adminRepository;
            this.logger = logger;
            this.adminModelMapper = adminModelMapper;
        }

        public IEnumerable<AdminUser> GetAdminUsers()
        {
            logger.LogInformation("Get all admin users");
            return adminModelMapper.Map(repository.GetAdminUsers());
        }

        public AdminUser GetAdminUser(int id)
        {
            logger.LogInformation($"GetAdminUser details of {id}");
            return adminModelMapper.Map(repository.GetAdminUser(id));
        }

        public bool CreateAdminUser(AdminUser adminUser)
        {
            logger.LogInformation($"CreateAdminUser of {adminUser.UserName}");
            return repository.CreateAdminUser(adminModelMapper.Map(adminUser));
        }

        public bool UpdateAdminUser(AdminUser adminUser)
        {
            logger.LogInformation($"UpdateAdminUser of {adminUser.UserName}");
            return repository.UpdateAdminUser(adminModelMapper.Map(adminUser));
        }

        public bool DeleteAdminUser(int id)
        {
            logger.LogInformation($"DeleteAdminUser of {id}");
            return repository.DeleteAdminUser(id);
        }
    }
}