using StockMarket.BLL.IService;
using StockMarket.DAL.IRepos;
using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.BLL.Service
{
     public class TradeBLL : ITradeBLL
    {
        private readonly ITradeDAL _trades;
        public TradeBLL(ITradeDAL trades)
        {
            _trades = trades;
        }
        public TradeDTO AddTrade(TradeDTO trade)
        {
            return _trades.Add(trade);
        }

        public void DeleteTrade(int id)
        {
            TradeDTO tradeExits = _trades.GetById(id);
            if(tradeExits != null)
            {
                _trades.Delete(tradeExits.TradeId);
            }
        }

        public List<TradeDTO> GetAllTrade()
        {
            return _trades.GetAll();
        }

        public TradeDTO GetById(int Id)
        {
            return _trades.GetById(Id);
        }

        public TradeDTO UpdateTrade(int id, TradeDTO trade)
        {
            TradeDTO tradeExits = _trades.GetById(id);
            if (tradeExits != null)
            {
                trade.TradeId = tradeExits.TradeId;
                return _trades.Update(trade);

            }
            return null;
        }
    }
}

