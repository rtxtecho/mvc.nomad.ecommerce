using System.Collections.Generic;

using System.Data.SqlClient;

using System.Data;

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

        public static void run_non_query(string query, prms_p prms
                                             )
        {
            SqlConnection
            conn = get_conn();

            SqlCommand cnt = new SqlCommand();

            cnt.Connection = conn;

            cnt.CommandText = query;

            foreach (prm_p prm in prms.curs
                    )
            {
                cnt.Parameters.Add("@" + prm.pseudo, prm.type
                                   );

                cnt.Parameters["@" + prm.pseudo].Value = prm.content;
            }

            cnt.ExecuteNonQuery();

            cnt.Dispose();

            conn.Close();

            conn.Dispose();
        } 

    public
    class prm_p
    {
        public
        string pseudo = "";
        public
        string content;
        public
        SqlDbType type;
    }

    public class prms_p
    {
        public
        List<prm_p>
            curs = new List<prm_p>();

        public void enroll(string pseudo, string content, SqlDbType type
                          )
        {
            prm_p prm = new prm_p();

            prm.pseudo = pseudo;

            prm.content = content;

            prm.type = type;

            curs.Add(prm);
        }
    }
}
    }