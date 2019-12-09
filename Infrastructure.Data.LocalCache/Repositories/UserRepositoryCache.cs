using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.Data.Interfaces.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Infrastructure.Data.LocalCache.Repositories
{
   
    public class UserRepositoryCache : IUserRepository
    {
        private readonly IAppParameters _parameters;
        private IMemoryCache cache;
       
        public UserRepositoryCache(IAppParameters parameters, IMemoryCache cache)
        {
            _parameters = parameters;
            this.cache = cache;
            
        }

        public void AddElement(IUser element)
        {
            
            if ((IUser)cache.Get(element.Id) == null)
            {
                element.CreateDate = DateTime.Now;
                cache.Set(element.Id, element);
            }
            else{
                throw new Exception("Ya existe un lemento con este id");
            }
            
            
        }

        public void DeleteElement(IUser element)
        {
            cache.Remove(element.Id);
           
        }

        public IEnumerable<IUser> GetAll()
        {
            
            return null;
            //var result = new List<IUser>();
            //foreach (var key in keys)
            //{
            //    var user = (IUser)cache.Get(key);
            //    result.Add(user);
            //}
            //return result;
        }

        public IUser GetById(int id)
        {
            
            return (IUser)cache.Get(id);
           
        }

        public void UpdateElement(IUser element)
        {
            element.UpdateDate = DateTime.Now;         
            cache.Set(element.Id, element);
        }


    }


}
