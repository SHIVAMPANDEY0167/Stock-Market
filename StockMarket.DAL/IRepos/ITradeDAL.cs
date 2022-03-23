using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.DAL.IRepos
{
    public interface ITradeDAL
    {
        TradeDTO Add(TradeDTO trade);
        List<TradeDTO> GetAll();
        TradeDTO GetById(int id);
        void Delete(int id);
        TradeDTO Update(TradeDTO trade);
    }
}
