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

    public class AdminService : IService<IAdminRepository>, IAdminService
    {
        IAdminModelMapper adminModelMapper;

        public AdminService(IAdminRepository adminRepository, IAdminModelMapper adminModelMapper)
        {
            repository = adminRepository;
            this.adminModelMapper = adminModelMapper;
        }

        public IEnumerable<AdminUser> GetAdminUsers()
        {
            return adminModelMapper.Map(repository.GetAdminUsers());
        }

        public AdminUser GetAdminUser(int id)
        {
            return adminModelMapper.Map(repository.GetAdminUser(id));
        }

        public bool CreateAdminUser(AdminUser adminUser)
        {
            return repository.CreateAdminUser(adminModelMapper.Map(adminUser));
        }

        public bool UpdateAdminUser(AdminUser adminUser)
        {
            return repository.UpdateAdminUser(adminModelMapper.Map(adminUser));
        }

        public bool DeleteAdminUser(int id)
        {
            return repository.DeleteAdminUser(id);
        }
    }
}