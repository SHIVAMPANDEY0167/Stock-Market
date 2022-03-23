using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Test.MockData
{
    public class BidMockData
    {
        public BidDTO AddBid()
        {
            BidDTO bidDTO = new BidDTO()
            {
                BidId = 1997,
                UserId = 102,
                Quantity = 6,
                Price  = 8000,
                TradeId =  3
            };
            return bidDTO;
        }
        public BidDTO GetById()
        {
            return new BidDTO
            {
                BidId = 1997,
                UserId = 102,
                Quantity = 6,
                Price = 8000,
                TradeId = 3
            };
        }
        public List<BidDTO> GetAllBid()
        {
            List<BidDTO> mockBidData = new List<BidDTO>()
            {
                 new BidDTO
                 {
                     BidId = 1997,
                     UserId = 102,
                     Quantity = 6,
                     Price  = 8000,
                     TradeId =  3
                 }

            };
            return mockBidData;
        }
        public BidDTO UpdateBid()
        {
            BidDTO bid = new BidDTO()
            {
                UserId = 102,
                Quantity = 6,
                Price = 8000,
                TradeId = 3
            };
            return bid;
        }
    }
}
