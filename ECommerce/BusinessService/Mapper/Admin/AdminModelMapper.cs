// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "AdminModelMapper.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace BusinessService.Mapper.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using BusinessService.Mapper.Contract.Admin;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using BO = Model;
    using RO = DataAccess.Models.Admin;

    public class AdminModelMapper : IAdminModelMapper
    {
        public BO.AdminUser Map(RO.AdminUser adminUser)
        {
            return new BO.AdminUser
            {
                UserName = adminUser.UserName,
                Email = adminUser.Email,
                Password = adminUser.PasswordHash,
                Telephone = adminUser.PhoneNumber
            };
        }

        public RO.AdminUser Map(BO.AdminUser adminUser)
        {
            return new RO.AdminUser
            {
                Email = adminUser.Email,
                UserName = adminUser.UserName,
                PhoneNumber = adminUser.Telephone,
                PasswordHash = GetHashPassowrd(adminUser.Password),
                LastModifiedOn = DateTime.UtcNow,
                LastModifiedBy = 1, // TODO : Get current admin user id
                AccessFailedCount = 0,
                NormalizedEmail = adminUser.Email.ToUpper(),
                NormalizedUserName = adminUser.UserName.ToUpper(),
                LockoutEnd = new DateTimeOffset(2018, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0))
            };
        }

        public IEnumerable<BO.AdminUser> Map(IEnumerable<RO.AdminUser> adminUser)
        {
            List<BO.AdminUser> adminUserList = new List<BO.AdminUser>();
            foreach (var item in adminUser)
            {
                adminUserList.Add(Map(item));
            }
            return adminUserList;
        }

        public IEnumerable<RO.AdminUser> Map(IEnumerable<BO.AdminUser> adminUser)
        {
            List<RO.AdminUser> adminUserList = new List<RO.AdminUser>();
            foreach (var item in adminUser)
            {
                adminUserList.Add(Map(item));
            }
            return adminUserList;
        }

        private string GetHashPassowrd(string rawPassword)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: rawPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}