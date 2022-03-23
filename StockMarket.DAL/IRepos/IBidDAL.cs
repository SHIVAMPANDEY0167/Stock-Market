using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.DAL.IRepos
{
    public interface IBidDAL
    {
        BidDTO Add(BidDTO bid);
        List<BidDTO> GetAll();
        BidDTO GetById(int id);
        void Delete(int id);
        BidDTO Update(BidDTO bid);
    }
}
