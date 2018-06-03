// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "ECommerceDBContext.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace DataAccess
{
    using DataAccess.Models.Admin;
    using Microsoft.EntityFrameworkCore;

    // The data context specifies which entities are included in the data model
    // When the DB is created, EF Core creates tables that have names the same as the DbSet property names
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options) : base(options) { }

        // DbSet property for each entity set (An entity set typically corresponds to a DB table, 
        // An entity corresponds to a row in the table.)
        public DbSet<AdminUser> AdminUser { get; set; }
    }
}