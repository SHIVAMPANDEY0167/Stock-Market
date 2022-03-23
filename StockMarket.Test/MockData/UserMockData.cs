using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.BLL.UnitTests.MOCK
{
    public class UserMockData
    {
        public UserDTO InsertUser()
        {
            UserDTO userDTO = new UserDTO()
            {
                UserId = 1,
                UserName = "kjdhfl",
                UserPassword = "dfds",
                User_Email = "sdfdass"
            };
            return userDTO;
        }
        public UserDTO GetById()
        {
            return new UserDTO
            {
                UserId = 2,
                UserName = "Shivam",
                UserPassword = "Password",
                User_Email = "Shivam@gmail.com"
            };
        }
        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> mockUserData = new List<UserDTO>()
            {
                 new UserDTO
                 {
                    UserId = 2,
                    UserName = "Shivam",
                    UserPassword = "Password",
                    User_Email = "Shivam@gmail.com"
                 },
                 new UserDTO
                 {
                    UserId = 1,
                    UserName = "kjdhfl",
                    UserPassword = "dfds",
                    User_Email = "sdfdass"
                 }
            };
            return mockUserData;
        }
        public UserDTO UpdateUser()
        {
            UserDTO user = new UserDTO()
            {
                UserName = "ShivamPandey",
                UserPassword = "Password",
                User_Email = "Shivam@gmail.com"
            };
            return user;
        }
    }
}
