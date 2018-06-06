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

    public class AdminRepository : IRepository<AdminUser>, IAdminRepository
    {
        public AdminRepository(ECommerceDBContext context)
        {
            this.context = context;
            entity = context.Set<AdminUser>();
        }
               
        public IEnumerable<AdminUser> GetAdminUsers()
        {
            return entity.AsEnumerable();
        }

        public AdminUser GetAdminUser(int id)
        {
            if (id == 0)
            {
                return null;
            }
            return entity.AsEnumerable().Where(x => x.Id == id).FirstOrDefault();
        }

        public bool CreateAdminUser(AdminUser adminUser)
        {
            if (string.IsNullOrWhiteSpace(adminUser.UserName) ||
                string.IsNullOrWhiteSpace(adminUser.Email) ||
                string.IsNullOrWhiteSpace(adminUser.PasswordHash))
            {
                return false;
            }
            context.Entry(adminUser).State = EntityState.Added;
            return context.SaveChanges() > 0;
        }

        public bool UpdateAdminUser(AdminUser adminUser)
        {
            if (adminUser.Id == 0)
            {
                return false;
            }
            return context.SaveChanges() > 0;
        }

        public bool DeleteAdminUser(int id)
        {
            if (id == 0)
            {
                return false;
            }
            AdminUser adminUser = GetAdminUser(id);
            entity.Remove(adminUser);
            return context.SaveChanges() > 0;
        }
    }
}