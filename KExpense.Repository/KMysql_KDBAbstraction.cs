using KExpense.Repository.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace KExpense.Repository
{
    public class KMysql_KDBAbstraction : AKDBAbstraction
    {
        public KMysql_KDBAbstraction(string connString) : base(connString) {   }

        public override void ExecuteReadTransaction(string query,IKModelMapper mapper)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(this.ConnectionString);
                conn.Open();


                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader dt = cmd.ExecuteReader())
                {
                    IKDataReader mysqlDatareader = new KMySqlDataReader(dt);
                    mapper.map(mysqlDatareader);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public override void ExecuteWriteTransaction(string query, IKModelMapper mapper)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(this.ConnectionString);
                conn.Open();


                MySqlCommand cmd = new MySqlCommand(query, conn);                
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
