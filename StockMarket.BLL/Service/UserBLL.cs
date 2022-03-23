using StockMarket.BLL.IService;
using StockMarket.DAL.IRepos;
using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.BLL.Service
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _users;
        public UserBLL(IUserDAL users)
        {
            _users = users;
        }
        public virtual string AddUser(UserDTO user)
        {
            _users.Add(user);
            return "success";
        }

        public void DeleteUser(int id)
        {
            UserDTO userExits = _users.GetById(id);
            if(userExits != null)
            {
                _users.Delete(userExits.UserId);
            }
        }

        public List<UserDTO> GetAllUser()
        {
            return _users.GetAll();
        }

        public UserDTO GetById(int Id)
        {
            return _users.GetById(Id);
        }

        public UserDTO UpdateUser(int id, UserDTO user)
        {
            UserDTO userExits = _users.GetById(id);
            if(userExits !=null)
            {
                user.UserId = userExits.UserId;
                return _users.Update(user);
            }
            return null;
        }
    }
}
