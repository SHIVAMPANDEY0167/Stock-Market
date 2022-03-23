using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.BLL.IService
{
    public interface IUserBLL
    {
        string AddUser(UserDTO user);
        List<UserDTO> GetAllUser();
        UserDTO GetById(int Id);
        UserDTO UpdateUser(int id, UserDTO user);
        void DeleteUser(int id);
    }
}
