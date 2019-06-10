using System;
using System.Data.SqlClient;

namespace AccessData
{
    public class AccessDataDBConnection
    {
        const string connString = "Data Source=192.168.99.100,11433;Initial Catalog=db_profile;User Id=SA;Password=isabella*15";
        // @"Provider=SQLOLEDB;Data Source=(local); integrated Security=SSPI; Initial Catalog=db_profile; Encrypt=true;"

        public SqlConnection CreateConnection()
        {
            using (var conn = new SqlConnection())
            {
                
            }
        }
    }
}
