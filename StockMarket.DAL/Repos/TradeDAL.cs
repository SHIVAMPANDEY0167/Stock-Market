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

    public class TradeDAL : ITradeDAL
    {
        private string connectionString;
        public TradeDAL()
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

        public TradeDTO Add(TradeDTO trade)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO Trade VALUES (@TradeId,@TradeDate,@BuyerId,@Price,@SellerId,@Quality,@UserId)";
                    dbConnection.Open();
                    return dbConnection.ExecuteScalar<TradeDTO>(sQuery, trade);
                }
            }
            catch (Exception addException)
            {
                throw addException;
            }
        }

        public List<TradeDTO> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"SELECT * From Trade";
                    dbConnection.Open();
                    return dbConnection.Query<TradeDTO>(sQuery).ToList();
                }
            }
            catch (Exception getAllException)
            {
                throw getAllException;
            }
        }
        public TradeDTO GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"SELECT * From Trade Where TradeId=@TradeId";
                    dbConnection.Open();
                    return dbConnection.Query<TradeDTO>(sQuery, new { TradeId = id }).FirstOrDefault();
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
                    string sQuery = "DeleteTrade";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { TradeId = id }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception deleteException)
            {
                throw deleteException;
            }
        }
        public TradeDTO Update(TradeDTO trade)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = "UpdateTrade";
                    dbConnection.Open();
                    return dbConnection.Query(sQuery,
                        new {TradeId =  trade.TradeId,
                            BuyerId =trade.BuyerId, 
                            Price= trade.Price, 
                            SellerId= trade.SellerId,
                            Quality = trade.Quality,
                            UserId = trade.UserId
                        },
                        commandType:CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception updateException)
            {
                throw updateException;
            }
        }
    }
}

