using Infrastructure.Data.Core.Entities;
using Infrastructure.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {

        public void AddElement(IUser element);
        public void UpdateElement(IUser element);
        public void DeleteElement(IUser element);

        public IUser GetById(int id);
        public IEnumerable<IUser> GetAll();

    }
}
