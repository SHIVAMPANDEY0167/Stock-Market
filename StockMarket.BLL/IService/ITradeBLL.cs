using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.BLL.IService
{
    public interface ITradeBLL
    {
        TradeDTO AddTrade(TradeDTO trade);
        List<TradeDTO> GetAllTrade();
        TradeDTO GetById(int Id);
        TradeDTO UpdateTrade(int id, TradeDTO trade);
        void DeleteTrade(int id);
    }
}
