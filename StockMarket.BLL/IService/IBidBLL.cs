using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.BLL.IService
{
    public interface IBidBLL
    {
        BidDTO AddBid(BidDTO bid);
        List<BidDTO> GetAllBid();
        BidDTO GetById(int Id);
        BidDTO UpdateBid(int id, BidDTO bid);
        void DeleteBid(int id);
    }
}
