using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.DTO
{
    public class BidDTO
    {
        public int BidId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TradeId { get; set; }
    }
}
