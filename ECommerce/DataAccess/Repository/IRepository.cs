// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IRepository.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class IRepository<TKey> where TKey : class
    {
        public ECommerceDBContext context;
        public ILogger logger;
        public DbSet<TKey> entity;
    }
}