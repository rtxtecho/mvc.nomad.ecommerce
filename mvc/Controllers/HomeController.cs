using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;
using mvc.business;
using System.Drawing;

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

        public string get_comp(
                                    int comp, int c_serv
                                   )
        {
            component_p comp_ = components_p.get(comp
                                               );

            string type = type_s.get(comp_.comp_type
                                    ).type;

            string r = "";

            r += get_record("Name", comp_.name, "edit_comp_name(" + comp +
                                                                  ");", "edit_comp_name"
                           );

            r += get_record("Type", type, "edit_comp_type(" + comp +
                                                                 ");", "edit_comp_type"
                          );
            string resu = Properties.Resources.ht_edit_comp.Replace("//content//", r
                                                                   )
                                                           .Replace("//src//", imgs.byte_to_base64(comp_.img, comp_.format
                                                                                              )
                                                                   );
            return resu;
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
                           "onclick = 'get_comp(" + c.ID +
                                              ")" +
                                     "'" +
                     ">";
                r += "<div " +
                           "class = 'l'" +
                       ">";
                r += "<img class = 'comp_img" +
                                   "'" +
                           "id = 'comp_img_" + c.ID +
                                "'" +
                            "src = '" + imgs.byte_to_base64(c.img, c.format
                                                           ) +
                                   "'" +
                     "/>";

                r += "</div>";
                r += "<div " +
                           "class = 'l'" +
                           " id='comp_name_" + c.ID +
                               "'" +
                      ">";
                r += c.name;

                r += "</div>";

                r += "<div " +
                           "class = 'cls'" +
                     ">";
                r += "</div>";

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
            string img = Properties.Resources.ht_create_sub_comp_img;
            string r = "";

            r += get_record("Name", ni, "create_sub_comp_name();", "create_sub_comp_name"
                            );

            r += get_record("Type", ni, "create_sub_comp_type();", "create_sub_comp_type"
                            );

            r += get_record("Image", img,
                "create_sub_comp_img();", "create_sub_comp_img"
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
                                    string name, int type, int super_comp, string img_stg,
                                    int c_serv
                                   )
        {
            string r = "";

            name = name.Trim();

            if (name == ""
                )
                r += "You must provide the <i>name</i> for this component" + "<br>";

            if (type == 0
                )
                r += "<i>Type</i> is required for this component" + "<br>";
            if (img_stg == ""
                )
                r += "<i>Image</i> is required for this component" + "<br>";

            img_stg_p ims = img_stgs_p.get(img_stg
                                          );
            if (ims == null
                )
                r += "Could not locate the image" + "<br>";

            if (!r.Equals("")
                )
                //2 = error
                return "2" + s240 + r;
            ims.purge();
            component_p comp = new component_p();

            comp.name = name;

            comp.comp_type = type;

            comp.super_comp = super_comp;

            comp.img = ims.img;
            comp.format = ims.format;
            comp.submit();

            return "0" + s240 + super_comp.ToString();
        }

        public string create_sub_comp_name(int c_serv
                                          )
        {
            string method = "create_sub_comp_name2();";

            return edit_comp_name_generic("", method
                                          );
        }


        public string edit_comp_name(int comp, int c_serv
                                            )
        {
            component_p comp_ = components_p.get(comp);

            string cur = comp_.name;

            string method = "edit_comp_name2(" + comp +
                                            ");";

            return edit_comp_name_generic(cur, method
                                           );
        }
        public string edit_comp_name2(int comp, string cur, int c_serv
                                      )
        {
            component_p comp_ = components_p.get(comp);
            comp_.revise("name", cur
                           );

            return comp + s240 + cur;
        }

        public string edit_comp_name_generic(string cur, string method
                                            )
        {

            int c = sql_code.get_c_count("component", "name"
                                        );

            string r = "<br>";

            r += get_t_bo("t_bo_edit_comp_name", cur, c
                         );

            r += "<br><br>";

            r += get_record("Store", "Store this name", method, ""
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

        public string create_sub_comp_img(int c_serv
                                          )
        {
            string r = Properties.Resources.ht_fi;

            string topic = "Choose the Image [.png, .bmp, .jpg]";

            return r + s240 + topic;
        }
        }
    }