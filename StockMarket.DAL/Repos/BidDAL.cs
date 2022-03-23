using Dapper;
using StockMarket.DAL.IRepos;
using StockMarket.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StockMarket.DAL.Repos
{
    public class BidDAL : IBidDAL
    {
        private string connectionString;
        public BidDAL()
        {
            connectionString = @"Data Source=.;Initial Catalog=Stock_Market1;Integrated Security=True";
        }

        public IDbConnection Connection
        {
            get
            { 
       
                return new SqlConnection(connectionString);
            }
        }

        public BidDTO Add(BidDTO bid)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO Bid VALUES (@BidId,@UserId,@Quantity,@Price,@TradeId)";
                    dbConnection.Open();
                    return dbConnection.ExecuteScalar<BidDTO>(sQuery, bid);
                }
            }
            catch (Exception addException)
            {
                throw addException;
            }
        }

        public List<BidDTO> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"SELECT * From Bid";
                    dbConnection.Open();
                    return dbConnection.Query<BidDTO>(sQuery).ToList();
                }
            }
            catch (Exception getAllException)
            {
                throw getAllException;
            }
        }
        public BidDTO GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"SELECT * From Bid Where BidId=@BidId";
                    dbConnection.Open();
                    return dbConnection.Query<BidDTO>(sQuery, new { TradeId = id }).FirstOrDefault();
                }
            }
            catch (Exception getException)
            {
                throw getException;
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"DELETE FROM Bid Where BidId=@BidId";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { TradeId = id });
                }
            }
            catch (Exception deleteException)
            {
                throw deleteException;
            }
        }
        public BidDTO Update(BidDTO bid)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = "UPDATE Bid SET UserId=@UserId,Quantity=@Quantity,Price=@Price,TradeId=@TradeId Where BidId=@BidId";
                    dbConnection.Open();
                    return dbConnection.Query(sQuery, new { BidId = bid.BidId, UserId = bid.UserId, Quantity = bid.Quantity, Price = bid.Price,TradeId=bid.TradeId}).FirstOrDefault();
                }
            }
            catch (Exception updateException)
            {
                throw updateException;
            }
        }

       
    }
}
