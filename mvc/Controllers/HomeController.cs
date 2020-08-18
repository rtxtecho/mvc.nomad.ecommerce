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

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        public string get_sub_comps(
                                    int comp
                                   )
        {
            component_p compo = new business.component_p();

            compo.name = "zzzzzzzzzzzz";

            compo.submit();
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
    }
}

