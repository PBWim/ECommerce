// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "AdminRepository.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.Repository.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Models.Admin;
    using DataAccess.Repository.Contract.Admin;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class AdminRepository : IRepository<AdminUser>, IAdminRepository
    {
        public AdminRepository(ECommerceDBContext context, ILogger<AdminRepository> logger)
        {
            this.context = context;
            this.logger = logger;
            entity = context.Set<AdminUser>();
        }
               
        public IEnumerable<AdminUser> GetAdminUsers()
        {
            logger.LogInformation("Get all admin users");
            return entity.AsEnumerable();
        }

        public AdminUser GetAdminUser(int id)
        {
            if (id == 0)
            {
                logger.LogError($"GetAdminUser id is zero {id}");
                return null;
            }
            logger.LogInformation($"GetAdminUser details of {id}");
            return entity.AsEnumerable().Where(x => x.Id == id).FirstOrDefault();
        }

        public bool CreateAdminUser(AdminUser adminUser)
        {
            if (string.IsNullOrWhiteSpace(adminUser.UserName) ||
                string.IsNullOrWhiteSpace(adminUser.Email) ||
                string.IsNullOrWhiteSpace(adminUser.PasswordHash))
            {
                logger.LogError($"CreateAdminUser UserName {adminUser.UserName}  or Email {adminUser.Email} or PasswordHash {adminUser.PasswordHash} is null");
                return false;
            }
            logger.LogInformation($"CreateAdminUser of {adminUser.UserName}");
            context.Entry(adminUser).State = EntityState.Added;
            return context.SaveChanges() > 0;
        }

        public bool UpdateAdminUser(AdminUser adminUser)
        {
            if (adminUser.Id == 0)
            {
                logger.LogError($"UpdateAdminUser of id {adminUser.Id} is null");
                return false;
            }
            logger.LogInformation($"UpdateAdminUser of {adminUser.UserName}");
            return context.SaveChanges() > 0;
        }

        public bool DeleteAdminUser(int id)
        {
            if (id == 0)
            {
                logger.LogError($"DeleteAdminUser of id {id} is null");
                return false;
            }
            AdminUser adminUser = GetAdminUser(id);
            logger.LogInformation($"DeleteAdminUser of {adminUser.UserName}");
            entity.Remove(adminUser);
            return context.SaveChanges() > 0;
        }
    }
}