// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IRepository.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.Repository
{
    using Microsoft.EntityFrameworkCore;

    public class IRepository<TKey> where TKey : class
    {
        public ECommerceDBContext context;
        public DbSet<TKey> entity;
    }
}