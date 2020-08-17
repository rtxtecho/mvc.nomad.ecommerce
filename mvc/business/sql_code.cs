using System.Data.SqlClient;

namespace mvc.business
{
    public class sql_code
    {
        public static SqlConnection get_conn(
                                           )
        {
            string conn_str = "Data Source=tcp:s20.winhost.com;Initial Catalog=DB_121607_nomad;User ID=DB_121607_nomad_user;Password=nomad;Integrated Security=False;";
            SqlConnection
            conn = new SqlConnection();

            conn.ConnectionString = conn_str;

            conn.Open();

            return conn;
        }

        public static int
                    get_i(SqlDataReader SDR, string column
                         )
        {
            try
            {
                string content = SDR[column].ToString();

                int i = int.Parse(content);

                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static string
                    get_s(SqlDataReader SDR, string column
                         )
        {
            try
            {
                string content = SDR[column].ToString();

                return content;
            }
            catch
            {
                return "";
            }
        }

        public static SqlDataReader run_query(string query, ref SqlConnection conn
                                             )
        {
            conn = get_conn();

            SqlCommand cnt = new SqlCommand();

            cnt.Connection = conn;

            cnt.CommandText = query;

            SqlDataReader SDR = cnt.ExecuteReader();

            return SDR;
        }
    }
}
