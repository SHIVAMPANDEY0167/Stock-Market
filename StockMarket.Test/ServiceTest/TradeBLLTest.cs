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
    [TestFixture]
    public class TradeBLLTest
    {
        private readonly Mock<ITradeDAL> _mockTrade;
        private readonly Mock<ITradeBLL> _mockTradeBLL;
        private readonly TradeBLL _tradeBLL;
        private readonly TradeMockData _mockTradeData;

        public TradeBLLTest()
        {
            _mockTrade = new Mock<ITradeDAL>();
            _mockTradeBLL = new Mock<ITradeBLL>();
            _mockTradeData = new TradeMockData();
            _tradeBLL = new TradeBLL(_mockTrade.Object);
        }
        [Test]
        public void AddTrade_SuccessInserted_ReturnTrue()
        {
            _mockTrade.Setup(p => p.Add(It.IsAny<TradeDTO>())).Returns(_mockTradeData.AddTrade);
            _tradeBLL.AddTrade(_mockTradeData.AddTrade());
            _mockTradeBLL.VerifyAll();
        }
        [Test]
        public void DeleteTrade_SuccessDeleted_ReturnTrue()
        {
            _mockTrade.Setup(t => t.GetById(It.IsAny<int>())).Returns(_mockTradeData.GetById);
            TradeDTO tradeDTO = _tradeBLL.GetById(1);
            Assert.NotNull(tradeDTO);
            _mockTrade.Setup(u => u.Delete(It.IsAny<int>()));
            _tradeBLL.DeleteTrade(tradeDTO.TradeId);
            _mockTradeBLL.VerifyAll();
        }
        [Test]
        public void GetTradeById_WhenCalled_ReturnTrade()
        {
            _mockTrade.Setup(t => t.GetById(It.IsAny<int>())).Returns(_mockTradeData.GetById);
            _tradeBLL.GetById(1);
            _mockTradeBLL.VerifyAll();
        }
        [Test]
        public void GetAllTrade_WhenCalled_ReturnAllTrade()
        {
            _mockTrade.Setup(t => t.GetAll()).Returns(_mockTradeData.GetAllTrade);
            _tradeBLL.GetAllTrade();
            _mockTradeBLL.VerifyAll();
        }
        [Test]
        public void UpdateTrade__WhenCalled_ReturnUpdatedTrade()
        {
            _mockTrade.Setup(u => u.GetById(It.IsAny<int>())).Returns(_mockTradeData.GetById);
            TradeDTO tradeDTO = _tradeBLL.GetById(1);
            Assert.NotNull(tradeDTO);
            _mockTrade.Setup(t => t.Update(tradeDTO));
            _tradeBLL.UpdateTrade(2, _mockTradeData.UpdateTrade());
            _mockTradeBLL.VerifyAll();
        }
    }
}
    
