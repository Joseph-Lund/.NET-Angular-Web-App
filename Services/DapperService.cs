using Dapper;  
using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.Logging;
using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.Common;  
using Microsoft.Data.SqlClient;  
using System.Linq;
  
namespace net_5.Services
{  
    public class DapperService : IDapperService  
    {  
        private readonly ILogger<DapperService> _logger;
        private readonly IConfiguration _config;  
        private string Connectionstring = "DefaultConnection";  
  
        public  DapperService(ILogger<DapperService> logger, IConfiguration config)  
        {  
            _logger = logger;
            _config = config;  
        }  
        public void Dispose()  
        {  
             
        }  
  
        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)  
        {  
            throw new NotImplementedException();  
        }  
  
        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)  
        {  
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));  
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();  
        }  
  
        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)  
        {  
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));  
            return db.Query<T>(sp, parms, commandType: commandType).ToList();  
        }  
  
        public DbConnection GetDbconnection()  
        {  
            return new SqlConnection(_config.GetConnectionString(Connectionstring));  
        }  
  
        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)  
        {  
            T result;  
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));  
            try  
            {  
                if (db.State == ConnectionState.Closed)  
                    db.Open();  
  
                using var tran = db.BeginTransaction();  
                try  
                {  
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();  
                    tran.Commit();  
                }
                catch (Exception ex)  
                {  
                    _logger.LogError(default(EventId), ex, "Error Inserting for sp:" + sp, null);
                    tran.Rollback();  
                    throw;  
                }  
            }  
            catch (Exception ex)  
            {  
                _logger.LogError(default(EventId), ex, "Error Connecting to database for sp:" + sp, null);
                throw;  
            }  
            finally  
            {  
                if (db.State == ConnectionState.Open)  
                    db.Close();  
            }  
  
            return result;  
        }  
  
        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)  
        {  
            T result;  
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));  
            try  
            {  
                if (db.State == ConnectionState.Closed)  
                    db.Open();  
  
                using var tran = db.BeginTransaction();  
                try  
                {  
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();  
                    tran.Commit();  
                }  
                catch (Exception ex)  
                {  
                    _logger.LogError(default(EventId), ex, "Error Updateing for sp:" + sp, null);
                    tran.Rollback();  
                    throw;  
                }  
            }  
            catch (Exception ex)  
            {  
                _logger.LogError(default(EventId), ex, "Error Connecting to database for sp:" + sp, null);
                throw;  
            }  
            finally  
            {  
                if (db.State == ConnectionState.Open)  
                    db.Close();  
            }  
  
            return result;  
        }  
    }  
}  