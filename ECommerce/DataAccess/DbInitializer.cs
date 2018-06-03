// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "DbInitializer.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Linq;
    using DataAccess.Models.Admin;

    // Seed method is written to populate default data
    public class DbInitializer
    {
        public static void Initialize(ECommerceDBContext context)
        {
            // The EnsureCreated method automatically creates the DB for the DB context. 
            // If the DB exists, EnsureCreated returns without modifying the DB.
            // If using migrations to create DB, we dont want this. Bz this doesnt 
            // support for migration table creation
            // context.Database.EnsureCreated();

            if (context.AdminUser.Any())
            {
                // DB has been seeded
                return;
            }

            var adminUsers = new AdminUser[]
            {
                new AdminUser{
                    IsSuperAdmin = true,
                    UserName = "Admin Test User",
                    Email = "bhashiwimalasuriya@gmail.com",
                    AccessFailedCount = 0,
                    EmailConfirmed = true,
                    ConcurrencyStamp = string.Empty,
                    LastModifiedBy = 0,
                    LastModifiedOn = DateTime.UtcNow,
                    LockoutEnabled = false,
                    LockoutEnd = new DateTimeOffset(2018, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0)),
                    NormalizedEmail = "BHASHIWIMALASURIYA@GMAIL.COM",
                    NormalizedUserName= "ADMIN TEST USER",
                    PhoneNumber = string.Empty,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = string.Empty,
                    TwoFactorEnabled = false,
                    PasswordHash = "164842CE17FB7A7925F8B7BAA3B9A00A" // 123Admin
                },
                new AdminUser{
                    IsSuperAdmin = false,
                    UserName = "Pabodha Wimalasuriya",
                    Email = "pabodha.wimalasuriya123@gmail.com",
                    AccessFailedCount = 0,
                    EmailConfirmed = true,
                    ConcurrencyStamp = string.Empty,
                    LastModifiedBy = 0,
                    LastModifiedOn = DateTime.UtcNow,
                    LockoutEnabled = false,
                    LockoutEnd = new DateTimeOffset(2018, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0)),
                    NormalizedEmail = "PABODHA.WIMALASURIYA123@GMAIL.COM",
                    NormalizedUserName= "ADMIN TEST USER",
                    PhoneNumber = string.Empty,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = string.Empty,
                    TwoFactorEnabled = false,
                    PasswordHash = "164842CE17FB7A7925F8B7BAA3B9A00A" // 123Admin
                }
            };

            foreach (AdminUser user in adminUsers)
            {
                context.AdminUser.Add(user);
            }
            context.SaveChanges();
        }
    }
}