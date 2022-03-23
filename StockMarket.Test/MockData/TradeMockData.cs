using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Test.MockData
{
    public class TradeMockData
    {
        public TradeDTO AddTrade()
        {
            TradeDTO tradeDTO = new TradeDTO()
            {
                TradeId = 1,
                TradeDate = DateTime.Parse("2022-02-07"),
                BuyerId = 1,
                Price= 80000,
                SellerId= 2002,
                Quality= 10,
                UserId =2

            };
            return tradeDTO;
        }
        public TradeDTO GetById()
        {
            return new TradeDTO
            {
                TradeId = 1,
                TradeDate =DateTime.Parse("2022-02-07"),
                BuyerId = 1,
                Price = 80000,
                SellerId = 2002,
                Quality = 10,
                UserId = 2
            };
        }
        public List<TradeDTO> GetAllTrade()
        {
            List<TradeDTO> mockTradeData = new List<TradeDTO>()
            {
                 new TradeDTO
                 {
                     TradeId = 1,
                     TradeDate = DateTime.Parse("2022-02-07"),
                     BuyerId = 1,
                     Price= 80000,
                     SellerId= 2002,
                     Quality= 10,
                     UserId =2
                 }
                 
            };
            return mockTradeData;
        }
        public TradeDTO UpdateTrade()
        {
            TradeDTO trade = new TradeDTO()
            {
                BuyerId = 1,
                Price = 80000,
                SellerId = 2002,
                Quality = 10,
                UserId = 2
            };
            return trade;
        }
    }
}
