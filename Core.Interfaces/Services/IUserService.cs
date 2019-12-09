using Core.Domain.Interfaces;
using Infrastructure.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {

        public void AddElement(IUserDomain element);
        public void UpdateElement(IUserDomain element);
        public void DeleteElement(int id);
        public IUserDomain GetById(int id );
        public IEnumerable<IUserDomain> GetAll();
    }
}
