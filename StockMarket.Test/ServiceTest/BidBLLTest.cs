using Moq;
using NUnit.Framework;
using StockMarket.BLL.IService;
using StockMarket.BLL.Service;
using StockMarket.DAL.IRepos;
using StockMarket.DTO;
using StockMarket.Test.MockData;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Test.ServiceTest
{
    public class BidBLLTest
    {
        private readonly Mock<IBidDAL> _mockBid;
        private readonly Mock<IBidBLL> _mockBidBLL;
        private readonly BidBLL _bidBLL;
        private readonly BidMockData _mockBidData;

        public BidBLLTest()
        {
            _mockBid = new Mock<IBidDAL>();
            _mockBidBLL = new Mock<IBidBLL>();
            _mockBidData = new BidMockData();
            _bidBLL = new BidBLL(_mockBid.Object);
        }
        [Test]
        public void AddBid_SuccessInserted_ReturnTrue()
        {
            _mockBid.Setup(p => p.Add(It.IsAny<BidDTO>())).Returns(_mockBidData.AddBid);
            _bidBLL.AddBid(_mockBidData.AddBid());
            _mockBidBLL.VerifyAll();
        }
        [Test]
        public void DeleteBid_SuccessDeleted_ReturnTrue()
        {
            _mockBid.Setup(t => t.GetById(It.IsAny<int>())).Returns(_mockBidData.GetById);
            BidDTO bidDTO = _bidBLL.GetById(1997);
            Assert.NotNull(bidDTO);
            _mockBid.Setup(u => u.Delete(It.IsAny<int>()));
            _bidBLL.DeleteBid(bidDTO.BidId);
            _mockBidBLL.VerifyAll();
        }
        [Test]
        public void GetBidById_WhenCalled_ReturnTrade()
        {
            _mockBid.Setup(t => t.GetById(It.IsAny<int>())).Returns(_mockBidData.GetById);
            _bidBLL.GetById(1997);
            _mockBidBLL.VerifyAll();
        }
        [Test]
        public void GetAllBid_WhenCalled_ReturnAllTrade()
        {
            _mockBid.Setup(t => t.GetAll()).Returns(_mockBidData.GetAllBid);
            _bidBLL.GetAllBid();
            _mockBidBLL.VerifyAll();
        }
        [Test]
        public void UpdateBid__WhenCalled_ReturnUpdatedBid()
        {
            _mockBid.Setup(u => u.GetById(It.IsAny<int>())).Returns(_mockBidData.GetById);
            BidDTO bidDTO = _bidBLL.GetById(1997);
            Assert.NotNull(bidDTO);
            _mockBid.Setup(t => t.Update(bidDTO));
            _bidBLL.UpdateBid(1997, _mockBidData.UpdateBid());
            _mockBidBLL.VerifyAll();
        }
    }
}