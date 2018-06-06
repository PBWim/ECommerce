// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "IService.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace BusinessService.Service
{
    public class IService<TKey> where TKey : class
    {
        public TKey repository;
    }
}
