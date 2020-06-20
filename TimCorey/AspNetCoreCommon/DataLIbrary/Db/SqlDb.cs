using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLIbrary.Db
{
    public class SqlDb : IDataAccess
    {
        public readonly IConfiguration _config;
        public SqlDb(IConfiguration config)
        {
            _config = config;
        }


        /// <summary>
        /// this will be the generic method that we call and getback a strongly typed list model
        /// this returns rows.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public async Task<List<T>> LoadData<T, U>(String storedProcedure, U parameters, string connectionStringName)
        {
            //get constr from the app that uses this class lib
            string connectonString = _config.GetConnectionString(connectionStringName);

            // T below is the model, where drapper will match the column from DB to the Model passed
            //  so we get back not datatable but a proper list of model
            using (IDbConnection connection = new SqlConnection(connectonString))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure,
                                                          parameters,
                                                          commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }


        /// <summary>
        /// common method for calls to update/ add data, this does not return data, but int which is 
        /// how many rows are affected
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public async Task<int> SaveData<T>(String storedProcedure, T parameters, string connectionStringName)
        {
            string connectonString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectonString))
            {
                return await connection.ExecuteAsync(storedProcedure,
                                                         parameters,
                                                         commandType: CommandType.StoredProcedure);
            }
        }



    }
}
