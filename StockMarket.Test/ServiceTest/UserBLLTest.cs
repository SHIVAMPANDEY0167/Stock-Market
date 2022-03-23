using Moq;
using NUnit.Framework;
using StockMarket.BLL.IService;
using StockMarket.BLL.Service;
using StockMarket.BLL.UnitTests.MOCK;
using StockMarket.DAL.IRepos;
using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Test.ServiceTest
{
    [TestFixture]
    public class UserBLLTest
    {
        private readonly Mock<IUserDAL> _mockUser;
        private readonly Mock<IUserBLL> _mockUserBLL;
        private readonly UserBLL _userBLL;
        private readonly UserMockData _mockData;
        public UserBLLTest()
        {
            _mockUser = new Mock<IUserDAL>();
            _mockUserBLL = new Mock<IUserBLL>();
            _mockData = new UserMockData();
            _userBLL = new UserBLL(_mockUser.Object);
        }

        [Test]
        public void AddUser_SuccessInserted_ReturnTrue()
        {
            _mockUser.Setup(p => p.Add(It.IsAny<UserDTO>())).Returns("Success");
            _userBLL.AddUser(_mockData.InsertUser());
            _mockUserBLL.VerifyAll();
        }
        [Test]
         public void DeleteUser_SuccessDeleted_ReturnTrue()
        {
            _mockUser.Setup(u => u.GetById(It.IsAny<int>())).Returns(_mockData.GetById);
            UserDTO userDTO = _userBLL.GetById(2);
            Assert.NotNull(userDTO);
            _mockUser.Setup(u => u.Delete(It.IsAny<int>()));
            _userBLL.DeleteUser(userDTO.UserId);
            _mockUserBLL.VerifyAll();
        }
        [Test]
        public void GetUserById_WhenCalled_ReturnUser()
        {
            _mockUser.Setup(u => u.GetById(It.IsAny<int>())).Returns(_mockData.GetById);
            _userBLL.GetById(2);
            _mockUserBLL.VerifyAll();
        }
        [Test]
        public void GetAllUser_WhenCalled_ReturnAllUser()
        {
            _mockUser.Setup(u => u.GetAll()).Returns(_mockData.GetAllUser);
            _userBLL.GetAllUser();
            _mockUserBLL.VerifyAll();
        }
        [Test]
        public void UpdateUser__WhenCalled_ReturnUpdatedUser()
        {
            _mockUser.Setup(u => u.GetById(It.IsAny<int>())).Returns(_mockData.GetById);
            UserDTO userDTO = _userBLL.GetById(2);
            Assert.NotNull(userDTO);
            _mockUser.Setup(u => u.Update(userDTO));
            _userBLL.UpdateUser(2, _mockData.UpdateUser());
            _mockUserBLL.VerifyAll();
        }
    }
}
