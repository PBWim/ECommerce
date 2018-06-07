// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IService.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace BusinessService.Service
{
    using Microsoft.Extensions.Logging;

    public class IService<TKey> where TKey : class
    {
        public TKey repository;
        public ILogger logger;
    }
}