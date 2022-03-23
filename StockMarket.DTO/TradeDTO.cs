using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.DTO
{
    public class TradeDTO
    {
        public int TradeId { get; set; }
        public DateTime TradeDate { get; set; }
        public int BuyerId { get; set; }
        public int Price { get; set; }
        public int SellerId { get; set; }
        public int Quality { get; set; }
        public int UserId { get; set; }
    }
}
