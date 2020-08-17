using System.Collections.Generic;
using System.Data.SqlClient;

namespace mvc.business
{
    public class components_p
    {
        public static component_p get(SqlDataReader SDR
                                     )
        {
            component_p comp = new business.component_p();

            comp.ID = sql_code.get_i(SDR, "ID"
                                    );

            comp.name = sql_code.get_s(SDR, "name"
                                    );

            comp.comp_type = sql_code.get_i(SDR, "comp_type"
                                           );

            comp.super_comp = sql_code.get_i(SDR, "super_comp"
                                             );

            return comp;
        }

        public static List<component_p> get_sub_comps(int comp
                                                     )
        {
            string r = "select * from components where super_comp = " + comp;

            SqlConnection conn = null;

            SqlDataReader SDR = sql_code.run_query(r, ref conn
                                                  );

            List<component_p> comps = new List<business.component_p>();

            for (; SDR.Read();
                )
            {
                component_p c = get(SDR);

                comps.Add(c);
            }

            SDR.Close();

            conn.Close();

            conn.Dispose();

            return comps;
        }
    }
}


                        