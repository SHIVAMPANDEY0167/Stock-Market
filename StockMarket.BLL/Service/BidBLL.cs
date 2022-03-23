using StockMarket.BLL.IService;
using StockMarket.DAL.IRepos;
using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.BLL.Service
{
    public class BidBLL : IBidBLL
    {
        private readonly IBidDAL _bid;
        public BidBLL(IBidDAL bid)
        {
            _bid = bid;
        }
        public BidDTO AddBid(BidDTO bid)
        {
            return _bid.Add(bid); 
        }

        public void DeleteBid(int id)
        {
            BidDTO bidExits = _bid.GetById(id);
            if (bidExits != null)
            {
                _bid.Delete(bidExits.BidId);
            }
        }

        public List<BidDTO> GetAllBid()
        {
            return _bid.GetAll();
        }

        public BidDTO GetById(int Id)
        {
            return _bid.GetById(Id);
        }

        public BidDTO UpdateBid(int id, BidDTO bid)
        {
            BidDTO bidExits = _bid.GetById(id);
            if (bidExits != null)
            {
                bid.BidId = bidExits.BidId;
                return _bid.Update(bid);
            }
            return null;
        }
    }
}
