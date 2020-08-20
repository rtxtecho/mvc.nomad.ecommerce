using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.business
{
    public class component_p
    {
        public int ID = 0;

        public string name = "";

        public int comp_type = 0;

        public int super_comp = 0;

        public string img = "";





    public void submit()
    {
        string r = "insert into component ";

        r += " (name, comp_type, super_comp" + ", img" +
              ")";

        r += " values (@name, " + comp_type + "," + super_comp + ", @img" +
                     ")";

        sql_code.
        prms_p prms = new business.sql_code.prms_p();

        prms.enroll("name", name, System.Data.SqlDbType.Text
                   );

            prms.enroll("img", img, System.Data.SqlDbType.Text
                       );

            sql_code.run_non_query(r, prms
                                   );
    }
        










       public void revise(string column, string content
                                )
        {
            sql_code.revise("component", column, content, ID
                            );
            }
        }
    }
