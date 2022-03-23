using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.DAL.IRepos
{
    public interface IUserDAL
    {
        string Add(UserDTO user);
        List<UserDTO> GetAll();
        UserDTO GetById(int id);
        void Delete(int id);
        UserDTO Update(UserDTO user);
    }
}
