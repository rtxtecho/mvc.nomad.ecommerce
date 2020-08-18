using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;
using mvc.business;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        public string s240 = "" + (char)240;
        public string ni = "<i>Not Identified</i>";

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }
        public string get_record(
                                 string nomencl,
                                 string summary,
                                 string method,
                                 string id
                                 )
        {
            string r = Properties.Resources.ht_rec.Replace("//nomencl//", nomencl
                                                           )
                                                   .Replace("//summary//", summary
                                                           )
                                                   .Replace("//method//", method
                                                           )
                                                   .Replace("//id//", id
                                                           );
            return r;
        }

        public string get_sub_comps(
                                    int comp, int c_serv
                                   )
        {
            List<component_p> comps = components_p.get_sub_comps(comp);

            string r = "";

            foreach (component_p c in comps
                      )
            {
                r += "<div " +
                           "class = 'get_sub' " +
                           "onclick = 'get_sub_comps(" + c.ID +
                                                   ");" +
                                     "'" +
                     ">";

                r += "+";

                r += "</div>";

                r += "<div " +
                           "class = 'get_sub' " +
                           "onclick = 'create_sub_comp(" + c.ID +
                                                      ");" +
                                     "'" +
                     ">";

                r += "*";

                r += "</div>";

                r += "<div " +
                           "class = 'l'" +
                     ">";

                r += c.name;

                r += "</div>";

                r += "<div " +
                           "class = 'cls'" +
                     ">";

                r += "</div>";

                r += "<div " +
                            "class = 'sub_comps" +
                                    "'" + " " +
                            "id = 'sub_comps_" + c.ID +
                                  "'" +
                     ">";

                r += "</div>";
            }
            return r + s240 + comp;
        }

        public string get_t_bo(
                               string id,
                               string cur,
                               int mx
                               )
        {
            int c_cur = cur.Length;

            string r = Properties.Resources.ht_t_bo.Replace("//id//", id
                                                           )
                                                    .Replace("//cur//", cur
                                                           )
                                                    .Replace("//c_cur//", c_cur.ToString()
                                                           )
                                                    .Replace("//c_mx//", mx.ToString()
                                                           );

            return r;
        }

        public string create_sub_comp(
                                    int comp, int c_serv
                                   )
        {
            string r = "";

            r += get_record("Name", ni, "create_sub_comp_name();", "create_sub_comp_name"
                            );

            r += get_record("Type", ni, "create_sub_comp_type();", "create_sub_comp_type"
                            );

            r += get_record("Image", ni, "create_sub_comp_image();", "create_sub_comp_image"
                            );

            r += "<br><br>";

            r += get_record("Store", "Store this component", "create_sub_comp2(" + comp +
                                                                             ");", ""
                           );

            string topic = "Create Component";

            if (comp > 0
                )
            {
                topic = "Create Sub Component for: ";

                component_p comp_ =
                    components_p.get(comp);

                topic += comp_.name;
            }

            r += s240 + topic;

            return r;
        }

        public string create_sub_comp2(
                                    string name, int type, int super_comp, int c_serv
                                   )
        {
            component_p comp = new component_p();

            comp.name = name;

            comp.comp_type = type;

            comp.super_comp = super_comp;

            comp.submit();

            return "";
        }

        public string create_sub_comp_name(int c_serv
                                          )
        {
            int c = sql_code.get_c_count("component", "name"
                                        );

            string r = "<br>";

            r += get_t_bo("t_bo_create_sub_comp_name", "", c
                         );

            r += "<br><br>";

            r += get_record("Store", "Store this name", "create_sub_comp_name2();", ""
                           );

            string topic = "Component Name";

            r += s240 + topic;

            return r;
        }

        public string create_sub_comp_type(int c_serv
                                          )
        {
            List<type_> types = type_s.get();

            string r = "<br>";

            foreach (type_ ty in types
                    )
            {
                string prms = ty.ID + ",'" + ty.type +
                                         "'";

                r += Properties.Resources.ht_srs.Replace("//method//", "create_sub_comp_type2"
                                                        )
                                                .Replace("//prms//", prms
                                                        )
                                                .Replace("//content//", ty.type
                                                        );
            }

            string topic = "Choose the type";

            return r + s240 + topic;
        }
        }
    }