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
    public class UserDAL : IUserDAL
    {
        private string connectionString;
        public UserDAL()
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

        public string Add(UserDTO user)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO Users1 (UserId,UserName,UserPassword,User_Email) VALUES (@UserId,@UserName,@UserPassword,@User_Email)";
                    dbConnection.Open();
                    dbConnection.ExecuteScalar<UserDTO>(sQuery, user);
                    return "Success";
                }
            }
            catch(Exception addException)
            {
                throw addException;
            }
        }

        public List<UserDTO> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"SELECT * From Users1";
                    dbConnection.Open();
                    return dbConnection.Query<UserDTO>(sQuery).ToList();
                }
            }
            catch(Exception getAllException)
            {
                throw getAllException;
            }
        }
        public UserDTO GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"SELECT * From Users1 Where UserId=@USerId";
                    dbConnection.Open();
                    return dbConnection.Query<UserDTO>(sQuery, new { UserId = id }).FirstOrDefault();
                }
            }
            catch(Exception getException)
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
                    string sQuery = "DeleteUser";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { UserId = id }, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception deleteException)
            {
                throw deleteException;
            }
        }
        public UserDTO Update(UserDTO user)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"UPDATE Users1 SET UserName = @UserName,UserPassword = @UserPassword, User_Email= @User_Email Where UserId=@UserId";
                    dbConnection.Open();
                    return dbConnection.Query(sQuery, new { UserId = user.UserId , UserName = user.UserName, UserPassword =user.UserPassword, User_Email= user.User_Email }).FirstOrDefault();
                }
            }
            catch(Exception updateException)
            {
                throw updateException;
            }
        }
    }
}
